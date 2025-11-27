using MauiAppPrevisao.Models;
using MauiAppPrevisao.Services;
using System;

namespace MauiAppPrevisao.Views;

public partial class PrevisaoView : ContentPage
{
    public PrevisaoView()
    {
        InitializeComponent();
    }

    private async void BtnBuscar_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtCidade.Text))
        {
            await DisplayAlert("Atenção", "Digite uma cidade.", "OK");
            return;
        }

        string cidade = txtCidade.Text;

        try
        {
            string resultado = await WeatherService.Instance.GetPrevisaoAsync(cidade);

            lblResultado.Text = $"{cidade}: {resultado}";
            frameResultado.IsVisible = true;

            HistoricoConsulta consulta = new HistoricoConsulta
            {
                UsuarioId = App.UsuarioLogado.Id, // NOVO: Salva o ID do dono
                Cidade = cidade,
                DataConsulta = DateTime.Now,
                ResultadoPrevisao = resultado
            };

            DatabaseService.Instance.RegistrarConsulta(consulta);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", "Falha ao buscar previsão: " + ex.Message, "OK");
        }
    }

    private async void BtnHistorico_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HistoricoView());
    }
}