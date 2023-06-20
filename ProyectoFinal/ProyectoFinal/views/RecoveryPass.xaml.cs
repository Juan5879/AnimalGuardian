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
    public partial class RecoveryPass : ContentPage
    {
        public RecoveryPass()
        {
            InitializeComponent();
        }

        private async void Btn_sendata(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPage());
        }
    }
}
                                    /*▄︻デ𝘗𝘈𝘕══━一*/