namespace ExpensesAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatethissummerfield12 : DbMigration
    {
        public override void Up()
        {
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
            DropIndex("ExpensesSchema.OfficeAssignment", new[] { "OfficeAssignmentId" });
            DropTable("ExpensesSchema.SummerField");
            DropTable("ExpensesSchema.OfficeAssignment");
            DropTable("ExpensesSchema.Entry");
        }
    }
}
