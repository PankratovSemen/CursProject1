using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CursProjects_GIt.Model.DataBase.Context
{
    public class ShareHoldersContext : DbContext
    {
        
        public DbSet<ShareHolders> ShareHolders { get; set; } = null!;
        

        public ShareHoldersContext()
        {


            Database.EnsureCreated();
           
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=curs;Trusted_Connection=True;");
        }
    }
}
