using Prism.Unity;
using StaffClient.Views;
using Microsoft.Practices.Unity;
using Microsoft.Azure.Documents.Client;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace StaffClient
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override async void OnInitialized()
        {
            try
            {
                InitializeComponent();

                await this.NavigationService.NavigateAsync("NavigationPage/MainPage");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        protected override void RegisterTypes()
        {
            this.Container.RegisterTypeForNavigation<NavigationPage>();
            this.Container.RegisterTypeForNavigation<MainPage>();

            this.Container.RegisterInstance(new DocumentClient(
                new Uri("https://botable.documents.azure.com:443/"),
                "Qp2YxwT8uNCTrhuKR3pUCnLkgbEkQWu1CcD0TQzAq67VCeqIKBWiyHRSwyNbQaejcYioptYY0JSraNNK1pByvQ=="));
            this.Container.RegisterTypeForNavigation<RegistPage>();
            this.Container.RegisterTypeForNavigation<LeavePage>();
        }
    }
}
