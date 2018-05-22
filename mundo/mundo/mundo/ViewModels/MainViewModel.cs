namespace mundo.ViewModels
{
    using Mundo.ViewModels;

    class MainViewModel
    {
        #region ViewMoels
        public LoginViewModel Login { get; set; }
        public PaisesViewModel Paises { get; set; }
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
