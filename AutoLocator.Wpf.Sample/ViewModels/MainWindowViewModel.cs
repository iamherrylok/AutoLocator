using AutoLocator.Wpf.Sample.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AutoLocator.Wpf.Sample.ViewModels
{
    internal partial class MainWindowViewModel : ObservableObject
    {
        private readonly AccountService _accountService;

        public MainWindowViewModel(AccountService accountService)
        {
            _accountService = accountService;

            Title = _accountService.Id;
        }

        [ObservableProperty]
        private string? _title;
    }
}
