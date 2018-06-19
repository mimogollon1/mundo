
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace mundo
{
    using mundo.Helpers;
    using mundo.ViewModels;
    using Views;
    public partial class App : Application
	{
        #region Peoperties
        public static NavigationPage Navigator { get; internal set; }
        #endregion

        #region Constructors
        public App()
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Settings.Token))
            {
                this.MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                var mainViewModel = MainViewModel.Getinstance();
                mainViewModel.Token = Settings.Token;
                mainViewModel.TokenType = Settings.TokenType;
                mainViewModel.Paises = new PaisesViewModel();
                this.MainPage = new MasterPage();
            }
           
        }
        #endregion

        #region Methods
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        } 
        #endregion
    }
}
