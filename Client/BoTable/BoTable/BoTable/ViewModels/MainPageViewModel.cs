using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BoTable.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

		public MainPageViewModel(INavigationService navigationService)
        {
            // 詳細ページへと遷移する時のコマンドを定義
            this.NavigateToDetailCommand = new DelegateCommand<string>(
                executeMethod: async x => await navigationService.NavigateAsync(name: $"DashboardPage?id={x}")
            );
        }

        // ライフサイクル

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }

        // コマンド

        // 詳細ページへと遷移したい時に呼ばれるコマンド
        public DelegateCommand<string> NavigateToDetailCommand { get; }
    }
}
