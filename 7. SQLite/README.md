
## Module 7: SQLite

### What is SQLite
> SQLite is an embedded SQL database engine. Unlike most other SQL databases, SQLite does not have a separate server process. SQLite reads and writes directly to ordinary disk files. A complete SQL database with multiple tables, indices, triggers, and views, is contained in a single disk file. The database file format is cross-platform - you can freely copy a database between 32-bit and 64-bit systems or between big-endian and little-endian architectures. These features make SQLite a popular choice as an Application File Format. Think of SQLite not as a replacement for Oracle but as a replacement for fopen().

[More info on the official website](https://www.sqlite.org/about.html)

We will use [this nuget package](https://www.nuget.org/packages/sqlite-net-pcl) which has support for .NETStandard (which was published two weeks ago :sweat_smile:). We can use a library that is **not* targeting the .NETStandard because in the previous modules we imported the profiles so that we can use nugets/plugins like this one.

### NuGet installation
![manage-nugets](https://github.com/microsoft-dx/xamarin-fundamentals-ui/blob/master/Images/manage-nugets.png?raw=true)

We right click on the solution (not a project) and then click on `Manage NuGet Packages for Solution...` after which a modal appears and then we click on the `Browse` tab to search for our SQLite nuget to install. We search for `sqlite-net-pcl` and then we check all projects because we need the library in each project in order to function correctly. The reason for this is that there are multiple targets for the assembly, one for each of the platform we want to target. The code is the same but it gets compiled differently, depending on the platform it builds for. After that, we hit install and accept any changes that this NuGet installation will do to our solution.

![sqlite-net-pcl](https://github.com/microsoft-dx/xamarin-fundamentals-ui/blob/master/Images/sqlite-net-pcl.png?raw=true)

As we saw in the SQLite definition, instead of a instance of a database server it makes use of the current file system. You probably heard about NTFS or FAT32 if you come from a Windows environment, Ext4 if you come from a Linux environment of HFS if you come from a macOS environment and as you probably guessed, different names mean different implementation :joy: .

The .NETStandard ***should*** fix this issue but currently doesn't, so custom code has to be written in order to communicate and access each platform file system and access the database. The purpose of this module is not to implement custom FileIO in Xamarin.Forms with .NETStandard so we will use a [nuget](https://www.nuget.org/packages/Plugin.NetStandardStorage) which [one of our MSPs](https://github.com/laurentiustamate94) built to simplify file system access.

![netstandard-storage](https://github.com/microsoft-dx/xamarin-fundamentals-ui/blob/master/Images/netstandard-storage.png?raw=true)

The installation process is the same, right click on the solution, click on `Manage NuGet Packages for Solution...` after which a modal appears and then we click on the `Browse` tab to search for our plugin to install. We search for `Plugin.NetStandardStorage` and then we check all projects.

We can now start building the Database Access Layer :bow_tie:

### Database Access Layer
We talked in the previous modules that .NETStandard resolves the problem of duplicating code depending on the platform you target and as an example we used a Database Access Layer (will use DAL), so why not stand by our word and implement the DAL targeting the .NETStandard? We will add a new library project by `right clicking the solution` > `Add` > `New project...`, as seen below

![netstandard-class-library](https://github.com/microsoft-dx/xamarin-fundamentals-ui/blob/master/Images/netstandard-class-library.png?raw=true)

We will name the project `MobileDemo.DataAccess` to maintain the consistency of the other projects. We will then reference this project only in the Portable project, because it automatically includes it in the platform specific projects. To do this, we right click on the `References` item from the Solution Explorer in the Portable project > `Add Reference...` and we select the project we already created, as seen below.

![add-reference](https://github.com/microsoft-dx/xamarin-fundamentals-ui/blob/master/Images/add-reference.png?raw=true)

After we have everything set-up, we can start and implement our custom functionality.

#### Entities
An entity is the abstraction of data that comes from a database context in a certain form. We will create a `ShoppingItem` class which will act as an entity which we will use when fetching or updating data from the database. In our case, the database is using a Code-First approach, meaning that we first create our abstraction in the code and after that we push it to create the database tables with specific tables and other configuration settings. To maintain consistency, we will create a folder called `Entities` in the .NETStandard project and put our `ShoppingItem` class inside it:

```cs
public class ShoppingItem
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Name { get; set; }

    public override string ToString()
    {
        return this.Name;
    }

    public override bool Equals(object obj)
    {
        var item = obj as ShoppingItem;

        return item.Name == this.Name;
    }
}
```

We make the Id a `primary key` which tells the database that this information cannot be duplicated, so it cannot exist multiple records with the same `Id` (we need this in order to identify a unique record in the UI, as we seen in the previous modules). We also set the `auto increment` attribute on the `Id` property which increments each record when we insert a new one. It is also a good practice to override the `ToString` and `Equals` method for future use of our model to avoid runtime errors that may take a while to fix.

#### Database class
As of personal choice, the `Database` class is [partial](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/partial-classes-and-methods#partial-classes) because I want to have all the necessary methods in the same class. This class makes use of the [Singleton pattern](https://en.wikipedia.org/wiki/Singleton_pattern) because we want to use the database context as a service and do not want multiple instances of the same service, just multiple connections to the database server. Let's review the main class.

```cs
public partial class Database
{
    #region Singleton

    private static Database _instance = null;

    public static Database Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Database();
            }

            return _instance;
        }
    }

    private Database()
    {

    }

    #endregion

    private string DatabasePath = null;

    private void CreateTables()
    {
        using (var dbContext = Database.Instance.GetConnection())
        {
            dbContext.CreateTable<ShoppingItem>();
        }
    }

    public void InitializeDatabase()
    {
        var task = Task.Run(() =>
        {
            var db = CrossStorage.FileSystem.LocalStorage.CreateFile(
                "xamarin-fundamentals.db",
                CreationCollisionOption.OpenIfExists);

            return db.FullPath;
        });

        task.Wait();

        this.DatabasePath = task.Result;


        this.CreateTables();
    }

    public SQLiteConnection GetConnection()
    {
        return new SQLiteConnection(this.DatabasePath);
    }
}
```

The `InitializeDatabase` method will be called every time the application launches and will initialize the context of the database. If the application is launched for the very first time, the database file, in our case `xamarin-fundamentals.db`, will be created on the file system and for future launches, it will only be opened for read. This functionality is built in the NetStandardStorage nuget and provides further more manipulation of the file system but this is not the topic of this module. 

The connection to the database is exposed through the `SQLiteConnection` which requires a valid absolute path to the database file in the file system. For this, when the database file is created, we store the information in the private `DatabasePath` property and expose the `SQLiteConnection` instance through the `GetConnection` method.

You may have noticed that we run on a separate thread using `Task.Run` and the reason for this is not to block the main thread (sometimes an exception will be thrown if it detects IO interaction on the main thread).

We can now start to implement CRUD (Create, Read, Update, Delete) functionality for our shopping list table.

```cs
public partial class Database
{
    public void AddItem(string name)
    {
        using (var dbContext = Database.Instance.GetConnection())
        {
            dbContext.Insert(new ShoppingItem
            {
                Name = name
            });
        }
    }

    public void DeleteItemById(int id)
    {
        using (var dbContext = Database.Instance.GetConnection())
        {
            var existingItems = dbContext.Query<ShoppingItem>($"SELECT * FROM ShoppingItem WHERE Id = {id}");

            if (existingItems.Any())
            {
                var toDelete = existingItems
                    .Where(x => x.Id == id)
                    .FirstOrDefault();

                if (toDelete != null)
                {
                    dbContext.Delete(toDelete);
                }
            }
        }
    }

    public IEnumerable<ShoppingItem> LoadItems()
    {
        using (var dbContext = Database.Instance.GetConnection())
        {
            return dbContext.Query<ShoppingItem>($"SELECT * FROM ShoppingItem");
        }
    }
}
```
The code here is pretty straight forward:

* we get an active connection to the database
* we query using [SQL language](https://en.wikipedia.org/wiki/SQL) records from the databse
* we execute an insert or delete action, depending on which method is called

For this example I used [string interpolation](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/interpolated-strings) to also showcase some features of C# 7.0.

### Entity to Model mapping

It is not best practice to use entities in the user interface, because you would want custom properties specifically for the UI but not to have them in the database. For example, in the database you have 2 columns - `FirstName` and `LastName` - and on the UI you want to display just one property, `FullName`. Of course, you can concatenate the information in the backend, after you fetch the data from the database or in the UI. But what happens when you multiple this behavior in other pages? Also, what if you want to append `Mr. or Ms.` to the FullName? Disaster.

The best solution is to isolate the mapping in special classes, either in UI or backend but the backend is preferred, in which you set your UI data however you want and pass to the UI exactly what it needs. In our case, this functionality will act as a helper, so we create a folder called `Helpers` and create a `Mappers` class inside.

```cs
public static class Mappers
{
    public static MobileDemo.Models.ShoppingItem ToModel(this MobileDemo.DataAccess.Entities.ShoppingItem data)
    {
        return new Models.ShoppingItem
        {
            ItemId = data.Id,
            ItemName = data.Name
        };
    }
}
```

We use a static class because we want to create [extension methods](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods) to various objects in order to make the code more readable. All this method does is to "cast" an entity to a model we use in the user interface.

### Integration

TODO add content

```cs
Database.Instance.InitializeDatabase();
```

TODO add content

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
        var data = Database.Instance.LoadItems()
            .Select(x => x.ToModel());

        this.ShoppingItems = new ObservableCollection<ShoppingItem>(data);
    }

    private async void contentListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var item = (sender as ListView).SelectedItem as ShoppingItem;

        Database.Instance.DeleteItemById(item.ItemId);

        this.ShoppingItems.RemoveAt(this.ShoppingItems.IndexOf(item));
    }

    private void addNewItem_button_Clicked(object sender, System.EventArgs e)
    {
        Navigation.PushAsync(new NewItem());
    }
}
```

TODO add content

```cs
var alertResult = await DisplayAlert("Delete warning", "Do you really want to delete?", "YES", "NO");

if (!alertResult)
{
    return;
}
```

TODO add content

```cs
public partial class NewItem : ContentPage
{
    public NewItem()
    {
        InitializeComponent();
    }

    private void addNewItem_button_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(amountEntry.Text))
        {
            Database.Instance.AddItem(amountEntry.Text);
        }

        Navigation.PopAsync();
    }
}
```

TODO add content

```cs
protected override void OnAppearing()
{
    InitializeItems();

    contentListView.ItemsSource = ShoppingItems;

    base.OnAppearing();
}
```

We now have a fully working application that persists data and we can now go shopping without ever forgetting what to buy. Let's add some style in the next module :sunglasses: