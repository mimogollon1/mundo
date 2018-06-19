namespace mundo.ViewModels
{
    using mundo.Models;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using ViewModels;

    public class MainViewModel
    {
        #region Properties
        public List<Pais> PaisList { get; set; }
        public string Token { get; set; }
        public string TokenType { get; set; }
        public ObservableCollection<MenuItemViewModel> Menus { get; set; }
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
            this.LoadMenu();
        }
        #endregion

        #region Method
        private void LoadMenu()
        {
            this.Menus = new ObservableCollection<MenuItemViewModel>();
            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "config",
                Pagename = "MyProfilePage",
                Title = " My Profile"
            });
            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "statics",
                Pagename = "StaticsPage",
                Title = "Statics"
            });
            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "exit",
                Pagename = "LoginPage",
                Title = "LogOut"
            });
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
