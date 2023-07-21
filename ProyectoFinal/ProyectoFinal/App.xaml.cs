using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProyectoFinal.views;
using ProyectoFinal.data;
using System.IO;

namespace ProyectoFinal
{
    public partial class App : Application
    {
        static SQLiteHelper connection;

        public App()
        {
            InitializeComponent();
            //hace de Login la nueva pestaña de inicio, es la que se mostrará al iniciar la aplicación.
            MainPage = new NavigationPage(new MainPage());
        }
        public static SQLiteHelper SQLiteDB
        {
            get
            {
                if (connection == null)
                {
                    connection = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Database.db3"));
                }
                return connection;
            }
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
