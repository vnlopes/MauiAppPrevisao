using MauiAppPrevisao.Services;

namespace MauiAppPrevisao.Views;

public partial class LoginView : ContentPage
{
    public LoginView()
    {
        InitializeComponent();
    }

    private void BtnLogin_Clicked(object sender, EventArgs e)
    {
        string email = txtEmail.Text;
        string senha = txtSenha.Text;

        var usuario = DatabaseService.Instance.Login(email, senha);

        if (usuario != null)
        {
            // NOVO: Salva quem logou na memória do App
            App.UsuarioLogado = usuario;

            Application.Current.MainPage = new NavigationPage(new PrevisaoView());
        }
        else
        {
            DisplayAlert("Erro", "E-mail ou senha incorretos.", "OK");
        }
    }

    private async void TapCadastrar_Tapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroView());
    }
}