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
	public partial class PetView : ContentPage
	{
		model.pets _pet;
		public PetView (model.pets pet)
		{
			InitializeComponent ();
			Title = "Editar datos de mascota";
			_pet = pet;
			petName.Text = pet.Name;
			petDescription.Text = pet.Description;
			petName.Focus ();
		}

        private void btn_SavePet_Clicked(object sender, EventArgs e)
        {
			if (_pet != null)
			{
				UpdatePet();
			}
        }
		async void UpdatePet()
		{
			_pet.Name = petName.Text;
			_pet.Description = petDescription.Text;
			await App.Database.UpdatePet(_pet);
			await Navigation.PopAsync();
		}
    }
}