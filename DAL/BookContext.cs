using DefaultMvcControllersAndAlternatives.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace DefaultMvcControllersAndAlternatives.DAL
{
    public class BookContext : DbContext
    {
        public BookContext() : base("BookDB")
        {
            Database.SetInitializer(new BookInitializer());
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}