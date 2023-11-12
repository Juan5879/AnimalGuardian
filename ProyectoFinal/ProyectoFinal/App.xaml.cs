using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProyectoFinal.views;
using ProyectoFinal.model;
using SQLite;
using System.IO;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using ProyectoFinal.http;
using Xamarin.Essentials;
using System.Xml.Linq;

namespace ProyectoFinal
{
    public partial class App : Application
    {

        private static SQLiteHelper db;
        private APIService apiservice;
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
        }

        protected async override void OnStart()
        {
            base.OnStart();

            MainPage = new NavigationPage(new Login());

        }
    
        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {

        }

    }
}
