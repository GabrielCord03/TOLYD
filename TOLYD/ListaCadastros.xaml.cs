using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOLYD.Classes;
using TOLYD.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TOLYD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaCadastros : ContentPage
    {
        public ListaCadastros()
        {
            InitializeComponent();
            LoadAnimalsAndCapturas();
        }

        private async void LoadAnimalsAndCapturas()
        {
            // Obter lista de animais
            List<Animal> animals = await App.Database.GetAnimalsAsync();

            // Para cada animal, obter as informações de captura correspondentes
            foreach (var animal in animals)
            {
                animal.Captura = await App.Database.GetCapturaByAnimalIdAsync(animal.IdAnimal);
            }

            // Definir a lista de animais como a fonte de itens para o ListView
            AnimalListView.ItemsSource = animals;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
             Navigation.PushAsync(new CadastroTatu_Cadastro());
        }

    }
}