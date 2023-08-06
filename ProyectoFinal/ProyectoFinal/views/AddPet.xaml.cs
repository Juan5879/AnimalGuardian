using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProyectoFinal.model;

namespace ProyectoFinal.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPet : ContentPage
    {
        public AddPet()
        {
            InitializeComponent();
        }
        private async void Btn_SavePet(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                //Crear una nueva clase "pet" donde se llenan los campos para guardarlos en la base de datos.
                pets pet = new pets
                {
                    Name = petName.Text,
                    Description = petDescription.Text,
                };
                //await App.SQLiteDB.SavePet(pet);

                //Deja vacias las variables.
                petName.Text = "";
                petDescription.Text = "";

                //Alerta de que se guardaron los datos.
                await DisplayAlert("Registro", "Se cargaron los datos correctamente.", "Aceptar");
            }

            //En caso de no poder guardar los datos se despliega este mensaje.
            else
            {
                await DisplayAlert("Error", "Datos incompletos", "Aceptar");
            }
            await Navigation.PopAsync();
        }

        //Esta función se asegura que todos los campos contengan texto.
        public bool ValidarDatos()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(petName.Text))
            {
                respuesta= false;
            }
            else if (string.IsNullOrEmpty(petDescription.Text))
            {
                respuesta= false;
            }
            else
            {
                respuesta= true;
            }
            return respuesta;
        }
    }
}