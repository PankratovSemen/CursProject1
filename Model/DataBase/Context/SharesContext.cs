using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CursProjects_GIt.Model.DataBase.Context
{
    public class SharesContext : DbContext
    {
        
        public DbSet<Share> Shares { get; set; } = null!;
        

        public SharesContext()
        {


            Database.EnsureCreated();
            
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=curs;Trusted_Connection=True;");
        }
    }
}
