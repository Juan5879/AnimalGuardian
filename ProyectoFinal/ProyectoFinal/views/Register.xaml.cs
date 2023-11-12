using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProyectoFinal.http;
using ProyectoFinal.model;

namespace ProyectoFinal.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        private APIService apiservice;
        public Register()
        {
            InitializeComponent();
            apiservice = new APIService();
        }

        private async void Btn_sendata(object sender, EventArgs e)
        {
            if (password.Text == passwordrepeat.Text)
            {
                User newUser = new User
                {
                    Name = user.Text,
                    Email = email.Text,
                    Password = password.Text
                };

                bool userAuth = await apiservice.CreateAuth(newUser);

                if (userAuth)
                {
                    await apiservice.CreateUserAsync(newUser);
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", "El nombre de usuario o Email ya está en uso", "Ok");
                }
                

            }
            else
            {
                await DisplayAlert("Error", "Las contraseñas no coinciden", "ok");
            }
        }
    }
}

                          /*｡*ﾟ.*.｡(っ ᐛ )っ PAN*/