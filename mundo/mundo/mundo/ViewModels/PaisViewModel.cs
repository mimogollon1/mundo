
namespace mundo.ViewModels
{
    using Models;
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class PaisViewModel : BaseViewModel
    {
        #region Attributes
        private ObservableCollection<Border> borders;
        private ObservableCollection<Currency> currencies;
        private ObservableCollection<Language> languages;
        #endregion

        #region Properties
        public Pais Pais { get; set; }

        public ObservableCollection<Border> Borders
        {
            get { return this.borders; }
            set { SetValue(ref this.borders, value); }
        }

        public ObservableCollection<Currency> Currencies
        {
            get { return this.currencies; }
            set { SetValue(ref this.currencies, value); }
        }

        public ObservableCollection<Language> Languages
        {
            get { return this.languages; }
            set { SetValue(ref this.languages, value); }
        }
        #endregion

        #region Constructors
        public PaisViewModel(Pais pais)
        {
            this.Pais = pais;
            this.LoadBorders();
            this.Currencies = new ObservableCollection<Currency>(this.Pais.Currencies);
            this.Languages = new ObservableCollection<Language>(this.Pais.Languages);
        }
        #endregion

        #region Methods
        private void LoadBorders()
        {
            this.Borders = new ObservableCollection<Border>();
            foreach (var border in this.Pais.Borders)
            {
                var pais = MainViewModel.Getinstance().PaisList.
                        Where(p => p.Alpha3Code == border).
                        FirstOrDefault();
                if (pais != null)
                {
                    this.Borders.Add(new Border
                    {
                        Code = pais.Alpha3Code,
                        Name = pais.Name,
                    });
                }
            }
        }
        #endregion
    }
}
