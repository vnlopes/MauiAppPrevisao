using MauiAppPrevisao.Models; // Necessário para usar a classe Usuario

namespace MauiAppPrevisao
{
    public partial class App : Application
    {
        // NOVO: Guarda o usuário logado para usar no app todo
        public static Usuario? UsuarioLogado { get; set; }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Views.LoginView());
        }
    }
}