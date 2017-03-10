using System;
using Prism.Mvvm;

namespace BoTable
{
    public class Menu
    {
        public Menu()
        {
        }

		public string Name { get; set; }
        public string Description { get; set; }
		public string ImageUrl { get; set; }
        public int Price { get; set; }
    }
}
