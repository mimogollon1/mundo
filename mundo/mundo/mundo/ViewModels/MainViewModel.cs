namespace mundo.ViewModels
{
    using mundo.Models;
    using System.Collections.Generic;
    using ViewModels;

    public class MainViewModel
    {
        #region Properties
        public List<Pais> PaisList { get; set; }
        #endregion

        #region ViewMoels
        public LoginViewModel Login { get; set; }
        public PaisesViewModel Paises { get; set; }
        public PaisViewModel Pais { get; set; }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            this.Login = new LoginViewModel();
            Instance = this;
        }
        #endregion

        #region Singleton
        private static MainViewModel Instance;

        public static MainViewModel Getinstance()
        {
            if (Instance == null)
            {
                return new MainViewModel();
            }
            return Instance;
        }
        #endregion
    }
}
