using HamburgerIcon.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HamburgerIcon
{
	public partial class MainPage : MasterDetailPage
	{
		public MainPage()
		{
			InitializeComponent();

            Master = new MenuPage();
            //Detail = new NavigationPage(new HomePage());
            Detail = new CustomNavigationPage(new HomePage());
            Icon = "icon.png";
		}
	}
}
