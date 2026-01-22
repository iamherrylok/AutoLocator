# AutoLocator

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4)](https://dotnet.microsoft.com/)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

AutoLocator is a lightweight ViewModel auto-location and dependency injection framework for WPF and Avalonia platforms. The ViewModelLocator implementation in this project is **inspired by [Prism](https://github.com/PrismLibrary/Prism) framework's ViewModelLocator**, simplified and independently packaged to be used in non-Prism projects.

## ✨ Features

- 🎯 **Auto ViewModel Binding** - Automatically associates Views with ViewModels based on naming conventions
- 💉 **Dependency Injection Support** - Built-in IoC container abstraction layer with DryIoc support
- 🖥️ **Multi-Platform Support** - Supports both WPF and Avalonia
- 🔌 **Extensible** - Supports custom ViewModel factories and container implementations
- 📦 **Lightweight** - Minimal dependencies, easy to integrate

## 📁 Project Structure

```
AutoLocator/
├── AutoLocator/                    # Core library - Container abstraction and DI
│   ├── Containers/                 # Container implementations
│   │   ├── DryIocContainer.cs      # DryIoc container adapter
│   │   └── ContainerType.cs        # Container type enum
│   ├── Interfaces/                 # Interface definitions
│   │   ├── IContainerBase.cs       # Container base interface
│   │   ├── IContainerRegistry.cs   # Service registration interface
│   │   ├── IContainerProvider.cs   # Service resolution interface
│   │   └── IContainerRegistryExtensions.cs  # Generic extension methods
│   └── ContainerProvider.cs        # Static container provider
│
├── AutoLocator.Wpf/                # WPF platform support
│   ├── ViewModelLocator.cs         # WPF ViewModel locator
│   └── ViewModelLocationProvider.cs # ViewModel location provider
│
├── AutoLocator.Avalonia/           # Avalonia platform support
│   ├── ViewModelLocator.cs         # Avalonia ViewModel locator
│   └── ViewModelLocatorProvider.cs # ViewModel location provider
│
├── AutoLocator.Wpf.Sample/         # WPF sample project
└── AutoLocator.Avalonia.Sample/    # Avalonia sample project
```

## 🚀 Quick Start

### Installation

Add `AutoLocator` and the corresponding platform library to your project.

### WPF Usage Example

#### 1. Initialize Container

```csharp
// App.xaml.cs
public partial class App : Application
{
    public App()
    {
        // Initialize DryIoc container
        ContainerProvider.Initialize(ContainerType.DryIoc);

        // Set ViewModel factory to use container resolution
        ViewModelLocationProvider.Initialize(ContainerProvider.Current.Resolve);

        // Register services
        RegisterTypes(ContainerProvider.Current);
    }

    private void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.Register<AccountService>();
        // Register more services...
    }
}
```

#### 2. Enable Auto Binding in View

```xml
<Window x:Class="YourApp.Views.MainWindow"
        xmlns:locator="clr-namespace:AutoLocator.Wpf;assembly=AutoLocator.Wpf"
        locator:ViewModelLocator.AutoWireViewModel="True">
    <Grid>
        <TextBlock Text="{Binding Title}" />
    </Grid>
</Window>
```

#### 3. Create ViewModel

```csharp
// ViewModels/MainWindowViewModel.cs
public class MainWindowViewModel : ObservableObject
{
    private readonly AccountService _accountService;

    public MainWindowViewModel(AccountService accountService)
    {
        _accountService = accountService;
    }

    public string Title => "Hello AutoLocator!";
}
```

### Avalonia Usage Example

```xml
<Window x:Class="YourApp.Views.MainWindow"
        xmlns:AutoLocator="clr-namespace:AutoLocator.Avalonia;assembly=AutoLocator.Avalonia"
        AutoLocator:ViewModelLocator.AutoWireViewModel="True">
    <Grid>
        <TextBlock Text="{Binding Title}" />
    </Grid>
</Window>
```

## 📋 Naming Conventions

ViewModelLocator uses the following naming conventions to automatically match Views and ViewModels:

| View                         | ViewModel                                  |
| ---------------------------- | ------------------------------------------ |
| `YourApp.Views.MainWindow`   | `YourApp.ViewModels.MainWindowViewModel`   |
| `YourApp.Views.MainView`     | `YourApp.ViewModels.MainViewModel`         |
| `YourApp.Views.UserControl1` | `YourApp.ViewModels.UserControl1ViewModel` |

Rules:

- Replace `.Views.` with `.ViewModels.` in the namespace
- If the class name ends with `View`, append `Model` suffix
- Otherwise append `ViewModel` suffix

## 💉 Dependency Injection API

### Service Registration

```csharp
// Register transient services
containerRegistry.Register<IService, ServiceImpl>();
containerRegistry.Register<MyService>();

// Register singleton services
containerRegistry.RegisterSingleton<IService, ServiceImpl>();
containerRegistry.RegisterSingleton<MySingletonService>();

// Register scoped services
containerRegistry.RegisterScoped<IScopedService, ScopedServiceImpl>();

// Register instances
containerRegistry.RegisterInstance<IConfig>(new Config());

// Register with factory methods
containerRegistry.Register<IService>(() => new ServiceImpl());
containerRegistry.RegisterSingleton<IService>(provider =>
    new ServiceImpl(provider.Resolve<IDependency>()));
```

### Service Resolution

```csharp
var service = ContainerProvider.Current.Resolve<IService>();
var namedService = ContainerProvider.Current.Resolve<IService>("serviceName");
```

## 🙏 Acknowledgements

The ViewModelLocator implementation in this project is inspired by [Prism Library](https://github.com/PrismLibrary/Prism). Prism is a powerful MVVM framework that provides comprehensive support for building loosely coupled, maintainable, and testable XAML applications.

AutoLocator extracts and simplifies the ViewModelLocator concept from Prism, allowing developers to use this powerful feature without depending on the full Prism framework.

## 📄 License

This project is open-sourced under the MIT License.

## 🤝 Contributing

Issues and Pull Requests are welcome!
