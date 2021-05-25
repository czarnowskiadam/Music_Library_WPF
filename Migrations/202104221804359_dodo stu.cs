namespace platformy_NET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dodostu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SocialStatus",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Date = c.DateTime(nullable: false),
                        StatusText = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.SpotifyAlbums", "Artist", c => c.String());
            DropColumn("dbo.SpotifyAlbums", "Artists");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SpotifyAlbums", "Artists", c => c.String());
            DropColumn("dbo.SpotifyAlbums", "Artist");
            DropTable("dbo.SocialStatus");
        }
    }
}
