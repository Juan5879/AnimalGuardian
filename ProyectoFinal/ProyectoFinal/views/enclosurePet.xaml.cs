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
using ProyectoFinal.data;
using System.Data;

namespace ProyectoFinal.views
{ 
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class enclosurePet : ContentPage
    {
        public static SQLiteConnection DBconection { get; set; }
        //public ObservableCollection<animalTS> AnimalTSList { get; set; }
        public enclosurePet()
        {
            InitializeComponent();

            string databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.db"); //Obtiene la ruta de la bsae de datos local.
            DBconection = new SQLiteConnection(databasePath); //Crea la conexión con la base de datos.
            DBconection.CreateTable<DBanimal>(); //Crea la tabla DBanimal en la base de datos.


            /*Funciones relacionadas a animalTS();
            AnimalTSList = new ObservableCollection<animalTS>();
            AnimalTSList.Add(new animalTS { nameTS = "Raul" });
            AnimalTSList.Add(new animalTS { descriptionTS = "Es horrible pero lamentablemente existen las arañas..." });
            petList.ItemsSource = AnimalTSList;*/
        }

        private async void btn_addPet_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPet());
        }


        /*ListView datos de ejemplo para evitar el uso inecesario de la base de datos
        public class animalTS
        {
            public string nameTS { get; set; }
            public string descriptionTS { get; set;}
        };*/
    }
}

                                                              /*▄︻デPAN̷══━一*/