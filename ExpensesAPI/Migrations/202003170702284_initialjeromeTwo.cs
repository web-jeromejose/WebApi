namespace ExpensesAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialjeromeTwo : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropTable("ExpensesSchema.Entry");
        }
    }
}
