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
    public partial class AccountDetails : ContentPage
    {
        User _user;
        User userdata;
        private APIService apiservice;

        public AccountDetails(User user)
        {
            InitializeComponent();
            apiservice = new APIService();
            _user = user;
            userName.Text = user.Name;
        }

        private async void savedata_Clicked(object sender, EventArgs e)
        {
            var oldpass = oldpassword.Text; // Obtiene el valor de oldpassword en este momento

            userdata = new User
            {
                Name = _user.Name,
                Email = _user.Email,
                Password = oldpass // Asigna el valor de oldpass en este momento
            };

            var userdatafromapi = await apiservice.GetUserByName(userdata.Name);
            userdata.Email = userdatafromapi.Email;
            userdata.IdUser = userdatafromapi.IdUser;
            var authsusses = await apiservice.UserAuth(userdata);

            var pass = userPassword.Text;
            var passRepeat = userPasswordRepeat.Text;
            if (authsusses.status == true && pass == passRepeat)
            {
                await apiservice.UpdateUserData(userdata);
                await DisplayAlert("Alerta", "Se modificó la contraseña correctamente", "Ok");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Alerta", "No se pudo cambiar la contraseña", "Ok");
            }
        }
    }
}