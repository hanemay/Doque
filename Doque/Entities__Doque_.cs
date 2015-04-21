using System.Data.Entity;
using Doque.Models;

namespace Doque
{
    public class Entities__Doque_ : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<Doque.Entities__Doque_>());

        public Entities__Doque_() : base("name=Entities__Doque_")
        {
        }

        public DbSet<Organization> Organizations { get; set; }
    }
}
