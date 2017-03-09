using Xamarin.Forms;

namespace BoTable.Views
{
    public partial class DashboardPage : TabbedPage
    {
		public DashboardPage()
        {
			InitializeComponent(); 
            this.ItemsSource = new[] {
                new Item { Title = "Tab1", Color = "Red" }, 
                new Item { Title = "Tab2", Color = "Blue" }, 
                new Item { Title = "Tab3", Color = "Olive" },
            };
        }
    }
	public class Item
	{
		public string Title { get; set; }
		public string Color { get; set; }
	}
}
