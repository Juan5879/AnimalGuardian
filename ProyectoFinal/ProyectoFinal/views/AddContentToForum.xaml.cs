using ProyectoFinal.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddContentToForum : ContentPage
    {
        public AddContentToForum()
        {
            InitializeComponent();
        }

        private async void post_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(forumTitle.Text) || string.IsNullOrWhiteSpace(forumContent.Text))
            {
                await DisplayAlert("Datos invalidos", "Los campos están vacíos", "Ok");
            }
            else
            {
                AddNewForumContent();
            }
        }

        async void AddNewForumContent()
        {
            await App.Database.CreateForumPage(new ForumContent
            {
                Title = forumTitle.Text,
                Content = forumContent.Text,
                User = "local:user",
                Date = DateTime.Now
            });
            await Navigation.PopAsync();
        }
    }
}