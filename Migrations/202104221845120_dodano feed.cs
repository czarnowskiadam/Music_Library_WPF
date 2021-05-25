namespace platformy_NET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dodanofeed : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.SocialStatus");
            AlterColumn("dbo.SocialStatus", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.SocialStatus", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.SocialStatus");
            AlterColumn("dbo.SocialStatus", "ID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.SocialStatus", "ID");
        }
    }
}
