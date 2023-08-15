using ProyectoFinal.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProyectoFinal.data;
using ProyectoFinal.model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Forum : ContentPage
    {
        public bool CreateData = true;
        public Forum()
        {
            InitializeComponent();
            var listForum = new List<ForumContent>();
            lstForum.ItemsSource = listForum;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                base.OnAppearing();
                if (CreateData != false)
                {
                    await App.Database.CreateForumPage(new ForumContent
                    {
                        Date = DateTime.Now,
                        Title = "Colapso de Colonias de Abejas",
                        User = "AmanteDeLosInsectos",
                        Content = "Vamos a discutir la alarmante disminución en las poblaciones de abejas y su impacto en la polinización."
                    });
                    await App.Database.CreateForumPage(new ForumContent
                    {
                        Date = DateTime.Now,
                        Title = "Jardines Amigables para Insectos",
                        User = "ManoVerde",
                        Content = "Comparte tus consejos para crear jardines que atraigan insectos beneficiosos mientras ahuyentan las plagas."
                    });

                    await App.Database.CreateForumPage(new ForumContent
                    {
                        Date = DateTime.Now,
                        Title = "Observación de Luciérnagas",
                        User = "ExploradorNocturno",
                        Content = "¿A quién más le encanta observar cómo las luciérnagas iluminan las noches de verano? Comparte tus lugares favoritos para ver luciérnagas."
                    });

                    await App.Database.CreateForumPage(new ForumContent
                    {
                        Date = DateTime.Now,
                        Title = "Comportamiento de Colonias de Hormigas",
                        User = "AmanteDeLasHormigas123",
                        Content = "Hablemos sobre el fascinante comportamiento y la organización de las colonias de hormigas. ¿Has observado alguna especie de hormiga interesante?"
                    });

                    await App.Database.CreateForumPage(new ForumContent
                    {
                        Date = DateTime.Now,
                        Title = "Repelentes para Mosquitos",
                        User = "ExploradorAlAireLibre",
                        Content = "Hablemos sobre formas efectivas y ecológicas de mantener alejados a los mosquitos durante las actividades al aire libre."
                    });

                    lstForum.ItemsSource = await App.Database.ReadForum();
                    CreateData = false;
                }
            }
            catch
            {

            }
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