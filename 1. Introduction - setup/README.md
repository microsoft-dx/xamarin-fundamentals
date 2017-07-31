# Module 1: Introduction & Setup

## Xamarin
[Xamarin](https://www.xamarin.com/) is a platform based on C# and xaml that allows the user to create **cross-platform applications** using shared-code between.


### How? 
This is what this module intends to focus on.

## Cross platform applications
A cross-platform application is a mobile application that can be used on each mobile opperating system - Android, iOS or UWP - having the same results on each platform but by using the native elements from each platform.
For example, lets have a look at these text entries:
![Code Example](https://github.com/microsoft-dx/xamarin-fundamentals-ui/blob/master/Images/xamarin-entry.png?raw=true)

As you can notice, these elements have the exact same behaviour and data expected, yet still they are different on each platform and are exactly the same as you have previously seen in other applications' text entries on either one of those platforms.

Xamarin provides the developer the possibility of creating a cross-platform Visual Studio project that builds the application for each used platform.

### How it works
With Xamarin development it is really all about productivity and time-efficiency or in other words cross-platform code:

- As a mobile application shows data, on the back-end part, C# provides the core’s cross-platform code that modelates the data shown in the user interface.
- As the back-end part is created using C# which provides the core’s cross-platform functionality, the UI (User Interface) is created using XAML, which is **a declarative markup language** - meaning that the code is written in the same order as the developers want to use it;
The XML file is used to define the user interface in XAML syntax,  while all  the  runtime  behavior  of  the  UI  elements  is  defined  in  C#

- XAML provides basic UI elements (such as Pages, Layouts and Controls) that are native on each platform, keeping the interface clean and simple.


## Setup

#### Prerequisites
- as Xamarin development is possible only using an Xamarin-compatible IDE, this project will be created in [Visual Studio](https://www.visualstudio.com/).
    - keep in mind that you can also use [Xamarin Studio](https://developer.xamarin.com/guides/cross-platform/xamarin-studio/) but all the modules will have instructions available for Visual Studio only.

1. Open Visual Studio and create a new Project - a __Cross Platform App (Xamarin)__.
![New project](https://github.com/microsoft-dx/xamarin-fundamentals-ui/blob/master/Images/new-project.PNG?raw=true)
2. 
