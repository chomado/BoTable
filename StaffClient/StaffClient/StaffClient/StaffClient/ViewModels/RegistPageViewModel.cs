using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using StaffClient.BusinessObjects;
using StaffClient.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StaffClient.ViewModels
{
    public class RegistPageViewModel : BindableBase, INavigationAware
    {
        private INavigationService NavigationService { get; }

        private StaffService StaffService { get; }

        public DelegateCommand LoadCommand { get; }

        public DelegateCommand<Party> SelectPartyCommand { get; }

        public ObservableCollection<Party> WaitingList { get; } = new ObservableCollection<Party>();

        public RegistPageViewModel(INavigationService navigationService, StaffService staffService)
        {
            this.NavigationService = navigationService;
            this.StaffService = staffService;

            this.LoadCommand = new DelegateCommand(async () => await this.LoadExecuteAsync());
            this.SelectPartyCommand = new DelegateCommand<Party>(async x => await this.SelectPartyExecuteAsync(x));
        }

        private Task SelectPartyExecuteAsync(Party party)
        {
            return this.NavigationService.NavigateAsync($"SheetsPage?partyId={party.Id}");
        }

        private async Task LoadExecuteAsync()
        {
            try
            {
                var waitingList = await this.StaffService.GetWaitingPartyAsync();
                this.WaitingList.Clear();
                foreach (var item in waitingList)
                {
                    this.WaitingList.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            this.LoadCommand.Execute();
        }
    }
}
