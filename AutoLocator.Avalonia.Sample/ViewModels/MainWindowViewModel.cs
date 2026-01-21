using CommunityToolkit.Mvvm.ComponentModel;

namespace AutoLocator.Avalonia.Sample.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private string _title = "Lok";
}