

## Module 4: Layouts & pages

### Introduction
Xamarin.Forms Layouts are used to compose user-interface controls into visual structures. They are visual elements but often none of them is actually seen (however we can use their properties to set background easier), what can be observed is the way the elements can be arranged trough them.

![enter image description here](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/controls/layouts-images/layouts-sml.png)

### Types of Layouts
Based of the number of children we can split them into 2 categories:
- Layouts with a single child: ContentView, Frame (usually used for its border), ScrollView, TemplatedView (the basic view) and ContentPresenter
- Layouts with multiple children: StackLayout, Grid, AbsoluteLayout, RelativeLayout and FlexLayout

### Application's layouts
[Layouts](https://developer.xamarin.com/guides/xamarin-forms/user-interface/controls/layouts/) are the very first structural level of an application's UI, being the base on which elements are being added - a container which holds all the elements and orders them. Depending on the application needed to be created, one or more layouts are being added to the [XAML](https://msdn.microsoft.com/en-us/library/cc295302.aspx) file. Those can be also get generated in the code, it is really a matter of taste.
From all the available layouts, more often used are:
- [Grid](https://developer.xamarin.com/api/type/Xamarin.Forms.Grid/), a layout which allows the developer to create rows and columns in the current view and add elements in them and therefore create a table-like view.
-[ScrollView](https://developer.xamarin.com/api/type/Xamarin.Forms.ScrollView/), which provides a scrollable view by arranging the elements to their height in the order in which they are added and when exceeding the heights of the device's screen it automatically becomes scrollable;
- [**StackLayout**](https://developer.xamarin.com/api/type/Xamarin.Forms.StackLayout/) is the most widely used layout because it provides two kind of orientation of the held elements:
  - vertical: aligning the elements from the upper side of the screen to the lower side, in the exact order they are added in the layout. 
  - horizontal: in which the elements are being aligned from left to right also in the same order from the layout.

### Current application's structure:
```
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:MobileDemo"
             x:Class="MobileDemo.MainPage"
             BackgroundColor="WhiteSmoke"
             Title="This is my shopping list app!">
    <Grid>
        <!--This layout contains content elements, like lists and text views-->
        <StackLayout
            x:Name="content"
            Orientation="Vertical"
            MinimumHeightRequest="600"
            MinimumWidthRequest="200"
            BackgroundColor="Transparent">
        </StackLayout>

        <!--This is a layout which will contain action elements like buttons-->
        <StackLayout
            x:Name="actions"
            Orientation="Vertical">
        </StackLayout>
    </Grid>
</ContentPage>
```
Notice that two StackLayouts are used for the two main parts of the page:
- the **content StackLayout** (the x:Name sets the Name property of the current object - see "x" as "this"); this part will contain data display.
- the **action StackLayout** will hold elements that will take an action on the data.


### Multiple layouts
Note that it is not necessary to have only one layout in a page - remember, a page is not a layout. Therefore, you can add as many layouts as you need and of as many types as you want. For example, here we have a StackLayout that contains one other StackLayout (which also hold 3 other StackLayouts) and another TemplateView.
<p align="center"><img height="300" alt="Crazy layouts" src="https://github.com/microsoft-dx/xamarin-fundamentals-ui/blob/master/Images/layouts.png?raw=true" margin=auto></p>


## Application's pages
A mobile application can have one or more [pages](https://developer.xamarin.com/guides/xamarin-forms/user-interface/controls/pages/) - these depend on the complexity of the application but also on the desired user experience. Considering this, pages can be of multiple types, among which worth mentioning:
- [Content pages](https://developer.xamarin.com/api/type/Xamarin.Forms.ContentPage/) - basic content-like page which allows elements to be oriented by the user.
- [Navigation pages](https://developer.xamarin.com/api/type/Xamarin.Forms.NavigationPage/) which allow each device's native workflow (sliding on Windows Phone and Android or buttons navigation on iOS - see WhatsApp, for example).


## Navigation through pages
To create the navigation between the pages, first of all the pages _need to be added in the project_.
As the App page and the MainPage are already added in the project, to add elements to the MainPage we only need to edit the XAML file MainPage.xaml and add elements to it, such as the two StackLayouts added in the current solution.
Further, to add a new page we have to right-click on the Portable solution of the project and add a new ContentPage to the solution:
<p align="center"><img height="500" alt="New page" src="https://github.com/microsoft-dx/xamarin-fundamentals-ui/blob/master/Images/new-page.png?raw=true" margin=auto></p>

As a shopping list application needs to allow adding a new item to the shopping list, the most clean way of doing that action is by having another page for the data input of the new item being added to the shopping list.
Make sure to add a new xaml **Content Page** because this type of page already has a C# file behind it added to the project at the same time:

<p align="center"><img height="450" alt="New page" src="https://github.com/microsoft-dx/xamarin-fundamentals-ui/blob/master/Images/new-item.PNG?raw=true" margin=auto></p>

The C# file (\<FileName>.cs) is the back-end implementation of this current page and this part will be covered in tomorrow's Xamarin Forms Back-end part session. The current UI structure is:

```
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="MobileDemo.NewItem">
    <ContentPage.Content>
        <StackLayout Orientation="Vertical">
            <Grid>
                <Grid.RowDefinitions>
                    <RowDefinition Height="*" />
                </Grid.RowDefinitions>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="*" />
                    <ColumnDefinition Width="*" />
                </Grid.ColumnDefinitions>
            </Grid>
            <Entry 
               x:Name="amountEntry"
               TextColor="DarkBlue" 
               Margin="0,0,0,20" 
               Placeholder="Please insert an item name" 
               Grid.Column="1" />
        </StackLayout>
    </ContentPage.Content>
</ContentPage>
```


### Your turn
What do you think should this page's code be? A StackLayout or maybe a GridLayout? Have a discussion about this with the instructor.
