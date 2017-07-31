## Application's layout
[Layouts](https://developer.xamarin.com/guides/xamarin-forms/user-interface/controls/layouts/) are the very first level of an application's UI, being the base on which elements are being added - a container which holds all the elements and orders them.
Depending on the application needed to be created, one or more layouts are being added to the [xaml](https://msdn.microsoft.com/en-us/library/cc295302.aspx) file. 
From all the available layouts, more often used are:
- the [Grid](https://developer.xamarin.com/api/type/Xamarin.Forms.Grid/) which allows the developer to create rows and columns in the current view and add elements in them and therefore create a table-like view.
- the [ScrollView](https://developer.xamarin.com/api/type/Xamarin.Forms.ScrollView/) which provides a scrollable view by arranging the elements to their height in the order in which they are added and when exceeding the heights of the device's screen it automatically becomes scrollable;
- especially important is the [**Stacklayout**](https://developer.xamarin.com/api/type/Xamarin.Forms.StackLayout/) because it provides two kind of orientation of the held elements:
  - vertical: aligning the elements from the upper side of the screen to the lower side, in the exact order they are added in the layout. 
  - horizontal: in which the elements are being aligned from left to right also in the same order from the layout.
