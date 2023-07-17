using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal.views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class user : ContentPage
	{
		public user ()
		{
			InitializeComponent ();
		}

        private async void btn_nav_config_Clicked(object sender, EventArgs e)
        {
			await Navigation.PushAsync(new AddPage());
        }

        private void btn_nav_contact_Clicked(object sender, EventArgs e)
        {

        }

        private void btn_nav_closesion_Clicked(object sender, EventArgs e)
        {

        }
    }
}