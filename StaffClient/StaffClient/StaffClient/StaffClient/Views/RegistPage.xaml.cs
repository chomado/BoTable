using StaffClient.BusinessObjects;
using StaffClient.ViewModels;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace StaffClient.Views
{
    public partial class RegistPage : ContentPage
    {
        public RegistPage()
        {
            InitializeComponent();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                if (e.SelectedItem == null) { return; }
                var party = (Party)e.SelectedItem;
                ((RegistPageViewModel)this.BindingContext).SelectPartyCommand.Execute(party);
                ((ListView)sender).SelectedItem = null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
