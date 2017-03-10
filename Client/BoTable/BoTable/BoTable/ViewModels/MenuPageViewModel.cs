using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using BoTable.Services;

namespace BoTable.ViewModels
{
    public class MenuPageViewModel : BindableBase
    {

		public MenuPageViewModel(INavigationService navigationService)
        {
            this.Menu = PopulateMenu();
        }

        public IEnumerable<Menu> Menu { get; set; }

		IEnumerable<Menu> PopulateMenu()
        {
            var menu = new List<Menu>()
            {
                new Menu()
                {
                    Name = "牛めし",
                    Price = 290,
                    Description = "うまい。",
                    ImageUrl = "https://www.matsuyafoods.co.jp/menu/upload_images/gyu_160823.jpg"
                },
                new Menu()
                {
                    Name = "プレミアム牛めし",
                    Price = 380,
                    Description = "最高にうまい。毎日食べられる",
                    ImageUrl = "https://www.matsuyafoods.co.jp/menu/upload_images/pre_gyu_140718.jpg"
				},
				new Menu()
				{
					Name = "ネギたっぷりプレミアム旨辛ネギたま牛めし",
					Price = 440,
					Description = "最高にうまい。3食 毎日食べてた。10kg太った",
					ImageUrl = "https://www.matsuyafoods.co.jp/menu/upload_images/pre_gyu_negitama_160531.jpg"
				},
                new Menu()
                {
                    Name = "定番朝定食",
                    Price = 360,
                    Description = "朝11:00までの限定朝定食。うまい。毎日食べられる",
                    ImageUrl = "https://www.matsuyafoods.co.jp/menu/upload_images/morning_teiban_160411.jpg"
                },
                new Menu()
                {
                    Name = "牛焼肉定食",
                    Price = 590,
                    Description = "ミニサイズが存在せず、普通サイズしか無いから、実は私は食べたこと無い。でもすごい人気商品だよ！",
                    ImageUrl = "https://www.matsuyafoods.co.jp/menu/upload_images/tei_gyuuyaki_r_161018.jpg"
                },
                new Menu()
                {
                    Name = "生ビール中ジョッキ",
                    Price = 290,
                    Description = "ビールは大人の人が好きな飲み物。松屋でも飲めるよ！",
                    ImageUrl = "https://www.matsuyafoods.co.jp/menu/upload_images/beer_m_160620.jpg"
                }
            };

            return menu;
        }

    }
}
