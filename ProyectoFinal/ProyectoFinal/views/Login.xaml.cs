using ProyectoFinal.http;
using ProyectoFinal.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft;
using Newtonsoft.Json;
using System.Threading;

namespace ProyectoFinal.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private readonly APIService apiservice;
        public Login()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            apiservice = new APIService();
            SearchDataSaved();
        }

        public async void SearchDataSaved()
        {
            var username = Application.Current.Properties.ContainsKey("Usuario") ? (string)Application.Current.Properties["Usuario"] : string.Empty;
            var password = Application.Current.Properties.ContainsKey("Contraseña") ? (string)Application.Current.Properties["Contraseña"] : string.Empty;
            var remember = Application.Current.Properties.ContainsKey("remember") ? (bool)Application.Current.Properties["remember"] : false;

            if (remember == true && username != null && password != null)
            {
                User userAuth = new User
                {
                    Name = username,
                    Password = password,
                    Email = username
                };

                var authsusses = await apiservice.UserAuth(userAuth);

                if (authsusses.status)
                {
                    await Navigation.PushAsync(new MainPage());
                }
            }
            Thread.Sleep(1000);
        }

        private async void Btn_login(object sender, EventArgs e)
        {
            User userAuth = new User
            {
                Name = user.Text, 
                Password = password.Text,
                Email = user.Text
            };

            var BodyConfirmation = await apiservice.UserAuth(userAuth);
            var confirmation = BodyConfirmation.status;

            var data = await apiservice.GetUserByName(userAuth.Name);
           

            if (confirmation == true)
            {
                Application.Current.Properties["Contraseña"] = userAuth.Password;
                Application.Current.Properties["Usuario"] = data.Name;
                Application.Current.Properties["Email"] = data.Email;
                var remember = rememberPasswordCheckbox.IsChecked;

                if (remember)
                {
                    Application.Current.Properties["remember"] = true;
                    Application.Current.SavePropertiesAsync();
                    await Navigation.PushAsync(new MainPage());
                }
                else
                {
                    Application.Current.SavePropertiesAsync();
                    await Navigation.PushAsync(new MainPage());
                }
            }
            else
            {
                
                await DisplayAlert("Alerta", "Usuario o contraseña no validos, por favor vuelva a intentarlo.", "ok");
            }
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