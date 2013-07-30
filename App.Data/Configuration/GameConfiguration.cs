using System.Data.Entity.ModelConfiguration;
using App.Model;

namespace App.Data
{
    public class GameConfiguration : EntityTypeConfiguration<Game>
    {
        public GameConfiguration()
        {
            //Games have many Consoles
            HasMany(c => c.Consoles);
        }
    }
}