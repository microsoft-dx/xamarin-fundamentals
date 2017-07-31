## Application's layouts
[Layouts](https://developer.xamarin.com/guides/xamarin-forms/user-interface/controls/layouts/) are the very first level of an application's UI, being the base on which elements are being added - a container which holds all the elements and orders them.
Depending on the application needed to be created, one or more layouts are being added to the [xaml](https://msdn.microsoft.com/en-us/library/cc295302.aspx) file. 
From all the available layouts, more often used are:
- the [Grid](https://developer.xamarin.com/api/type/Xamarin.Forms.Grid/) which allows the developer to create rows and columns in the current view and add elements in them and therefore create a table-like view.
- the [ScrollView](https://developer.xamarin.com/api/type/Xamarin.Forms.ScrollView/) which provides a scrollable view by arranging the elements to their height in the order in which they are added and when exceeding the heights of the device's screen it automatically becomes scrollable;
- especially important is the [**Stacklayout**](https://developer.xamarin.com/api/type/Xamarin.Forms.StackLayout/) because it provides two kind of orientation of the held elements:
  - vertical: aligning the elements from the upper side of the screen to the lower side, in the exact order they are added in the layout. 
  - horizontal: in which the elements are being aligned from left to right also in the same order from the layout.

## Application's pages
A mobile application can have one or more [pages](https://developer.xamarin.com/guides/xamarin-forms/user-interface/controls/pages/) - these depend on the complexity of the application but also on the desired user experience. Considering this, pages can be of multiple types, among which worth mentioning:
- [Content pages](https://developer.xamarin.com/api/type/Xamarin.Forms.ContentPage/) - basic content-like page which allows elements to be oriented by the suer.
- [Navigation pages](https://developer.xamarin.com/api/type/Xamarin.Forms.NavigationPage/) which allow each device's native workflow (sliding on Windows Phone and Android or buttons navigation on iOS - see Whatsapp, for example).


### Multiple layouts
Note that it is not necessary to have only one layout in a page - remember, a page is not a layout. Therefore, you can add as many layouts as you need and of as many types as you want. For example, here we have a StackLayout that contains one other StackLayout (which also hold 3 other StackLayouts) and another TemplateView.
<p align="center"><img height="300" alt="Crazy layouts" src="https://github.com/microsoft-dx/xamarin-fundamentals-ui/blob/master/Images/layouts.png?raw=true" margin=auto></p>


## Navigation through pages
To create the navigation between the pages, first of all the pages _need to be added in the project_.
As the App page and the MainPage are already added in the project, to add elements to the MainPage we only need to edit the xaml file MainPage.xaml and add elements to it, such as the two StackLayouts added in the current solution.
Further, to add a new page we have to right-click on the Portable solution of the project and add a new ContentPage to the solution:
<p align="center"><img height="500" alt="New page" src="https://github.com/microsoft-dx/xamarin-fundamentals-ui/blob/master/Images/new-page.png?raw=true" margin=auto></p>
