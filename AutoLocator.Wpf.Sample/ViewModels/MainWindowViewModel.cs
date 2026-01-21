using CommunityToolkit.Mvvm.ComponentModel;

namespace AutoLocator.Wpf.Sample.ViewModels
{
    internal partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        public string _title = "lok";
    }
}
