
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace mundo
{
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

            //this.MainPage = new NavigationPage(new LoginPage());
            this.MainPage = new MasterPage();
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
