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
	public partial class CadastroBiometria : ContentPage
	{
		public CadastroBiometria ()
		{
			InitializeComponent();
		}

        private async void Entry_Completed(object sender, EventArgs e)
        {
            var entry = sender as Entry;

            if (entry == null || string.IsNullOrEmpty(entry.Text))
                return;

            var biometria = new Biometria
            {
                //IDAnestesia2 = int.Parse(TXTIDAnestesia2.Text),
                ValorBiometria = entry.Text,
               // NumAnestesia2 = TXTIDAnestesia2.Text
            };

            switch (entry.StyleId)
            {
                case "CompTotal":
                    biometria.TipoBiometria = "CompTotal";
                    break;
                case "CompCab":
                    biometria.TipoBiometria = "CompCab";
                    break;
                case "Largcab":
                    biometria.TipoBiometria = "Largcab";
                    break;
                case "PadraoEsc":
                    biometria.TipoBiometria = "PadraoEsc";
                    break;
                case "CompEscEnc":
                    biometria.TipoBiometria = "CompEscEnc";
                    break;
                case "LargEscEnc":
                    biometria.TipoBiometria = "LargEscEnc";
                    break;
                case "LargIntOrb":
                    biometria.TipoBiometria = "LargIntOrb";
                    break;
                case "LargIntLacr":
                    biometria.TipoBiometria = "LargIntLacr";
                    break;
                case "CompOr":
                    biometria.TipoBiometria = "CompOr";
                    break;
                case "CompcCauda":
                    biometria.TipoBiometria = "CompCauda";
                    break;
                case "LargCauda":
                    biometria.TipoBiometria = "LargCauda";
                    break;
                case "CompEscEsc":
                    biometria.TipoBiometria = "CompEscEsc";
                    break;
                case "SemiCircEscEsc":
                    biometria.TipoBiometria = "SemiCircEscEsc";
                    break;
                case "CompEscPel":
                    biometria.TipoBiometria = "CompEscPel";
                    break;
                case "SemiCircEscPel":
                    biometria.TipoBiometria = "SemiCircEscPel";
                    break;
            }
            await App.Database.SaveBiometriaAsync(biometria);
        }
    }
}