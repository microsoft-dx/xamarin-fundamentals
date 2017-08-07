## Module 5: Observable Collections

### ListView
In this application's case, a very important element is the actual shopping items list, which was created using a [ListView](https://developer.xamarin.com/guides/xamarin-forms/user-interface/listview/) which is a list of cells - cells containing text and/or icons or other elements.

As said, a ListView is formed of cells, which can be [ImageCells](https://developer.xamarin.com/guides/xamarin-forms/user-interface/listview/customizing-cell-appearance/#ImageCell), [TextCells](https://developer.xamarin.com/guides/xamarin-forms/user-interface/listview/customizing-cell-appearance/#TextCell) or [CustomCells](https://developer.xamarin.com/guides/xamarin-forms/user-interface/listview/customizing-cell-appearance/#Custom_Cells) that will definately suit each developer's needs. And as it is a native element, each platform has its custom ListView style:
<p align="center"><img height="200" alt="Icons" src="https://github.com/microsoft-dx/xamarin-fundamentals-ui/blob/master/Images/listview.png?raw=true" margin=auto></p>

[Image source](https://blog.xamarin.com/wp-content/uploads/2014/06/ListView-With-Monkeys.png)

Today, we are going to tap into the CustomCells, more specifically the *ViewCell* and how we can customize and template data in our own way.

#### Data templating

ListViews can only be populated dynamically (although you can have a resource or static class that you pass to the ItemsSource property, but why would you do that? :confused:), so we will create a method which will populate our list with shopping list items. For this, we will create our own model of shopping list item, let's call it `ShoppingItem` and we will create a new folder called `Models` in the project and put the newly created class in it, as shown below.

<table>
	<tr>
		<td><img alt="new_class" src="https://github.com/microsoft-dx/xamarin-fundamentals-ui/blob/master/Images/new-class.png?raw=true"></td>
		<td><img alt="new_folder" src="https://github.com/microsoft-dx/xamarin-fundamentals-ui/blob/master/Images/new-folder.png?raw=true"></td>
	</tr>
</table>

Model classes, also known as DTOs (Data Transfer Objects), are objects that hold no state and their sole purpose is to transfer data from the backend to the frontend (this process usually implies a data mapping between backend and frontend classes and we will do this, tommorow, in the SQLite module).

The `ShoppingItem` is modeled as follows:
```cs
public class ShoppingItem
{
    public int ItemId { get; set; }
    
    public string ItemName { get; set; }
}
```

The `ItemName` will store the shopping item name (we will add insert functionality tommorow :bowtie:) and the `ItemId` property will store the item identifier from the database (we will be needing this in the UI as well). Also, we need *properties* and not *variables* to be able to access them from the UI (we will see in a moment). We will now create and template our ListView as follows, inside of the StackLayout with `x:Name=content`:
```cs
<ListView x:Name="contentListView" ItemTapped="contentListView_ItemTapped">
    <ListView.ItemTemplate>
        <DataTemplate>
            <ViewCell>
                <Grid>
                    <Label Text="{Binding ItemId}" IsVisible="False" />
                    <Label Text="{Binding ItemName}" />
                </Grid>
            </ViewCell>
        </DataTemplate>
    </ListView.ItemTemplate>
</ListView>
```

The are a couple of new things in the code above, let's review it :grin: . From the previous module, we know that this ListView can be identified in the C# code by the variable `contentListView`. We define an event (will learn more about delegates in the next module) in which we will handle when an item from our list has been clicked and delete it from the list from now.

The ViewCell will be rendered for each item in the shopping list and for each item, a Grid will be displayed, with two labels - one for the ItemName and one for the ItemId. Observe that the Text property has a **Binding** attribute inside - this syntax means that this property will be dynamic and it will get it's value from the `ItemId` or `ItemName` property by calling the `getter`.

We do not need to display the `ItemId`, because we will use this in the backend to know on which item from the list we clicked, so we will set the `IsVisible` property to `False`.

### The `List<T>` does not work !

As you probably figured out by now, we will need a list in which to store the items that we have in the database and display them in the UI. For now, we will instantiate the list and hardcode some elements, but keep in mind that this list will be populated from the database and now we only want the UI to work, so we [mock implement](https://en.wikipedia.org/wiki/Mock_object) the backend.

We will now create a basic `List<ShoppingItem>` and populate it with some data. We will also implement the item deletion from the list, so our `MainPage.xaml.cs` will look something like this:

```cs
public partial class MainPage : ContentPage
{
    public List<ShoppingItem> ShoppingItemsList { get; set; }

    public MainPage()
    {
        InitializeComponent();
        InitializeItems();

        contentListView.ItemsSource = ShoppingItemsList;
    }

    private void InitializeItems()
    {
        //TODO This will be populated from the database
        var contentForList = new List<ShoppingItem>
        {
            new ShoppingItem { ItemId = 1, ItemName = "item1"},
            new ShoppingItem { ItemId = 2, ItemName = "item2"},
            new ShoppingItem { ItemId = 3, ItemName = "item3"},
            new ShoppingItem { ItemId = 4, ItemName = "item4"}
	    };

        this.ShoppingItemsList = new contentForList;
    }

    private void contentListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
         var item = (sender as ListView).SelectedItem as ShoppingItem;
         var index = this.ShoppingItemsList
			 .IndexOf(item);

         this.ShoppingItemsList.RemoveAt(this.ShoppingItemsList.IndexOf(item));
    }
}
```

The `sender` in this case is the ListView, because that objects sends the event and sets the SelectedItem property to the current item that was selected. The reason we cast it without checking is because we know that the sender is a `ListView` and the `SelectedItem` is a `ShoppingItem` (in production environments we should check before casting like this but we don't care for now :sweat_smile:).

Now that everything compiles, we should be able to run our application. We will set the `MobileDemo.UWP` project as a start-up project by right clicking it and selecting `Set as StartUp Project` because it provides very quick access to see how things are going and we don't have to wait for an Android VM or Mac connection issues. As we can see in the image below, the first item of the list is not displayed due to debugging tools being enabled. A way to disable it would be to go to `App.xaml.cs` and comment the `this.DebugSettings.EnableFrameRateCounter = true;` line. Although the debug settings are good to have, we do not need them in the context of this module.

![uwp-observable-collections](https://github.com/microsoft-dx/xamarin-fundamentals-ui/blob/master/Images/uwp-observable-collections.png?raw=true)

We will now check the functionality of the list, it should delete the items as we click them.

-----------------------------------------------------
<details> 
    <summary>It's not working... :scream: but why? (be advised, Game of Thrones spoilers below) </summary>
    The main reason the UI is not updated is because the UI is not notified about the deletion of an item from that list. So, in order to update the UI, we will need to implement an mechanism that should notify and remove from the UI the selected element. Luckily, this already exists :relaxed:
    
    No GoT spoilers though.
</details>

-----------------------------------------------------

Let's put a breakpoint in the `contentListView_ItemTapped` method to see what is happening. We see that if we click once on item 4 for example, it gets the item and the index correctly and also removes the item from the list but still shows in the UI. Can you guess what happens if we click the forth item again? No exception, but that is not strange at all, because the object does not exist anymore but exists in the UI. We can go and remove the entire list and click multiple times on the items and still not crash.

You can now watch the spoiler, it will not bite :stuck_out_tongue:, promise. The class we need to use in this context is the `ObservableCollection<ShoppingItem>` which has all the functionalities of a list **and** necessary implementations to notify the UI about insertions and deletions. We will modify our code as follows:

```cs
public partial class MainPage : ContentPage
{
    public ObservableCollection<ShoppingItem> ShoppingItems { get; set; }

    public MainPage()
    {
        InitializeComponent();
        InitializeItems();

        contentListView.ItemsSource = ShoppingItems;
    }

    private void InitializeItems()
    {
        //TODO This will be populated from the database
        var contentForCollection= new List<ShoppingItem>
        {
            new ShoppingItem { ItemId = 1, ItemName = "item1"},
            new ShoppingItem { ItemId = 2, ItemName = "item2"},
            new ShoppingItem { ItemId = 3, ItemName = "item3"},
            new ShoppingItem { ItemId = 4, ItemName = "item4"}
	    };

        this.ShoppingItems = new ObservableCollection<ShoppingItem>(contentForCollection);
    }

    private void contentListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
         var item = (sender as ListView).SelectedItem as ShoppingItem;
         var index = this.ShoppingItems
             .IndexOf(item);

         this.ShoppingItems.RemoveAt(this.ShoppingItems.IndexOf(item));
    }
}
```

We will now run the application and see that everything works as expected :relaxed:
