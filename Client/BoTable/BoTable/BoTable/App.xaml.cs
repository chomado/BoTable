using Prism.Unity;
using BoTable.Views;
using Microsoft.Azure.Documents.Client;
using Microsoft.Practices.Unity;
using BoTable.Services;
using Xamarin.Forms;
using BoTable.Model;

namespace BoTable
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
			Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<DashboardPage>();

            Container.RegisterType<Registration>(new ContainerControlledLifetimeManager());

            // Document クライアントをコンテナに登録
            Container.RegisterInstance(new DocumentClient(
                serviceEndpoint: new System.Uri("https://botable.documents.azure.com:443/"),
                authKeyOrResourceToken: "Qp2YxwT8uNCTrhuKR3pUCnLkgbEkQWu1CcD0TQzAq67VCeqIKBWiyHRSwyNbQaejcYioptYY0JSraNNK1pByvQ=="));

            Container.RegisterType<PartyInfo>(new ContainerControlledLifetimeManager());
        }
    }
}
