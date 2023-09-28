using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinal.model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PetDetails : ContentPage
    {
        public PetDetails(pets slectedPet)
        {
            InitializeComponent();

            petName.Text = slectedPet.Name;
            petDescription.Text = slectedPet.Description;
        }
    }
}