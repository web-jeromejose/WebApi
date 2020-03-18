using ExpensesAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ExpensesAPI.Data
{
    public class AppDbContext : DbContext
    {
        //public AppDbContext()
        //   : base()
        //{
        //    string encrypted = System.Configuration.ConfigurationManager.ConnectionStrings["SghDbContextConnString"].ToString();
        //    string decrypted = EncryDecry.Decrypt(encrypted, true);
        //    Database.Connection.ConnectionString = decrypted;
        //    // Database.CreateIfNotExists();
        //}
        public AppDbContext() : base("name=ExpensesDb")
        {

        }
        public DbSet<Entry> Entries { get; set; }

        //one to one
        public DbSet<SummerField> SummerField { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }

        //one to many
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<BookCategory> BookCategory { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Book> Book { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // set this to remove the 's' word after the model.. Auto by EF ex. employees on Employee model class
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Entity<Entry>().ToTable("Employee");//one by one
            modelBuilder.Entity<Entry>().ToTable("Entry", "ExpensesSchema"); //with SCHEMA
            modelBuilder.Entity<SummerField>().ToTable("SummerField", "ExpensesSchema");
      
            modelBuilder.Entity<OfficeAssignment>().ToTable("OfficeAssignment", "ExpensesSchema");

 

            //one to many
            modelBuilder.Entity<Grade>()
        .HasMany<Student>(g => g.Students)
        .WithRequired(s => s.CurrentGrade)
        .WillCascadeOnDelete();

            //many to many
            modelBuilder.Entity<BookCategory>().HasKey(bc => new { bc.BookId, bc.CategoryId });
            //modelBuilder.Entity<BookCategory>()
            //            .HasOne(bc => bc.Book)
            //            .WithMany(b => b.BookCategories)
            //            .HasForeignKey(bc => bc.BookId);
            //modelBuilder.Entity<BookCategory>()
            //            .HasOne(bc => bc.Category)
            //            .WithMany(c => c.BookCategories)
            //            .HasForeignKey(bc => bc.CategoryId);



        }
     





    }
}