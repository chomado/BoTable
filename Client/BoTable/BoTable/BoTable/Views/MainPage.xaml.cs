﻿using System;
using BoTable.ViewModels;
using Xamarin.Forms;

namespace BoTable.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void OnQrClicked(object sender, EventArgs e)
        {
            var mainPageViewModel = (MainPageViewModel)this.BindingContext;

            // ダッシュボードページへの遷移のコマンド実行
            mainPageViewModel.NavigateToDetailCommand.Execute();
        }
    }
}