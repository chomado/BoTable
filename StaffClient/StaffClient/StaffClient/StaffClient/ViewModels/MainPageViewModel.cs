using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using StaffClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StaffClient.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        public DelegateCommand<string> NavigateCommand { get; }

        public MainPageViewModel(INavigationService navigationService)
        {
            this.NavigateCommand = new DelegateCommand<string>(async x => await navigationService.NavigateAsync(x));
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }
    }
}
