using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPet : ContentPage
    {
        private SQLiteConnection database;
        public AddPet()
        {
            InitializeComponent();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mascotasdb.db");
            database = new SQLiteConnection(dbPath);
            database.CreateTable<mascota>();
        }
        /*
        private void OnPickerSelectionChanged(object sender, EventArgs e)
        {
            var selectedOption = animalType.SelectedItem as String;
        }
        */
        private async void Btn_SavePet(object sender, EventArgs e)
        {
            string Name = petName.Text;
            string Notes = petNotes.Text;

            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Notes))
            {
                mascota nuevamascota = new mascota()
                {
                    Name = Name,
                    Notes = Notes
                };

                database.Insert(nuevamascota);

                await DisplayAlert("Mensaje", "La mascota ha sido agregada", "Aceptar");

                petName.Text = string.Empty;
                petNotes.Text = string.Empty;
            }
            else
            {
                await DisplayAlert("Error", "Campos incompletos", "Aceptar");
            }

            await Navigation.PopAsync();
        }

    }
}