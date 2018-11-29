
##  Module 3: NetStandard in Xamarin

  

In this module we are going to learn how we can make use of the [.NET Standard](https://docs.microsoft.com/en-us/dotnet/articles/standard/library) in [Xamarin.Forms](https://www.xamarin.com/forms) applications. If you don't know what the .NET Standard is you can check out [this article](https://blogs.msdn.microsoft.com/dotnet/2016/09/26/introducing-net-standard/) which details what the .NET Standard is and wants to be and more into the compatibility part with Windows applications, .NET Core and Xamarin. If you know what the .NET Standard is but still haven't wrapped your head around it, you can check David Fowler's [explanation](https://gist.github.com/davidfowl/8939f305567e1755412d6dc0b8baf1b7).

  

As you can see from the image below, the current state of .NET has a base class library for each framework on which the Microsoft tools expand.

  

- The .NET Framework is the framework of choice in the context of Windows-only application development with tons of plugins and extensions as well as a full featured documentation

- .NET Core is the framework of choice in the context of cross platform desktop application development, targeting Windows, Linux and macOS development

- Xamarin is the framework of choice in the context of cross platform mobile application development, targeting the Universal Windows Platform, Android and iOS.

  

![netstandard_today](https://github.com/microsoft-dx/xamarin-fundamentals-ui/blob/master/Images/dotnet-today.png?raw=true)

  

[Image source](https://msdnshared.blob.core.windows.net/media/2016/09/dotnet-today.png)

  

Today, if you want your application or your business to target all these platforms, you will have to duplicate the custom code you write that initialises plugins or external libraries. While most of the common plugins or libraries are available on multiple framework, they still have to maintained separately and their code duplicated with the possibility of a bug to occur on one or multiple platforms, so we are back at square one.

  

![netstandard_tomorrow](https://github.com/microsoft-dx/xamarin-fundamentals-ui/blob/master/Images/dotnet-tomorrow.png?raw=true)

  

[Image source](https://msdnshared.blob.core.windows.net/media/2016/09/dotnet-tomorrow.png)

  

Tomorrow (we are going to do this today though :stuck_out_tongue: ), if you want your application or your business to target all these platforms, all you have to do is target your project/library/plugin/nuget to .NETStandard. This may seem complicated, but we will see in the following chapters how we can do this with the Xamarin platform.

  

###  PCL project

  

We will need to convert our PCL project to a .NET Standard project. To do that we right click on the portable project (in our case *MobileDemo*) and we will modify it's settings.

  

Before we migrate our project, we need to remove all NuGet packages that depend on the PCL standard. To do that easy, we will delete the **packages.config** file shown in the Solution Explorer, as displayed below.

  

![delete-packages-config](https://github.com/microsoft-dx/xamarin-fundamentals-ui/blob/master/Images/delete-packages-config.png?raw=true)

  

We will then click "**Target .NET Platform Standard**" and it should start porting it in a couple of seconds. The latest supported .NET Standard by **Xamarin.Forms 2.3.4.247** is **netstandard1.4**, so we will select .NET Standard 1.4 from the drop-down list as displayed below.

  

![target-netstandard](https://github.com/microsoft-dx/xamarin-fundamentals-ui/blob/master/Images/target-netstandard.png?raw=true)

  

After all the above setup is done, the [soon to be dead](https://xamarinhelp.com/visual-studio-2017-net-standard-xamarin/) **project.json** will be created and will look something like this:

  

The migration added the latest .NET Standard Library and the latest NETCore Compatibility layer (we don't necessarily need it for this example, but if you have a NuGet that hasn't been updated to .NET Core or .NET Standard, but does have PCLs inside it, this package solves the compatibility issues) that we will remove.

  

We now need to add the Xamarin.Forms NuGet package, and now comes the tricky part. As of Xamarin.Forms 2.3.4.247, the NuGet packages isn't .NET Standard compatible out-of-the-box, so we need to import the necessary [PCL profiles](https://docs.microsoft.com/en-us/nuget/schema/target-frameworks) in order to work and we will modify the project.json file to look something like this:

  

```

{

"supports": {},

"dependencies": {

"NETStandard.Library": "1.6.1",

"Xamarin.Forms": "2.3.4.247"

},

"frameworks": {

"netstandard1.4": {

"imports": "portable-monoandroid10+net45+win+win81+wp8+wpa81+xamarinios10+xamarinmac20"

}

}

}

```

  

We will then remove the references from the portable project that we no longer need (they are not automatically removed as of Visual Studio 2017 Community):

* **Xamarin.Forms.Core**

* **Xamarin.Form.Platform**

* **Xamarin.Forms.Xaml**

  

also delete everything that references the **packages** folder. Some of the code include:

```

<Import Project="..\packages\Xamarin.Forms.2.3.4.247\build\..." ... />

<Target Name="EnsureNuGetPackageBuildImports" ... > ... </Target>

```

  

We will now need to delete the **packages.config** files from the Android and iOS projects and replace them with **project.json**. Also, the references will not be removed automatically, so we need to remove them manually, as described below. We will also unload the csproj files and remove everything that references the **packages** folder, as seen above.

  

###  Android project

  

We will remove everything in the list below, the from the References.

* **FormsViewGroup**

* **System.ObjectModel**

* **Xamarin.Forms.Core**

* **Xamarin.Forms.Platform**

* **Xamarin.Forms.Platform.Android**

* **Xamarin.Forms.Xaml**

* **Xamarin.Android.Support**

* **Animated.Vector.Drawable**

* **Xamarin.Android.Support.Design**

* **Xamarin.Android.Support.v4**

* **Xamarin.Android.Support.v7.AppCompat**

* **Xamarin.Android.Support.v7.CardView**

* **Xamarin.Android.Support.v7.MediaRouter**

* **Xamarin.Android.Support.v7.RecyclerView**

* **Xamarin.Android.Support.Vector.Drawable**

  

The Android **project.json** will look like this (Android API 25):

  

```

{

"dependencies": {

"Xamarin.Android.Support.Animated.Vector.Drawable": "25.3.1",

"Xamarin.Android.Support.Design": "25.3.1",

"Xamarin.Android.Support.v4": "25.3.1",

"Xamarin.Android.Support.v7.AppCompat": "25.3.1",

"Xamarin.Android.Support.v7.CardView": "25.3.1",

"Xamarin.Android.Support.v7.MediaRouter": "25.3.1",

"Xamarin.Android.Support.v7.RecyclerView": "25.3.1",

"Xamarin.Android.Support.Vector.Drawable": "25.3.1",

"Xamarin.Forms": "2.3.4.247"

},

"frameworks": {

"MonoAndroid,Version=v7.1": {}

},

"runtimes": {

"win": {}

}

}

```

  

###  iOS project

  

We will remove everything in the list below, the from the References.

* **Xamarin.Forms.Core**

* **Xamarin.Forms.Platform**

* **Xamarin.Forms.Platform.iOS**

* **Xamarin.Forms.Xaml**

  

The iOS **project.json** will look like this:

  

```

{

"dependencies": {

"Xamarin.Forms": "2.3.4.247"

},

"frameworks": {

"Xamarin.iOS,Version=v1.0": {}

},

"runtimes": {

"win": {}

}

}

```

  

We will then need to unload the iOS csproj to add the **AutoGenerateBindingRedirects** tag in order to get rid of the warning (there is an issue with System.Runtime :unamused:). So we will add the following line into the iOS csproj for each configuration (*Debug*, *Debug|iPhoneSimulator* etc.):

  

```

<AutoGenerateBindingRedirects>true</AutoGenerateBindingRedirects>

```

  

###  UWP project

  

In the UWP project we only need to update the **Microsoft.NETCore.UniversalWindowsPlatform** NuGet to the latest .NET Standard supported version that is **5.3.4**. The UWP **project.json** will look like this:

  

```

{

"dependencies": {

"Microsoft.NETCore.UniversalWindowsPlatform": "5.3.4",

"Xamarin.Forms": "2.3.4.247"

},

"frameworks": {

"uap10.0": {}

},

"runtimes": {

"win10-arm": {},

"win10-arm-aot": {},

"win10-x86": {},

"win10-x86-aot": {},

"win10-x64": {},

"win10-x64-aot": {}

}

}

```

  

###  In conclusion

  

So there we have it, a fully working, up-to-date Xamarin.Forms project with .NET Standard :sunglasses: