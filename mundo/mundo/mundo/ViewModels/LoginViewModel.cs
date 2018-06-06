namespace mundo.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Services;
    using Xamarin.Forms;
    using System;
    using Views;
    using Helpers;

    public class LoginViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Properties
        public bool IsRemenber { get; set; }
        public String Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }
        public String Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }
        public bool IsLoading
        {
            get { return this.isLoading; }
            set { SetValue(ref this.isLoading, value); }
        }
        public bool IsEnable
        {
            get { return this.isEnable; }
            set { SetValue(ref this.isEnable, value); }
        }
        #endregion

        #region Attributes
        private String password;
        private String email;
        private bool isLoading;
        private bool isEnable;
        #endregion

        #region Contructors
        public LoginViewModel()
        {
            this.apiService = new ApiService();
            this.IsRemenber = true;
            this.isEnable = true;
            this.Email = "mogollon_11@hotmail.com";
            this.Password = "666666";
        }
        #endregion

         #region Commands
        public ICommand LoginComand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }


        private async void Login()
        {

            this.IsLoading = true;
            this.IsEnable = false;

            if (String.IsNullOrEmpty(this.Email))
            {
                this.IsLoading = false;
                this.IsEnable = true;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.EmailValidator,
                    Languages.Accept);
                return;
            }

            if (String.IsNullOrEmpty(this.Password))
            {
                this.IsLoading = false;
                this.IsEnable = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an password",
                   "Accept");
                return;
            }


            var conection = await this.apiService.CheckConnection();

            if (!conection.IsSuccess)
            {
                this.IsLoading = false;
                this.IsEnable = true;
                await Application.Current.MainPage.DisplayAlert(
                   "Error",
                   conection.Message,
                  "Accept");
                this.Password = string.Empty;
                return;
            }

            var token = await this.apiService.GetToken("https://mundoapi.azurewebsites.net"
                , this.Email
                , this.Password);

            if (token == null)
            {
                this.IsLoading = false;
                this.IsEnable = true;
                await Application.Current.MainPage.DisplayAlert(
                   "Error",
                   "something was wrong, please try agaun",
                  "Accept");
                this.Password = string.Empty;
                return;
            }

            if(string.IsNullOrEmpty(token.AccessToken))
            {
                this.IsLoading = false;
                this.IsEnable = true;
                await Application.Current.MainPage.DisplayAlert(
                   "Error",
                   token.ErrorDescription,
                  "Accept");
                this.Password = string.Empty;
                return;
            }

            var mainViewModel = MainViewModel.Getinstance();
            mainViewModel.Token = token;

            MainViewModel.Getinstance().Paises = new PaisesViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new PaisesPage());

            this.IsLoading = false;
            this.IsEnable = true;

            this.Password = string.Empty;
            this.Email = string.Empty;
        }
        #endregion
    }
}
