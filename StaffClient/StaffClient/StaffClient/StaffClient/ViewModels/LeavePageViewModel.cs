using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using StaffClient.BusinessObjects;
using StaffClient.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace StaffClient.ViewModels
{
    public class LeavePageViewModel : BindableBase, INavigationAware
    {
        private INavigationService NavigationService { get; }

        private IPageDialogService PageDialogService { get; }

        private StaffService StaffService { get; }

        public ObservableCollection<Sheet> Sheets { get; } = new ObservableCollection<Sheet>();

        public DelegateCommand<Sheet> LeaveCommand { get; }

        public LeavePageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, StaffService staffService)
        {
            this.NavigationService = navigationService;
            this.PageDialogService = pageDialogService;
            this.StaffService = staffService;

            this.LeaveCommand = new DelegateCommand<Sheet>(async x => await this.LeaveExecuteAsync(x));
        }

        private async Task LeaveExecuteAsync(Sheet x)
        {
            var answer = await this.PageDialogService.DisplayAlertAsync("Info", "席を空席にします", "OK", "Cancel");
            if (!answer) { return; }

            x.Status = SheetStatus.Empty;
            await this.StaffService.UpdateSheetAsync(x);
            await this.NavigationService.NavigateAsync("/NavigationPage/MainPage");
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            var result = await this.StaffService.GetSheetsByStatus(SheetStatus.Fill);
            this.Sheets.Clear();
            foreach (var sheet in result)
            {
                this.Sheets.Add(sheet);
            }
        }
    }
}
