namespace Mundo.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using Mundo.Services;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using Xamarin.Forms;

    class PaisesViewModel : BaseViewModel
    {
        #region Services;
        ApiService apiService;
        #endregion

        #region Attributes
        private ObservableCollection<Pais> paises;
        private bool isRefreshing;
        private string filter;
        private List<Pais> PaisList;
        #endregion

        #region Propperties
        public ObservableCollection<Pais> Paises
        {
            get { return this.paises; }
            set { SetValue(ref this.paises, value); }
        }
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public string Filter
        {
            get { return this.filter; }
            set { SetValue(ref this.filter, value); this.Search(); }
        }
        #endregion

        #region Constructors
        public PaisesViewModel()
        {
            this.apiService = new ApiService();
            this.LoadPaises();
        }
        #endregion

        #region Methods
        private async void LoadPaises()
        {
            this.IsRefreshing = true;
            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
            }

            var response = await this.apiService.GetList<Pais>(
                "http://restcountries.eu",
                "/rest",
                "/v2/all");
            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                return;
            }

            this.PaisList = (List<Pais>)response.Result;
            this.Paises = new ObservableCollection<Pais>(this.PaisList);
            this.IsRefreshing = false;
        }

        private void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.Paises = new ObservableCollection<Pais>(this.PaisList);
            }
            else
            {
                this.Paises = new ObservableCollection<Pais>(
                    this.PaisList.Where(P => 
                                            P.Name.ToLower().Contains(this.Filter.ToLower()) ||
                                            P.Capital.ToLower().Contains(this.Filter.ToLower())
                                            ));
            }
        }
        #endregion

        #region Commands
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadPaises);
            }
        }
        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        }
        #endregion

    }
}
