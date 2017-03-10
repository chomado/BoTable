using StaffClient.BusinessObjects;
using StaffClient.ViewModels;
using Xamarin.Forms;

namespace StaffClient.Views
{
    public partial class SheetsPage : ContentPage
    {
        public SheetsPage()
        {
            InitializeComponent();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) { return; }

            ((SheetsPageViewModel)this.BindingContext).RegistCommand.Execute((Sheet)e.SelectedItem);
            ((ListView)sender).SelectedItem = null;
        }
    }
}
