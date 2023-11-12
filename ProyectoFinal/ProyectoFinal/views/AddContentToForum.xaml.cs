using ProyectoFinal.http;
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
        private APIService apiservice;
        public AddContentToForum()
        {
            InitializeComponent();
            apiservice = new APIService();
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
                await Navigation.PopAsync();
            }
            
        }

        async void AddNewForumContent()
        {
            var userNameSaved = Application.Current.Properties.ContainsKey("Usuario") ? (string)Application.Current.Properties["Usuario"] : string.Empty;
            var content = new ForumContent
            {
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Title = forumTitle.Text,
                user = userNameSaved,
                Date = DateTime.Now,
                Content = forumContent.Text
            };
            await apiservice.PostForum(content);
        }        
    }
}