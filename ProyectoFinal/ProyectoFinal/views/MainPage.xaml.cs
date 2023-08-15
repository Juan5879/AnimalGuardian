/*Librerías y elementos*/
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : Xamarin.Forms.TabbedPage
    {
        private int paginactual = 0; 
        private int totaldepaginas = 5; 

        public MainPage()
        {
            InitializeComponent();

            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom); //Coloca el TabbedPage en el fondo de la pantalla
            On<Android>().SetIsSmoothScrollEnabled(true); //habilita el desplazamiento suave en el TabbedPage. 

            this.Appearing += MainPage_move; //Cuando la página se muestra, se ejecuta el código dentro del método MainPage_move.
            totaldepaginas = Children.Count; //Asigna el número total de páginas hijos del TabbedPage a la variable.

            NavigationPage.SetHasNavigationBar(this, false);
        }   

        private async void MainPage_move(object sender, EventArgs e) //El menú se desplaza solo hasta recinto gracias a esta función.
        {
            while (paginactual != 2) //Mientras la página actual sea diferente a 2...
            {
                await Task.Delay(0); //Se contará el intervalo de tiempo establecido
                paginactual++;       //Se suma +1 a la variable de la página actual
                CurrentPage = Children[paginactual]; //Se navega a la siguiente página indicada por el indice "paginactual"
            }
        }
    }
}

                                                                /*█▓▒­░⡷⠂🍞⠐⢾░▒▓█*/