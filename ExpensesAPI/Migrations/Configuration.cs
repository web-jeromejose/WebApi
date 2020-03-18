namespace ExpensesAPI.Migrations
{
    using ExpensesAPI.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ExpensesAPI.Data.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ExpensesAPI.Data.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Entries.Add(
              new Models.Entry()
              {
                  Description = "test",
                  IsExpense = false,
                  Value = 3

              });




            var summerfields = new SummerField[]
     {
                new SummerField { Block = "Kim",     Lot = "Abercrombie",
                    StartDate = DateTime.Parse("1995-03-11") },
                new SummerField { Block = "Fadi",    Lot = "Fakhouri",
                    StartDate = DateTime.Parse("2002-07-06") },
                new SummerField { Block = "Roger",   Lot = "Harui",
                    StartDate = DateTime.Parse("1998-07-01") },
                new SummerField { Block = "Candace", Lot = "Kapoor",
                    StartDate = DateTime.Parse("2001-01-15") },
                new SummerField { Block = "Roger",   Lot = "Zheng", StartDate = DateTime.Parse("2004-02-12") }
     };

            

            try
            {

                foreach (SummerField i in summerfields)
                {
                    context.SummerField.Add(i);
                }
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                            ve.PropertyName,
                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                            ve.ErrorMessage);
                    }
                }
                throw;

            }


            var officeAssignments = new OfficeAssignment[]
           {
                new OfficeAssignment { OfficeAssignmentId = summerfields.Single( i => i.Lot == "Abercrombie").Id, Location = "Abercrombie 17"   },
                new OfficeAssignment { OfficeAssignmentId = summerfields.Single( i => i.Lot == "Fakhouri").Id, Location = "Smith 17"   },
                new OfficeAssignment {
                    OfficeAssignmentId = summerfields.Single( i => i.Lot == "Harui").Id, Location = "Gowan 27" },
                new OfficeAssignment {
                    OfficeAssignmentId = summerfields.Single( i => i.Lot == "Kapoor").Id, Location = "Thompson 304" },

                new OfficeAssignment {
                    OfficeAssignmentId = summerfields.Single(i => i.Lot == "Zheng").Id, Location = "Zheng House"

                }
           };


            try
            {

                foreach (OfficeAssignment o in officeAssignments)
                {
                    context.OfficeAssignments.Add(o);
                }
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                            ve.PropertyName,
                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                            ve.ErrorMessage);
                    }
                }
                throw;
            }

           // var students = new Student[] {
           //     new Student { Name = "MArian" },
           //     new Student { Name = "Jerome" },
           //};
           // foreach (Student ia in students)
           // {
           //     context.Students.Add(ia);
           // }
           // context.SaveChanges();




        }
    }
}
