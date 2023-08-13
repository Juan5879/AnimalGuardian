using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProyectoFinal.model;

namespace ProyectoFinal.views
{ 

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class enclosurePet : ContentPage
    {
        SQLiteHelper SQLiteHelper;


        public enclosurePet()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                lstPets.ItemsSource = await App.Database.ReadPets(); 
            }
            catch
            {

            }
            //lista estatica
            /*
            var listamascota = new List<petTS>
            {
                new petTS { Name = "Raul estatico", Description = "Una lista estatica"},
                new petTS { Name = "Raul estatico 2", Description = "Una lista estatica 2"},
                new petTS { Name = "Raul estatico 3", Description = "Una lista estatica 3"}
            };
            lstPets.ItemsSource = listamascota;*/
        }

        private async void btn_addPet_Clicked(object sender, EventArgs e)
        {           
            await Navigation.PushAsync(new AddPet());
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {

        }
    }
}

                                                              /*▄︻デPAN̷══━一*/