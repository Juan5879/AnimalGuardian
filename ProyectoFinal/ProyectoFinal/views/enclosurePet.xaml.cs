﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal.views
{ 

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class enclosurePet : ContentPage
        
    {

        public enclosurePet()
        {
            InitializeComponent();
         
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var petList = await App.SQLiteDB.GetAllPets();
            if(petList != null )
            {
                lstPets.ItemsSource = petList;
            }
        }

        private async void btn_addPet_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPet());
        }
    }
}

                                                              /*▄︻デPAN̷══━一*/