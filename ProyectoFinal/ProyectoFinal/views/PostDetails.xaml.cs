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
    public partial class PostDetails : ContentPage
    {
        public PostDetails(ForumContent content)
        {
            InitializeComponent();

            Title.Text = content.Title;
            Content.Text = content.Content;
            User.Text = content.user;
            Date.Text = content.Date.ToString();
        }
    }
}