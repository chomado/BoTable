using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using BoTable.Services;

namespace BoTable.ViewModels
{
    public class WaitingPageViewModel : BindableBase
    {

        public WaitingPageViewModel(INavigationService navigationService, Registration registration)
        {
            this.registration = registration;
        }

        private Registration registration;

        private int number;
        public int Number 
        {
            get { return this.number; }
            set { SetProperty(ref this.number, value); }
        }

        // ライフサイクル

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public async void ShowWaitingPartyNumber()
        {
            var number = await this.registration.GetWaitingPartyNumber(id: "dummy");
            Number = number;
        }

    }
}
