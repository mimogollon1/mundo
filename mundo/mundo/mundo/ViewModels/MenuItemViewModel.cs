namespace mundo.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using mundo.Helpers;
    using mundo.Views;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class MenuItemViewModel
    {
        #region Properties
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Pagename { get; set; }

        #endregion

        #region Commands
        public ICommand NavigateCommand
        {
            get
            {
                return new RelayCommand(Navigate);
            }
        }

        #endregion

        #region Methos
        void Navigate()
        {
            if (this.Pagename == "LoginPage")
            {
                Settings.Token = string.Empty;
                Settings.TokenType = string.Empty;
                var mainViewModel = MainViewModel.Getinstance();
                mainViewModel.Token = string.Empty;
                mainViewModel.TokenType = string.Empty;
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
    }

        #endregion
    }

}
