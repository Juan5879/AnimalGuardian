using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProyectoFinal.views;
using ProyectoFinal.model;
using SQLite;
using System.IO;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace ProyectoFinal
{
    public partial class App : Application
    {
        private static SQLiteHelper db;
        public static SQLiteHelper Database
        {
            get
            {
                if (db == null)
                {
                    db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Mascotas.db3"));
                }
                return db;
            }
        }

        public App()
        {
            InitializeComponent();
            //hace de Login la nueva pestaña de inicio, es la que se mostrará al iniciar la aplicación.
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

    }
}
