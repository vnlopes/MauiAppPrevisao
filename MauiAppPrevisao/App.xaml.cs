using MauiAppPrevisao.Models; 
namespace MauiAppPrevisao
{
    public partial class App : Application
    {

        public static Usuario? UsuarioLogado { get; set; }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Views.LoginView());
        }
    }
}