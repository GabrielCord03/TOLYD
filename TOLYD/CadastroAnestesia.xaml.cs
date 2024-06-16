using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOLYD.Classes;
using TOLYD.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.Mime.MediaTypeNames;

namespace TOLYD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroAnestesia : ContentPage
    {
        private Animal _animal;
        private List<Anestesia2> _anestesia2List;
        private int _currentAnestesia2Index;
        public CadastroAnestesia(Animal animal)
        {
            InitializeComponent();
            _animal = animal;
            _anestesia2List = new List<Anestesia2> { new Anestesia2() };
            _currentAnestesia2Index = 0;
        }

        private void UpdateAnestesia2Fields()
        {
            {
                try
                {                     
                        var currentAnestesia2 = _anestesia2List[_currentAnestesia2Index];
                        TXTIDAnestesia2.Text = _currentAnestesia2Index.ToString();
                        TXTValorFC.Text = currentAnestesia2.ValorAnestesia2;
                        TXTValorFR.Text = currentAnestesia2.ValorAnestesia2;
                        TXTValorOximetria.Text = currentAnestesia2.ValorAnestesia2;
                        TXTValorTemperatura.Text = currentAnestesia2.ValorAnestesia2;
                    
                }
                catch
                {
                    TXTIDAnestesia2.Text = _currentAnestesia2Index.ToString();
                    TXTValorFC.Text = string.Empty;
                    TXTValorFR.Text = string.Empty;
                    TXTValorOximetria.Text = string.Empty;
                    TXTValorTemperatura.Text = string.Empty;
                }
            }
        }

        private void SaveCurrentAnestesia2()
        {
            var currentAnestesia2 = _anestesia2List[_currentAnestesia2Index];
            currentAnestesia2.IDAnestesia2 = int.Parse(TXTIDAnestesia2.Text);
            currentAnestesia2.ValorAnestesia2 = TXTValorFC.Text; // Update this to get the correct value based on the StyleId
        }


        //    App.Database.SaveAnestesiaAsync(anestesia);

        // var captura = new Captura
        //{
        //    Id = animal.IdAnimal, // Usa o ID do animal salvo como chave primária
        //    LocCap = TXTLocCap.Text,
        //    DataCap = TXTDataCap.Text,
        //    Instituicao = TXTInstituicao.Text,
        //    Contato = TXTContato.Text,
        //    Obs = TXTObs.Text
        // };
        // await App.Database.SaveCapturaAsync(captura);




        private async void Entry_Completed(object sender, EventArgs e)
        {
            var entry = sender as Entry;

            if (entry == null || string.IsNullOrEmpty(entry.Text))
                return;

            SaveCurrentAnestesia2();

            var anestesia2 = new Anestesia2
            {
                IDAnestesia2 = int.Parse(TXTIDAnestesia2.Text),
                ValorAnestesia2 = entry.Text,
                NumAnestesia2 = TXTIDAnestesia2.Text
            };

            switch (entry.StyleId)
            {
                case "FC":
                    anestesia2.TipoAnestesia2 = "FC";
                    break;
                case "FR":
                    anestesia2.TipoAnestesia2 = "FR";
                    break;
                case "Oximetria":
                    anestesia2.TipoAnestesia2 = "Oximetria";
                    break;
                case "Temperatura":
                    anestesia2.TipoAnestesia2 = "Temperatura";
                    break;
            }
            await App.Database.SaveAnestesia2Async(anestesia2);
        }
        private void ButtonAnterior_Clicked(object sender, EventArgs e)
            {
                if (_currentAnestesia2Index > 0)
                {
                    SaveCurrentAnestesia2();
                    _currentAnestesia2Index--;
                    UpdateAnestesia2Fields();
                }
            }

            private void ButtonProximo_Clicked(object sender, EventArgs e)
            {
                if (_currentAnestesia2Index < _anestesia2List.Count - 1)
                {
                    SaveCurrentAnestesia2();
                    _currentAnestesia2Index++;
                }
                else
                {
                    SaveCurrentAnestesia2();
                    _anestesia2List.Add(new Anestesia2());
                    _currentAnestesia2Index++;
                }
                UpdateAnestesia2Fields();
            }

            private async void ButtonSalvar_Clicked(object sender, EventArgs e)
            {
                SaveCurrentAnestesia2();

                foreach (var anestesia2 in _anestesia2List)
                {
                    anestesia2.IDAnestesia2 = int.Parse(TXTIDAnestesia2.Text);
                    await App.Database.SaveAnestesia2Async(anestesia2);
                }

                var anestesia = new Anestesia
                {
                    idAnimalAnestesia = _animal.IdAnimal,
                    TipoAnestesia = TXTTipoAnestesia.Text,
                    AplicacaoAnestesia = TXTAplicacaoAnestesia.Text,
                    InducaoAnestesia = TXTInducaoAnestesia.Text,
                    RetornoAnestesia = TXTRetornoAnestesia.Text,
                    TempAnestesia = TXTTempAnestesia.Text,
                    OBSAnestesia = TXTObsAnestesia.Text
                };

                await App.Database.SaveAnestesiaAsync(anestesia);

            await Navigation.PushAsync(new CadastroBiometria());

            await DisplayAlert("Sucesso", "Anestesia e parâmetros fisiológicos salvos com sucesso", "OK");
            }
        }
    }
