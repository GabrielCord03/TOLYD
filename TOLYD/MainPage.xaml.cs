using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using TOLYD.Data;
using TOLYD.Classes;

namespace TOLYD
{
    public partial class MainPage : ContentPage
    {
        private readonly Conexao _database;
        public MainPage()
        {
            InitializeComponent();
            _database = new Conexao(DependencyService.Get<IFileHelper>().GetLocalFilePath("YourApp.db3"));
        }

        private async void BTNLogar_Clicked(object sender, EventArgs e)
        {
            var user = await _database.GetUserAsync(TXTEmail.Text);

            if (user != null && user.Password == TXTSenha.Text)
            {
                if (TesteConexao.IsConnected())
                {
                    var apiService = new ApiConexao();
                    await apiService.SyncUserAsync(user);
                }
             
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Erro", "Nome de usuário ou senha inválidos", "OK");
            }
            await Navigation.PushAsync(new CadastroTatu());
        }

        private async void BTNCriar_Clicked(object sender, EventArgs e)
        {
            var existingUser = await _database.GetUserAsync(TXTEmail.Text);
            if (existingUser != null)
            {
                await DisplayAlert("Erro", "Usuário já existe", "OK");
                return;
            }

            // Cria um novo usuário
            var newUser = new User
            {
                Username = TXTEmail.Text,
                Password = TXTSenha.Text // Aqui, em uma aplicação real, você deve hash a senha antes de salvar
            };

            // Salva o novo usuário no banco de dados
            int result = await _database.SaveUserAsync(newUser);
            if (result > 0)
            {
                await DisplayAlert("Sucesso", "Usuário criado com sucesso", "OK");
            }
            else
            {
                await DisplayAlert("Erro", "Falha ao criar usuário", "OK");
            }
        }
    }
}
