# AutoLocator

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4)](https://dotnet.microsoft.com/)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

AutoLocator 是一个轻量级的 ViewModel 自动定位和依赖注入框架，支持 WPF 和 Avalonia 平台。本项目的 ViewModelLocator 实现方式**源自于 [Prism](https://github.com/PrismLibrary/Prism) 框架中的 ViewModelLocator**，并在此基础上进行了简化和独立封装，使其可以在非 Prism 项目中独立使用。

## ✨ 特性

- 🎯 **自动 ViewModel 绑定** - 基于命名约定自动将 View 与 ViewModel 关联
- 💉 **依赖注入支持** - 内置 IoC 容器抽象层，支持 DryIoc
- 🖥️ **多平台支持** - 同时支持 WPF 和 Avalonia
- 🔌 **可扩展** - 支持自定义 ViewModel 工厂和容器实现
- 📦 **轻量级** - 最小化依赖，易于集成

## 📁 项目结构

```
AutoLocator/
├── AutoLocator/                    # 核心库 - 容器抽象和依赖注入
│   ├── Containers/                 # 容器实现
│   │   ├── DryIocContainer.cs      # DryIoc 容器适配器
│   │   └── ContainerType.cs        # 容器类型枚举
│   ├── Interfaces/                 # 接口定义
│   │   ├── IContainerBase.cs       # 容器基础接口
│   │   ├── IContainerRegistry.cs   # 服务注册接口
│   │   ├── IContainerProvider.cs   # 服务解析接口
│   │   └── IContainerRegistryExtensions.cs  # 泛型扩展方法
│   └── ContainerProvider.cs        # 静态容器提供者
│
├── AutoLocator.Wpf/                # WPF 平台支持
│   ├── ViewModelLocator.cs         # WPF ViewModel 定位器
│   └── ViewModelLocationProvider.cs # ViewModel 定位提供者
│
├── AutoLocator.Avalonia/           # Avalonia 平台支持
│   ├── ViewModelLocator.cs         # Avalonia ViewModel 定位器
│   └── ViewModelLocatorProvider.cs # ViewModel 定位提供者
│
├── AutoLocator.Wpf.Sample/         # WPF 示例项目
└── AutoLocator.Avalonia.Sample/    # Avalonia 示例项目
```

## 🚀 快速开始

### 安装

将 `AutoLocator` 和对应平台的库添加到你的项目中。

### WPF 使用示例

#### 1. 初始化容器

```csharp
// App.xaml.cs
public partial class App : Application
{
    public App()
    {
        // 初始化 DryIoc 容器
        ContainerProvider.Initialize(ContainerType.DryIoc);

        // 设置 ViewModel 工厂使用容器解析
        ViewModelLocationProvider.Initialize(ContainerProvider.Current.Resolve);

        // 注册服务
        RegisterTypes(ContainerProvider.Current);
    }

    private void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.Register<AccountService>();
        // 注册更多服务...
    }
}
```

#### 2. 在 View 中启用自动绑定

```xml
<Window x:Class="YourApp.Views.MainWindow"
        xmlns:locator="clr-namespace:AutoLocator.Wpf;assembly=AutoLocator.Wpf"
        locator:ViewModelLocator.AutoWireViewModel="True">
    <Grid>
        <TextBlock Text="{Binding Title}" />
    </Grid>
</Window>
```

#### 3. 创建 ViewModel

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

### Avalonia 使用示例

```xml
<Window x:Class="YourApp.Views.MainWindow"
        xmlns:AutoLocator="clr-namespace:AutoLocator.Avalonia;assembly=AutoLocator.Avalonia"
        AutoLocator:ViewModelLocator.AutoWireViewModel="True">
    <Grid>
        <TextBlock Text="{Binding Title}" />
    </Grid>
</Window>
```

## 📋 命名约定

ViewModelLocator 使用以下命名约定自动匹配 View 和 ViewModel：

| View                         | ViewModel                                  |
| ---------------------------- | ------------------------------------------ |
| `YourApp.Views.MainWindow`   | `YourApp.ViewModels.MainWindowViewModel`   |
| `YourApp.Views.MainView`     | `YourApp.ViewModels.MainViewModel`         |
| `YourApp.Views.UserControl1` | `YourApp.ViewModels.UserControl1ViewModel` |

规则说明：

- 将命名空间中的 `.Views.` 替换为 `.ViewModels.`
- 如果类名以 `View` 结尾，则添加 `Model` 后缀
- 否则添加 `ViewModel` 后缀

## 💉 依赖注入 API

### 服务注册

```csharp
// 注册瞬态服务
containerRegistry.Register<IService, ServiceImpl>();
containerRegistry.Register<MyService>();

// 注册单例服务
containerRegistry.RegisterSingleton<IService, ServiceImpl>();
containerRegistry.RegisterSingleton<MySingletonService>();

// 注册作用域服务
containerRegistry.RegisterScoped<IScopedService, ScopedServiceImpl>();

// 注册实例
containerRegistry.RegisterInstance<IConfig>(new Config());

// 使用工厂方法注册
containerRegistry.Register<IService>(() => new ServiceImpl());
containerRegistry.RegisterSingleton<IService>(provider =>
    new ServiceImpl(provider.Resolve<IDependency>()));
```

### 服务解析

```csharp
var service = ContainerProvider.Current.Resolve<IService>();
var namedService = ContainerProvider.Current.Resolve<IService>("serviceName");
```

## 🙏 致谢

本项目的 ViewModelLocator 实现方式源自于 [Prism Library](https://github.com/PrismLibrary/Prism)。Prism 是一个功能强大的 MVVM 框架，为构建松耦合、可维护和可测试的 XAML 应用程序提供了全面的支持。

AutoLocator 提取并简化了 Prism 中的 ViewModelLocator 概念，使开发者可以在不依赖完整 Prism 框架的情况下使用这一强大的功能。

## 📄 许可证

本项目基于 MIT 许可证开源。

## 🤝 贡献

欢迎提交 Issue 和 Pull Request！
