using Plugin.LocalNotifications;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationDetails : ContentPage
    {
        Notification notificationData;
        DateTime newNotificationDate;
        public NotificationDetails(Notification notification)
        {
            InitializeComponent();

            notificationData = new Notification();

            PetName.Text = notification.PetName;
            Description.Text = notification.Description;
            TimeSpan timeSpanValue = notification.Time.TimeOfDay;
            TimeEntry.Time = timeSpanValue;



            notificationData.Id = notification.Id;

            notificationData.IdPet = notification.IdPet;
            notificationData.Hour = notification.Hour;
            notificationData.Minute = notification.Minute;
            notificationData.PetName = notification.PetName;
        }

        public async void UpdateNotification()
        {
            TakeData();

            await App.Database.UpdateNotification(notificationData);

            CrossLocalNotifications.Current.Show("Animal Guardian", notificationData.Description, notificationData.Id, newNotificationDate);

            await Navigation.PopAsync();
        }

        public void TakeData()
        {
            var description = Description.Text;

            notificationData.Description = description;

            TimeSpan Time = TimeEntry.Time;
            var Hours = Time.Hours;
            var Minutes = Time.Minutes;

            DateTime DateTimeNow = DateTime.Now;
            DateTime dateTime;

            string Date = $"{DateTimeNow:yyyy-MM-dd}T{Hours:00}:{Minutes:00}:00";
            if (DateTime.TryParseExact(Date, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                newNotificationDate = dateTime;
            }
        }

        private async void delete_Clicked(object sender, EventArgs e)
        {
            var confirmation = await DisplayAlert("Advertencia", $"Quiere eliminar esta notificación?", "Si", "No");

            if (confirmation == true)
            {
                await App.Database.DeleteNotification(notificationData);
                await Navigation.PopAsync();
            }
        }

        private void edit_Clicked(object sender, EventArgs e)
        {
            UpdateNotification();
        }
    }
}