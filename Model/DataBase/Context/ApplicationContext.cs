using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CursProjects_GIt.Model.DataBase.Context
{
    public class ApplicationContext:DbContext
    {
        public DbSet<UsersModel> Users { get; set; } = null!;

        public ApplicationContext() 
        {
           

            Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=curs;Trusted_Connection=True;");
        }
    }
}
