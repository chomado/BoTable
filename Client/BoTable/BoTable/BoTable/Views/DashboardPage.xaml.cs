using BoTable.ViewModels;
using Xamarin.Forms;

namespace BoTable.Views
{
    public partial class DashboardPage : TabbedPage
    {
		public DashboardPage()
        {
			InitializeComponent();

            // タブが切り替えられたとき
            this.CurrentPageChanged += (sender, e) => {
                var waitingPage = this.CurrentPage as WaitingPage;
                if (waitingPage != null)
                {
                    var viewModel = waitingPage.BindingContext as WaitingPageViewModel;
                    viewModel.ShowWaitingPartyNumber();
                }
            };

            // 表示中
            this.Appearing += (sender, e) => { 
                var waitingPage = this.CurrentPage as WaitingPage;
				if (waitingPage != null)
				{
					var viewModel = waitingPage.BindingContext as WaitingPageViewModel;
					viewModel.ShowWaitingPartyNumber();
				}
            };
        }
    }
}
