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


            var email = datauser.Text;
            await DisplayAlert("Alerta", $"Email del receptor {email}", "ok");
            var bodyBuilder = new BodyBuilder();

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("AnimalGuardian", "mail@gmail.com"));
            message.To.Add(new MailboxAddress("Usuario", email));
            message.Subject = "Recuperar contraseña";


            bodyBuilder.TextBody = $"Aqui tiene el código para recuperar su contraseña: {code}";

            message.Body = bodyBuilder.ToMessageBody();

            // Configurar el cliente SMTP
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("mail@gmail.com", "código de aplicación");

                // Enviar el correo
                client.Send(message);

                client.Disconnect(true);
            }

            await Navigation.PushAsync(new AddPage());
        }
    }
}
                                    /*▄︻デ𝘗𝘈𝘕══━一*/