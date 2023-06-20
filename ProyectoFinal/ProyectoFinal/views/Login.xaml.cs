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
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void Btn_login(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());  
        }
        private async void Btn_nav_register(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }
        private async void Btn_nav_recoverypass(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecoveryPass());
        }
    }
}
                       /*▁ ▂ ▄ ▅ ▆ ▇ █ PAN █ ▇ ▆ ▅ ▄ ▂ ▁*/