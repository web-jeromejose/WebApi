namespace ExpensesAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testnew : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.BookId);
            
            CreateTable(
                "dbo.BookCategory",
                c => new
                    {
                        BookId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookId, t.CategoryId })
                .ForeignKey("dbo.Book", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "ExpensesSchema.Entry",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        IsExpense = c.Boolean(nullable: false),
                        Value = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Grade",
                c => new
                    {
                        GradeId = c.Int(nullable: false, identity: true),
                        GradeName = c.String(),
                        Section = c.String(),
                    })
                .PrimaryKey(t => t.GradeId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CurrentGradeId = c.Int(nullable: false),
                        CurrentGrade_GradeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grade", t => t.CurrentGrade_GradeId, cascadeDelete: true)
                .Index(t => t.CurrentGrade_GradeId);
            
            CreateTable(
                "ExpensesSchema.OfficeAssignment",
                c => new
                    {
                        OfficeAssignmentId = c.Int(nullable: false),
                        Location = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.OfficeAssignmentId)
                .ForeignKey("ExpensesSchema.SummerField", t => t.OfficeAssignmentId)
                .Index(t => t.OfficeAssignmentId);
            
            CreateTable(
                "ExpensesSchema.SummerField",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Block = c.String(nullable: false, maxLength: 50),
                        Lot = c.String(),
                        Owner = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        Grade = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("ExpensesSchema.OfficeAssignment", "OfficeAssignmentId", "ExpensesSchema.SummerField");
            DropForeignKey("dbo.Student", "CurrentGrade_GradeId", "dbo.Grade");
            DropForeignKey("dbo.BookCategory", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.BookCategory", "BookId", "dbo.Book");
            DropIndex("ExpensesSchema.OfficeAssignment", new[] { "OfficeAssignmentId" });
            DropIndex("dbo.Student", new[] { "CurrentGrade_GradeId" });
            DropIndex("dbo.BookCategory", new[] { "CategoryId" });
            DropIndex("dbo.BookCategory", new[] { "BookId" });
            DropTable("ExpensesSchema.SummerField");
            DropTable("ExpensesSchema.OfficeAssignment");
            DropTable("dbo.Student");
            DropTable("dbo.Grade");
            DropTable("ExpensesSchema.Entry");
            DropTable("dbo.Category");
            DropTable("dbo.BookCategory");
            DropTable("dbo.Book");
        }
    }
}
