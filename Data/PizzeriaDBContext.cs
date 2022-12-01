using la_mia_pizzeria_model.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_model.Data
{
    public class PizzeriaDbContext : IdentityDbContext<IdentityUser>
    {
        private static PizzeriaDbContext _instance;
        public static PizzeriaDbContext Instance
        {
            get { return _instance ?? (_instance = new PizzeriaDbContext()); }
        }
        public DbSet<Pizza> Pizze { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Message> Messages { get; set; }
        public PizzeriaDbContext()
        {
        }

        public PizzeriaDbContext(DbContextOptions<PizzeriaDbContext> options): base(options)
        {

            //optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=db_pizzeriamodel;Integrated Security=True;Encrypt=false;");

        }

 

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}