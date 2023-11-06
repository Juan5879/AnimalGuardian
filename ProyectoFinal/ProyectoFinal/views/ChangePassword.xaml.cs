using ProyectoFinal.http;
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
    public partial class ChangePassword : ContentPage
    {
        int codeAuth;
        User userData = new User();
        private APIService apiservice;
        public ChangePassword(User user, int code)
        {
            InitializeComponent();

            apiservice = new APIService();

            codeAuth = code;
            userData.Email = user.Email;

        }

        private async void SendData_Clicked(object sender, EventArgs e)
        {
            if (Code.Text == codeAuth.ToString())
            {
                if (password.Text  == passwordRepeat.Text) 
                {
                    var userElement = await apiservice.GetUserByEmail(userData.Email);

                    if (userElement != null)
                    {
                        User userUpdatedData = new User
                        {
                            IdUser = userElement.IdUser,
                            Name = userElement.Name,
                            Email = userElement.Email,
                            Password = password.Text,
                            
                        };
                        var result = await apiservice.UpdateUserData(userUpdatedData);

                        if (result)
                        {
                            await DisplayAlert("Contraseña cambiada", "La contraseña fue cambiada exitosamente", "Ok");
                            await Navigation.PushAsync(new Login());
                        }
                        else
                        {
                            await DisplayAlert("Error", "´La contraseña no pudo ser modificada", "Ok");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Error", "No se encontró el usuario", "Ok");
                    }


                    
                }
                else
                {
                    await DisplayAlert("Error", "Las contraseñas no coinciden", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Error", "El código no es el correcto", "Ok");
            }
        }
    }
}