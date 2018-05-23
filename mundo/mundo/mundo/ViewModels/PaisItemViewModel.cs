namespace mundo.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Views;
    using Models;
    using System;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class PaisItemViewModel : Pais
    {
        #region Commands
        public ICommand SelectPaisCommand
        {
            get
            {
                return new RelayCommand(SelectPais);
            }
        }

        private async void SelectPais()
        {
            MainViewModel.Getinstance().Pais = new PaisViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new PaisPage());
        }
        #endregion
    }
}
