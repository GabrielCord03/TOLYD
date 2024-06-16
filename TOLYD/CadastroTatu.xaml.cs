using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TOLYD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroTatu : ContentPage
    {
        public CadastroTatu()
        {
            InitializeComponent();

        }

        private async void BTNCadastro_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CadastroTatu_Cadastro());
        }

        private async void BTNVisualizarLista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaCadastros());
        }
    }
}