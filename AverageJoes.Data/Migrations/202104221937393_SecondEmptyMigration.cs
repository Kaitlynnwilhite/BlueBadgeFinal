namespace AverageJoes.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondEmptyMigration : DbMigration
    {
        public override void Up()
        {
         ////   DropForeignKey("dbo.Activity", "UserID", "dbo.Users");
         //   DropIndex("dbo.Activity", new[] { "UserID" });
         //   AlterColumn("dbo.Activity", "UserID", c => c.Int());
         //   CreateIndex("dbo.Activity", "UserID");
         //   AddForeignKey("dbo.Activity", "UserID", "dbo.Users", "ID");
        }
        
        public override void Down()
        {
        //    DropForeignKey("dbo.Activity", "UserID", "dbo.Users");
        //    DropIndex("dbo.Activity", new[] { "UserID" });
        //    AlterColumn("dbo.Activity", "UserID", c => c.Int(nullable: false));
        //    CreateIndex("dbo.Activity", "UserID");
        //    AddForeignKey("dbo.Activity", "UserID", "dbo.Users", "ID", cascadeDelete: true);
        }
    }
}
