using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProyectoFinal.model;
using MimeKit;

namespace ProyectoFinal.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WikiDetails : ContentPage
    {
        public WikiDetails(WikiData wiki)
        {
            InitializeComponent();

            var imageUrl = wiki.Image;
            var imageSource = new UriImageSource { Uri = new Uri(imageUrl) };
            URLimage.Source = imageSource;

            Name.Text = wiki.Name;
            ScientificName.Text = wiki.ScientificName;
            Species.Text = wiki.Species;
            SubSpecies.Text = wiki.SubSpecies;
            GeographicalDistribution.Text = wiki.GeographicalDistribution;
            Habitat.Text = wiki.Habitat;
            AverageSizeWeight.Text = wiki.AverageSizeWeight;
            Behavior.Text = wiki.Behavior;
            Reproduction.Text = wiki.Reproduction;
            Diet.Text = wiki.Diet;
            AnatomyCharacteristics.Text = wiki.AnatomyCharacteristics;
            StateConservation.Text = wiki.StateConservation;
            Curiosities.Text = wiki.Curiosities;
            ConservationThreats.Text = wiki.ConservationThreats;
            
            
        }
    }
}