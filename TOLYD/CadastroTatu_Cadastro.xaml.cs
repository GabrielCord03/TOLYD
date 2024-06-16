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
    public partial class CadastroTatu_Cadastro : ContentPage
    {
        public CadastroTatu_Cadastro()
        {
            InitializeComponent();
            //if (TXTNumIdAnimal.Text == string.Empty) {
                LoadNextIdAsync();
            //}

        }

        private async void LoadNextIdAsync()
        {
            // Lógica para obter o próximo número de identificação disponível
            int nextId = await App.Database.GetNextAnimalIdAsync(); // Implemente este método na classe de acesso ao banco de dados

            // Define o valor de TXTNumIdAnimal com o próximo ID disponível
            TXTNumIdAnimal.Text = nextId.ToString();
        }

        private async void ButtonSalvar_Clicked(object sender, EventArgs e)
        {
            var animal = new Animal
            {
                IdAnimal = Int32.Parse(TXTNumIdAnimal.Text),
                NomAnimal = TXTIdAnimal.Text,
                Peso = TXTPeso.Text,
                NumMicroChip = TXTNumMicroChip.Text
            };

            // Salva o animal no banco de dados
            await App.Database.SaveAnimalAsync(animal);

            var captura = new Captura
            {
                Id = animal.IdAnimal, // Usa o ID do animal salvo como chave primária
                LocCap = TXTLocCap.Text,
                DataCap = TXTDataCap.Text,
                Instituicao = TXTInstituicao.Text,
                Contato = TXTContato.Text,
                Obs = TXTObs.Text
            };
            await App.Database.SaveCapturaAsync(captura);

            await Navigation.PushAsync(new CadastroAnestesia(animal));



        }

    }
}