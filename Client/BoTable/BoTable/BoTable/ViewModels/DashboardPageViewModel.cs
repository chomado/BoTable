using BoTable.Model;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace BoTable.ViewModels
{
	public class DashboardPageViewModel : BindableBase, INavigationAware
    {
        private PartyInfo PartyInfo { get; }

        private IPageDialogService PageDialogService { get; }

		public DashboardPageViewModel(PartyInfo partyInfo, IPageDialogService pageDialogService)
        {
            this.PartyInfo = partyInfo;
            this.PageDialogService = pageDialogService;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            object id;
            if (parameters.TryGetValue("id", out id))
            {
                this.PartyInfo.Id = (string)id;
                await this.PartyInfo.UpdateAsync();

                if (this.PartyInfo.PartyCount != -1)
                {
                    Device.StartTimer(TimeSpan.FromSeconds(5), () =>
                    {
                        this.PartyInfo.UpdateAsync().Wait();
                        if (this.PartyInfo.PartyCount == 1)
                        {
                            this.PageDialogService.DisplayAlertAsync("Info", "お客様の番が来ました。いらっしゃいませ。", "OK");
                            return false;
                        }
                        return true;
                    });
                }
            }
        }
    }
}
