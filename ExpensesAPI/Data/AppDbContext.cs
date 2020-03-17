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
        public AppDbContext() : base("name=ExpensesDb")
        {

        }
        public DbSet<Entry> Entries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // set this to remove the 's' word after the model.. Auto by EF ex. employees on Employee model class
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Entity<Entry>().ToTable("Employee");//one by one
           modelBuilder.Entity<Entry>().ToTable("Entry", "ExpensesSchema"); //with SCHEMA
        }
        //public AppDbContext()
        //   : base()
        //{
        //    string encrypted = System.Configuration.ConfigurationManager.ConnectionStrings["SghDbContextConnString"].ToString();
        //    string decrypted = EncryDecry.Decrypt(encrypted, true);
        //    Database.Connection.ConnectionString = decrypted;
        //    // Database.CreateIfNotExists();
        //}





    }
}