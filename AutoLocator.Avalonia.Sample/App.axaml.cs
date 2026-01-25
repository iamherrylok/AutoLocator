using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AutoLocator.Avalonia.Sample.Views;
using AutoLocator.Containers;

namespace AutoLocator.Avalonia.Sample;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);

        ContainerProvider.Initialize(ContainerType.DryIoc);
        ViewModelLocationProvider.Initialize(ContainerProvider.Current.Resolve);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow();
        }

        base.OnFrameworkInitializationCompleted();
    }
}