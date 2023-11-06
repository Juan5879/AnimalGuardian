using ProyectoFinal.http;
using ProyectoFinal.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Forum : ContentPage
    {
        private APIService apiservice;
        public bool CreateData = true;


        public Forum()
        {
            InitializeComponent();
            apiservice = new APIService();
        }
        protected override async void OnAppearing()
        {
            var forumdata = await apiservice.GetForumContent();
            lstForum.ItemsSource = forumdata;
            OnPropertyChanged(nameof(lstForum.ItemsSource));
        }


        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            lstForum.ItemsSource = await App.Database.SearchForum(e.NewTextValue);
        }

        private async void CreateForumContent_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddContentToForum());
        }
    }
}