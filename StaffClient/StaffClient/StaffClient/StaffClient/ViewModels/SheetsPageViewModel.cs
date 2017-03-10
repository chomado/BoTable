using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
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
    public class SheetsPageViewModel : BindableBase, INavigationAware
    {
        private INavigationService NavigationService { get; }

        private IPageDialogService PageDialogService { get; }

        private int PartyId { get; set; }

        private StaffService StaffService { get; }

        public ObservableCollection<Sheet> Sheets { get; } = new ObservableCollection<Sheet>();

        public DelegateCommand<Sheet> RegistCommand { get; }

        public SheetsPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, StaffService staffService)
        {
            this.StaffService = staffService;

            this.NavigationService = navigationService;
            this.PageDialogService = pageDialogService;

            this.RegistCommand = new DelegateCommand<Sheet>(async x => await this.RegistExecuteAsync(x));
        }

        private async Task RegistExecuteAsync(Sheet sheet)
        {
            var result = await this.PageDialogService.DisplayAlertAsync("確認", "お席にご案内しますか", "OK", "Cancel");
            if (!result) { return; }

            sheet.Status = SheetStatus.Fill;

            try
            {
                await this.StaffService.DeletePartyByIdAsync(this.PartyId);
                await this.StaffService.UpdateSheetAsync(sheet);

                await this.NavigationService.NavigateAsync("/NavigationPage/MainPage");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters == null) { return; }

            if (parameters.TryGetValue("partyId", out var partyId))
            {
                this.PartyId = int.Parse((string)partyId);
            }

            var sheets = await this.StaffService.GetSheetsByStatus(SheetStatus.Empty);
            this.Sheets.Clear();
            foreach (var sheet in sheets)
            {
                this.Sheets.Add(sheet);
            }
        }
    }
}
