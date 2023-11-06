using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MimeKit;
using MailKit.Net.Smtp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecoveryPass : ContentPage
    {
        public RecoveryPass()
        {
            InitializeComponent();
        }

        private async void Btn_sendata(object sender, EventArgs e)
        {

            Random random = new Random();
            int code = random.Next(100000, 999999);


            var emailUser = datauser.Text;
            if (!String.IsNullOrEmpty(emailUser))
            {
                var bodyBuilder = new BodyBuilder();

                var emailAG = "email";
                var passwordAplication = "clave de aplicación";

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("AnimalGuardian", emailAG));
                message.To.Add(new MailboxAddress("Usuario", emailUser));
                message.Subject = "Recuperar contraseña";


                bodyBuilder.TextBody = $"Aqui tiene el código para recuperar su contraseña: {code}";

                message.Body = bodyBuilder.ToMessageBody();

                // Configurar el cliente SMTP
                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate(emailAG, passwordAplication);

                    client.Send(message);

                    client.Disconnect(true);
                }

                User user = new User
                {
                    Name = datauser.Text,
                    Email = emailUser,
                    Password = null,
                };

                await Navigation.PushAsync(new ChangePassword(user, code));

            }
            else
            {
                await DisplayAlert("Alerta", "El campo de EmailEstá vacío", "Ok");
            }
        }
    }
}
                                    /*▄︻デ𝘗𝘈𝘕══━一*/