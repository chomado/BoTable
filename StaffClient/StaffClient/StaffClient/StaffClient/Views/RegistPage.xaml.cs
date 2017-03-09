using StaffClient.ViewModels;
using System;
using Xamarin.Forms;

namespace StaffClient.Views
{
    public partial class RegistPage : ContentPage
    {
        public RegistPage()
        {
            InitializeComponent();
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            ((RegistPageViewModel)this.BindingContext).LoadCommand.Execute();
        }
    }
}
