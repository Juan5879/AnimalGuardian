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
    public partial class AddPet : ContentPage
    {
        public AddPet()
        {
            InitializeComponent();
        }
        private void OnPickerSelectionChanged(object sender, EventArgs e)
        {
            var selectedOption = animalType.SelectedItem as String;
        }
        /*
        private async void Btn_SavePet(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        */
    }
}