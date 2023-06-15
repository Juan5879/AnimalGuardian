using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProyectoFinal.views;


namespace ProyectoFinal
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //hace de Login la nueva pestaña de inicio, es la que se mostrará al iniciar la aplicación.
            MainPage = new NavigationPage(new Login());
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
