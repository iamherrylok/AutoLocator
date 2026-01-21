using DryIoc;
using System.Windows;

namespace AutoLocator.Wpf.Sample
{
    public partial class App : Application
    {
        public App()
        {
            var container = new DryIocContainer();

            ContainerProvider.SetContainer(container);

            ViewModelLocationProvider.SetDefaultViewModelFactory(ContainerProvider.Current.Resolve);
        }
    }
}
