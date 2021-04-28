namespace AverageJoes.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnrollmentStuff : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Activity", "Users_ID", "dbo.Users");
            DropIndex("dbo.Activity", new[] { "Users_ID" });
            CreateTable(
                "dbo.Enrollment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        ActivityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Activity", t => t.ActivityID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.ActivityID);
            
            DropColumn("dbo.Activity", "Users_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Activity", "Users_ID", c => c.Int());
            DropForeignKey("dbo.Enrollment", "UserID", "dbo.Users");
            DropForeignKey("dbo.Enrollment", "ActivityID", "dbo.Activity");
            DropIndex("dbo.Enrollment", new[] { "ActivityID" });
            DropIndex("dbo.Enrollment", new[] { "UserID" });
            DropTable("dbo.Enrollment");
            CreateIndex("dbo.Activity", "Users_ID");
            AddForeignKey("dbo.Activity", "Users_ID", "dbo.Users", "ID");
        }
    }
}
