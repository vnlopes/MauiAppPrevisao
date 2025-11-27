using MauiAppPrevisao.Models;
using MauiAppPrevisao.Services;

namespace MauiAppPrevisao.Views;

public partial class CadastroView : ContentPage
{
    public CadastroView()
    {
        InitializeComponent();
    }

    private async void BtnSalvar_Clicked(object sender, EventArgs e)
    {
        Usuario novoUser = new Usuario
        {
            Nome = txtNome.Text,
            DataNascimento = dtpNascimento.Date,
            Email = txtEmail.Text,
            Senha = txtSenha.Text
        };

        // Validação na Model conforme solicitado
        if (novoUser.Validar(out string erro))
        {
            try
            {
                DatabaseService.Instance.CadastrarUsuario(novoUser);
                await DisplayAlert("Sucesso", "Usuário cadastrado!", "OK");
                await Navigation.PopAsync(); // Volta para o Login
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }
        else
        {
            await DisplayAlert("Atenção", erro, "OK");
        }
    }
}