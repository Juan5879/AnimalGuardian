﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private void btn_nav_Pet(object sender, EventArgs e)
        {

        }

        private void btn_nav_AddPet(object sender, EventArgs e)
        {

        }

        public class Element
        {
            public string animal { get; set; }
        }
    }
}