
namespace MauiAppLogin4
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Defina temporariamente a MainPage como nula
            MainPage = null;

            // Execute a verificação de login após a inicialização
            CheckLoginStatus();
        }

        private async void CheckLoginStatus()
        {
            // Espera pela resposta do armazenamento seguro
            String? usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");

            // Define a MainPage com base na verificação de login
            if (usuario_logado == null)
            {
                MainPage = new Login();
            }
            else
            {
                MainPage = new Protegida();
            }
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow(activationState);
            window.Width = 400;
            window.Height = 700;
            return window;
        }
    }
}
