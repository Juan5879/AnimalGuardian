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
        }

        protected override async void OnStart()
        {
            base.OnStart();

            //string usuarioAlmacenado = await SecureStorage.GetAsync("Usuario");
            //string contraseñaAlmacenada = await SecureStorage.GetAsync("Contraseña");
            /*
            if (!string.IsNullOrEmpty(usuarioAlmacenado) && !string.IsNullOrEmpty(contraseñaAlmacenada))
            {
                UserData userAuth = new UserData
                {
                    Name = usuarioAlmacenado,
                    Password = contraseñaAlmacenada,
                    Email = usuarioAlmacenado
                };

                var BodyConfirmation = await apiservice.UserAuth(userAuth);
                var confirmation = BodyConfirmation.status;

                if (confirmation == true)
                {
                    MainPage = new NavigationPage(new MainPage());
                }
                else
                {
                    MainPage = new NavigationPage(new Login());
                }
            }*/
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

    }
}
