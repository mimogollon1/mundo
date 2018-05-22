namespace Mundo.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using System;
    using Mundo.Views;
    using mundo.ViewModels;

    class LoginViewModel : BaseViewModel
    {

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
            this.IsRemenber = true;
            this.isEnable = true;
            this.Email = "mogollon_11@hotmail.com";
            this.Password = "1234";
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
            if (String.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an email",
                   "Accept");
                return;
            }

            if (String.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an password",
                   "Accept");
                return;
            }
            this.isLoading = true;
            this.isEnable = false;
            if (this.Email != "mogollon_11@hotmail.com" || this.Password != "1234")
            {
                this.isLoading = false;
                this.isEnable = true;
                await Application.Current.MainPage.DisplayAlert(
                   "Error",
                   "Email or password incorrect",
                  "Accept");
                this.Password = string.Empty;
                return;
            }

            this.isLoading = false;
            this.isEnable = true;

            this.Password = string.Empty;
            this.Email = string.Empty;

            MainViewModel.Getinstance().Paises = new PaisesViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new PaisesPage());
        }
        #endregion
    }
}
