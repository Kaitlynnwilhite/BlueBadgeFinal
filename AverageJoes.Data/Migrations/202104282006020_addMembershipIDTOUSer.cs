namespace AverageJoes.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMembershipIDTOUSer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "MembershipTypes", c => c.Int(nullable: false));
            DropColumn("dbo.Enrollment", "OwnerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Enrollment", "OwnerID", c => c.Guid(nullable: false));
            DropColumn("dbo.Users", "MembershipTypes");
        }
    }
}
