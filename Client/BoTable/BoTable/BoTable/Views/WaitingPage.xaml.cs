using System;
using BoTable.ViewModels;
using Xamarin.Forms;

namespace BoTable.Views
{
    public partial class WaitingPage : ContentPage
    {
        public WaitingPage()
        {
            InitializeComponent();
        }

        public void OnQrClicked(object sender, EventArgs e)
        {
            var mainPageViewModel = (MainPageViewModel)this.BindingContext;

            // 詳細ページへの遷移のコマンド実行
            mainPageViewModel.NavigateToDetailCommand.Execute();
        }
    }
}
