# Module 1: Introduction & Setup

## Xamarin
[Xamarin](https://www.xamarin.com/) is a platform based on C# and XAML that allows the user to create **cross-platform applications** using shared-code between each platforms's solution.


### How? 
This is what this module intends to focus on. You can do one single application that works on every device (Windows 10, Android, iOS/macOS [currently in beta :sweat_smile:]) and you can run native applications on all the devices.

## Cross platform applications
A cross-platform application is a mobile application that can be used on multiple operating systems - Android, iOS or UWP - with the same results on each platform, but using the native elements from each platform.
For example, lets have a look at these text entries:
![Code Example](https://github.com/microsoft-dx/xamarin-fundamentals-ui/blob/master/Images/xamarin-entry.png?raw=true)

[Image source](http://ammras.elmapharmamarketing.in/content/images/pages/forms/example-app.png)

As you can notice, these elements have the exact same behaviour and data expected, yet still they are different on each platform and are exactly the same as you have previously seen in other applications' text entries on either one of those platforms.

Xamarin provides the developer with the possibility of creating a cross-platform Visual Studio project that builds the application for each used platform.

### How it works
With Xamarin, development is really all about productivity and time-efficiency, or in other words, cross-platform code:

- As a mobile application shows data, on the back-end part, C# provides the core’s cross-platform code that modelates the data shown in the user interface.
- As the back-end part is created using C# which provides the core’s cross-platform functionality, the UI (User Interface) is created using XAML, which is **a declarative markup language** - meaning that the code is written in the same order as the developers want to use it;
The XML file is used to define the user interface in XAML syntax,  while all  the  runtime  behavior  of  the  UI  elements  is  defined  in  C#

- XAML provides basic UI elements (such as Pages, Layouts and Controls) that are native on each platform, keeping the interface clean and simple.


## Xamarin Forms
Xamarin.Forms is a namespace that works directly on Xamarin is “a natively-backed UI toolkit abstraction” and allows XAML user interface development, which  is  a  better  alternative  than  using  native  Xamarin  interface as it is a mark-up language.

## Setup -- Windows
First we need to go [here](https://www.visualstudio.com/downloads/) and download the installer for visual studio (this course will use Visual Studio Community). Then, after the download has finished, we click on the installer and select a custom install for Visual Studio (you can also change the location)

![Installer](https://github.com/microsoft-dx/xamarin-fundamentals-ui/blob/master/Images/installer.jpg?raw=true)

On the next screen we need to select the Cross Platform Mobile Development section as this is what we will use (Xamarin):

![Installer must have](https://github.com/microsoft-dx/xamarin-fundamentals-ui/blob/master/Images/installer-must-have.jpg?raw=true)

After this we are good to go and the install will begin and the Wait Begins (depending on your internet connection and you SSD/HDD it should take some time. I grabbed a beer, started two benchmark virtual machines and the installer finished in 4.5h on a HDD and 45 minutes on the SSD).

## Setup -- macOS

TODO :sweat_smile:

## First Xamarin Project

1. Open Visual Studio and create a new Project and on the left side select **Visual C#**, and then **Cross-Platform**.

![xamarin forms](https://user-images.githubusercontent.com/23138335/49178094-842c4c00-f357-11e8-88e7-568d6d7b244f.PNG)

2. Select the **Xamarin.Forms Mobile App** and create a **Blank App**. You can now choose which platforms to include in your project (Android, iOS, UWP).

![blank](https://user-images.githubusercontent.com/23138335/49178360-3d8b2180-f358-11e8-8cc7-89675354219f.PNG)



## The project explained

As you can see, the are many subsections as it follows: 

1. My-first-app containing: App.xaml (App.xaml.cs is the fundamental Class for a Xamarin Project) and MainPage.xaml which is the page that gets rendered when the application is fired up
2. My-first-app.Android containing all the files Required for Android's side of the App.
3. My-first-app.iOS containing all the files Required for iOS's side of the App. 
4. My-first-app.UWP, explained in [this blog post](https://laurentiu.microsoft.pub.ro/2016/04/03/hello-universal-windows-platform/)

![image](https://user-images.githubusercontent.com/23138335/49178562-be4a1d80-f358-11e8-86e0-5c3b090319c0.png)


We will set the UWP project as the default executing project and hit F5. We now created our first Xamarin PCL application.

#### Remarks
- as Xamarin development is possible only using a Xamarin-compatible IDE, this project will be created in [Visual Studio](https://www.visualstudio.com/).
- keep in mind that you can also use [Xamarin Studio](https://developer.xamarin.com/guides/cross-platform/xamarin-studio/), but all the modules in this course will have instructions available for Visual Studio only.

## In conclusion

As you may have already observed, there is basicaly no need for C# coding knowledge to create a basic “Hello World” App in the Xamarin Platform, it’s as simple and easy as File => New => Project. For a better understanding of how useful the C# language can be, you can check out [this repository](https://github.com/microsoft-dx/csharp-fundamentals/) full with basic C# projects.

#### Useful links:
[Xamarin for Developers](https://developer.xamarin.com/)

[Video Tutorial for Beginers](https://www.youtube.com/watch?v=6MQXkUfIn9M)
