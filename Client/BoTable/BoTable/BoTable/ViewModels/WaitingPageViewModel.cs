using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using BoTable.Services;
using BoTable.Model;

namespace BoTable.ViewModels
{
    public class WaitingPageViewModel : BindableBase
    {
        private PartyInfo partyInfo;

        public PartyInfo PartyInfo
        {
            get { return this.partyInfo; }
            private set { this.SetProperty(ref this.partyInfo, value); }
        }

        private Registration registration;

        public WaitingPageViewModel(INavigationService navigationService, Registration registration, PartyInfo partyInfo)
        {
            this.registration = registration;
            this.PartyInfo = partyInfo;
        }

        // ライフサイクル

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public async void ShowWaitingPartyNumber()
        {
            var number = await this.registration.GetWaitingPartyNumber(id: this.PartyInfo.Id);
            this.PartyInfo.PartyCount = number;
            this.PartyInfo.WaitingMinutes = number * 8;
        }

    }
}
