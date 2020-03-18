namespace ExpensesAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class oneToMany : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Student", "CurrentGrade_GradeId", "dbo.Grade");
            DropIndex("dbo.Student", new[] { "CurrentGrade_GradeId" });
            DropTable("dbo.Student");
            DropTable("dbo.Grade");
        }
    }
}
