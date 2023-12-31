﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CursProjects_GIt.Model.DataBase.Context
{
    public class ApplicationContext : DbContext
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
