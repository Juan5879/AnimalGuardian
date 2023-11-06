using ProyectoFinal.model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.LocalNotifications;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ParamNotificationPage : ContentPage
    {

        pets petdata = new pets();

        public ParamNotificationPage(pets pet)  
        {
            InitializeComponent();

            petName.Text = pet.Name;

            petdata.IdPet = pet.IdPet;
            petdata.Name = pet.Name;
            petdata.Description = pet.Description;
            petdata.TypeOfAnimal = pet.TypeOfAnimal;
            petdata.ImagePet = pet.ImagePet;
        }

        private async void CreateNotification_Clicked(object sender, EventArgs e)
        {
            TimeSpan Time = TimeEntry.Time;
            var Hours = Time.Hours;
            var Minutes = Time.Minutes;

            DateTime DateTimeNow = DateTime.Now;
            DateTime dateTime;

            string Date = $"{DateTimeNow:yyyy-MM-dd}T{Hours:00}:{Minutes:00}:00";
            if (DateTime.TryParseExact(Date, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                Notification notification = new Notification
                {
                    IdPet = petdata.IdPet,
                    PetName = petdata.Name,
                    Description = description.Text,
                    Hour = Hours,
                    Minute = Minutes,
                    Time = dateTime
                };
                await App.Database.CreateNotification(notification);

                CrossLocalNotifications.Current.Show("Animal Guardian", notification.Description, notification.Id, notification.Time);

                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Error", "Error al convertir la fecha de string a DateTime", "ok");
            }
        }
    }
}