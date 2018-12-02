## Module 4: Layouts & pages

### Introduction
Xamarin.Forms Layouts are used to compose user-interface controls into visual structures. They are visual elements but often none of them are actually seen. However, we can use their properties to set the background more easily. What can be observed is the way in which the elements can be arranged through them.

![enter image description here](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/controls/layouts-images/layouts-sml.png)

### Types of Layouts
Based on the number of children we can split them into 2 categories:
- Layouts with a single child: ContentView, Frame (usually used for its border), ScrollView, TemplatedView (the basic view) and ContentPresenter
- Layouts with multiple children: StackLayout, Grid, AbsoluteLayout, RelativeLayout and FlexLayout

### Application's layouts
[Layouts](https://developer.xamarin.com/guides/xamarin-forms/user-interface/controls/layouts/) are the very first structural level of an application's UI, being the base on which elements are being added - a container which holds all the elements and orders them. Depending on the application that needs to be created, one or more layouts can be added to the [XAML](https://msdn.microsoft.com/en-us/library/cc295302.aspx) file. They can also be generated in the code, it is really a matter of taste.
From all the available layouts, here's what is more often that not used:
- [Grid](https://developer.xamarin.com/api/type/Xamarin.Forms.Grid/), a layout which allows the developer to create rows and columns in the current view and add elements in them and therefore create a table-like view.
-[ScrollView](https://developer.xamarin.com/api/type/Xamarin.Forms.ScrollView/), which provides a scrollable view by arranging the elements to their height in the order in which they are added and, when exceeding the height of the device's screen, automatically becomes scrollable;
- [**StackLayout**](https://developer.xamarin.com/api/type/Xamarin.Forms.StackLayout/) is the most widely used layout because it provides two kinds of orientations for the elements held:
  - vertical: aligning the elements from the upper side of the screen to the lower side, in the exact order in which they are added to the layout. 
  - horizontal: the elements are being aligned from left to right, also in the same order in which they are added.

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
- the **action StackLayout** will hold elements that will perform an action on the data.


### Multiple layouts
Note that it is not necessary to have only one layout in a page - remember, a page is not a layout. Therefore, you can add as many layouts as you need and of as many types as you want. For example, here we have a StackLayout that contains one other StackLayout and a TemplatedView. The white StackLayout holds yet another 3 StackLayouts. If this was too hard to grasp, you can take a look at the code below and connect what every bit of it does with the output image.
```
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:App1"
             x:Class="App1.MainPage">

    <StackLayout BackgroundColor="Blue"
                 HeightRequest="450">
        <Label Text="Welcome to Xamarin.Forms!"
               HorizontalOptions="Center"
               VerticalOptions="StartAndExpand"
               TextColor="White" />
        <StackLayout BackgroundColor="White"
                     HeightRequest="350"
                     TranslationY="-10"
                     Orientation="Horizontal"
                     Spacing="5">
            <StackLayout BackgroundColor="Green"
                         WidthRequest="50" />
            <StackLayout BackgroundColor="Red"
                         WidthRequest="50" />
            <StackLayout BackgroundColor="Tomato"
                         WidthRequest="50" 
                         Opacity="0.5" />
        </StackLayout>
        <TemplatedView BackgroundColor="Yellow"
                       HeightRequest="200"/>
    </StackLayout>
</ContentPage>
```
<p align="center"><img height="300" alt="Crazy layouts" src="https://github.com/microsoft-dx/xamarin-fundamentals-ui/blob/master/Images/multiple-layouts.png?raw=true" margin=auto></p>

## Application's pages
A mobile application can have one or more [pages](https://developer.xamarin.com/guides/xamarin-forms/user-interface/controls/pages/) - these depend on the complexity of the application but also on the desired user experience. Considering this, pages can be of multiple types, among which worth mentioning are:
- [Content pages](https://developer.xamarin.com/api/type/Xamarin.Forms.ContentPage/) - basic content-like page which allows elements to be oriented by the user.
- [Navigation pages](https://developer.xamarin.com/api/type/Xamarin.Forms.NavigationPage/) which allow each device's native workflow (sliding on Windows Phone and Android or buttons navigation on iOS - see WhatsApp for example).

What is worth noting is that, contrary to the order in which Layouts and Pages have been introduced here, as can be seen from the code describing the application's structure, Pages are what come first and Layouts are what goes inside of them.


## Navigation through pages
To create the navigation between the pages, first of all the pages _need to be added to the project_.
As the App page and the MainPage are already present, to add elements to the MainPage we only need to edit the XAML file MainPage.xaml and add elements to it, such as the two StackLayouts added in the current solution.
Further, to add a new page, we have to right-click on the Portable solution of the project and add a new ContentPage to the solution:
<p align="center"><img height="500" alt="New page" src="https://github.com/microsoft-dx/xamarin-fundamentals-ui/blob/master/Images/new-page.png?raw=true" margin=auto></p>

As a shopping list application needs to allow adding a new item to the shopping list, the cleanest way of doing that action is to have another page for the data input of the new item being added to the shopping list.
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
