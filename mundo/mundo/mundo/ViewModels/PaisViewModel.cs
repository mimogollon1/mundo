
namespace mundo.ViewModels
{
    using Models;
    public class PaisViewModel
    {
        #region Properties
        public Pais Pais { get; set; }
        #endregion

        #region Constructors
        public PaisViewModel(Pais pais)
        {
            this.Pais = pais;
        } 
        #endregion
    }
}
