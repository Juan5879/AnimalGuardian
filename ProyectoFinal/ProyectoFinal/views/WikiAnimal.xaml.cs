using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinal.http;
using ProyectoFinal.model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal.views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WikiAnimal : ContentPage
	{
        private APIService apiservice;
        public bool CreateData = true;
		public WikiAnimal ()
		{
			InitializeComponent ();
            apiservice = new APIService();
		}
        protected override async void OnAppearing()
        {
            var wikiAnimals = await apiservice.GetWikisAnimalAsync();
            lstWiki.ItemsSource = wikiAnimals;
            OnPropertyChanged(nameof(lstWiki.ItemsSource));
        }
        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            lstWiki.ItemsSource = await App.Database.SearchWiki(e.NewTextValue);
        }
    }
}
