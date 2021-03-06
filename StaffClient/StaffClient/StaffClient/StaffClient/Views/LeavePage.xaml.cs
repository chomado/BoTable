﻿using StaffClient.BusinessObjects;
using StaffClient.ViewModels;
using Xamarin.Forms;

namespace StaffClient.Views
{
    public partial class LeavePage : ContentPage
    {
        public LeavePage()
        {
            InitializeComponent();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) { return; }

            ((LeavePageViewModel)this.BindingContext).LeaveCommand.Execute((Sheet)e.SelectedItem);
            ((ListView)sender).SelectedItem = null;
        }
    }
}
