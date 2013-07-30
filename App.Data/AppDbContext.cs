using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using App.Model;
using App.Data.SampleData;

namespace App.Data
{
    public class AppDbContext : DbContext 
    {
        // ToDo: Move Initializer to Global.asax; don't want dependence on SampleData
        static AppDbContext()
        {
            Database.SetInitializer(new AppDatabaseInitializer());
        }

        public AppDbContext()
            : base(nameOrConnectionString: "App") {
                Database.SetInitializer(new AppDatabaseInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Use singular table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //add for each model:
            modelBuilder.Configurations.Add(new GameConfiguration());
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Console> Consoles { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SocialLink> SocialLinks { get; set; }
        public DbSet<Follow> Following { get; set; }
        public DbSet<Gettinlist> Gettinlists { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }
    }
}
