using MauiAppPrevisao.Services;

namespace MauiAppPrevisao.Views;

public partial class HistoricoView : ContentPage
{
    public HistoricoView()
    {
        InitializeComponent();
        dtpInicio.Date = DateTime.Now.AddDays(-30);
        dtpFim.Date = DateTime.Now;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        CarregarDados();
    }

    private void CarregarDados()
    {
        // NOVO: Passa o ID do usuário logado (App.UsuarioLogado.Id)
        var lista = DatabaseService.Instance.FiltrarHistorico(
            App.UsuarioLogado.Id,
            dtpInicio.Date,
            dtpFim.Date
        );

        collectionHistorico.ItemsSource = lista;
    }

    private void BtnFiltrar_Clicked(object sender, EventArgs e)
    {
        CarregarDados();
    }
}