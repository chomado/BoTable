using System;
using BoTable.ViewModels;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;
using System.Diagnostics;
using Newtonsoft.Json;

namespace BoTable.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void OnQrClicked(object sender, EventArgs e)
        {
			//var mainPageViewModel = (MainPageViewModel)this.BindingContext;
            //mainPageViewModel.TestNavigateToDetailCommand.Execute();

            try
            {
                // スキャナページの設定
                var scanPage = new ZXingScannerPage()
                {
                    DefaultOverlayTopText = "バーコードを読み取ります",
                    DefaultOverlayBottomText = "",
                };
                // スキャナページを表示
                await this.Navigation.PushAsync(scanPage);

                // データが取れると発火
                scanPage.OnScanResult += (result) =>
                {
                // スキャン停止
                scanPage.IsScanning = false;

                // PopAsyncで元のページに戻り、結果をダイアログで表示
                Device.BeginInvokeOnMainThread(async () =>
                    {
                        await this.Navigation.PopAsync();
                        var mainPageViewModel = (MainPageViewModel)this.BindingContext;
                        // ダッシュボードページへの遷移のコマンド実行
                        dynamic json = JsonConvert.DeserializeObject(result.Text);
                        mainPageViewModel.NavigateToDetailCommand.Execute((string)json.id);
                    });
                };
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

        }
    }
}
