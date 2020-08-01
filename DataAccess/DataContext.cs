using DataAccess.Models;
using System.Data.Entity;


namespace DataAccess
{
    public class DataContext: DbContext
    {
        public DataContext():base("DataContext")
        {
            Database.SetInitializer(new Inicializator());
        }
        public DbSet<ChildCardModel> ChildCards { get; set; }
        public DbSet<PictureModel> Pictures { get; set; }
       
    }
}
