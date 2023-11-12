using ProyectoFinal.http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerifiUserData : ContentPage
    {
        readonly APIService apiservice;
        public VerifiUserData()
        {
            InitializeComponent();
            VerifiDataLocalUser();

        }

        public async void VerifiDataLocalUser()
        {
            System.Threading.Thread.Sleep(2000);
            var name = Preferences.Get("Name", null);
            var password = Preferences.Get("Password", null);
            var email = Preferences.Get("Email", null);
            User user = new User
            {
                Name = name,
                Password = password,
                Email = email
            };

            await DisplayAlert("Data", $"{name}, {password}, {email}", "ok");

            if (name == null && password == null && email == null)
            {
                await Navigation.PushAsync(new Login());
            }
            else
            {

                var Auth = await apiservice.UserAuth(user);

                if (Auth.status == true)
                {
                    await Navigation.PushAsync(new MainPage());
                }
            }
        }
    }
}