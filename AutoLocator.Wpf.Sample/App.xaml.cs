using AutoLocator.Containers;
using AutoLocator.Interfaces;
using AutoLocator.Wpf.Sample.Services;
using System.Windows;

namespace AutoLocator.Wpf.Sample
{
    public partial class App : Application
    {
        public App()
        {
            ContainerProvider.Initialize(ContainerType.DryIoc);
            ViewModelLocationProvider.Initialize(ContainerProvider.Current.Resolve);

            RegisterTypes(ContainerProvider.Current);
        }

        private void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<AccountService>();
        }
    }
}
