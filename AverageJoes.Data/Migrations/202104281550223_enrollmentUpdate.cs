namespace AverageJoes.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enrollmentUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Enrollment", "OwnerID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Enrollment", "OwnerID");
        }
    }
}
