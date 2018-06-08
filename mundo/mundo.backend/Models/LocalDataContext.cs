namespace mundo.backend.Models
{
    using Domain;

    public class LocalDataContext : DataContext
    {
        public System.Data.Entity.DbSet<mundo.Domain.User> Users { get; set; }
    }
}