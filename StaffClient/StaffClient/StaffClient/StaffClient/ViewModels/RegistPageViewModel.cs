using Prism.Commands;
using Prism.Mvvm;
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
    public class RegistPageViewModel : BindableBase
    {
        private StaffService StaffService { get; }

        public DelegateCommand LoadCommand { get; }

        public ObservableCollection<Party> WaitingList { get; } = new ObservableCollection<Party>();

        public RegistPageViewModel(StaffService staffService)
        {
            this.StaffService = staffService;

            this.LoadCommand = new DelegateCommand(async () => await this.LoadExecuteAsync());
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
    }
}
