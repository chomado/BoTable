using BoTable.Model;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BoTable.ViewModels
{
	public class DashboardPageViewModel : BindableBase, INavigationAware
    {
        private PartyInfo PartyInfo { get; }

		public DashboardPageViewModel(PartyInfo partyInfo)
        {
            this.PartyInfo = partyInfo;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.TryGetValue("id", out var id))
            {
                this.PartyInfo.Id = (string)id;
            }
        }
    }
}
