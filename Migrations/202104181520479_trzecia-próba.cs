namespace platformy_NET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class trzeciapróba : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ImageSPs", "Artist_id", "dbo.Artists");
            DropForeignKey("dbo.Artists", "SpotifyAlbum_ID", "dbo.SpotifyAlbums");
            DropIndex("dbo.Artists", new[] { "SpotifyAlbum_ID" });
            DropIndex("dbo.ImageSPs", new[] { "Artist_id" });
            DropTable("dbo.Artists");
            DropTable("dbo.ImageSPs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ImageSPs",
                c => new
                    {
                        width = c.Int(nullable: false, identity: true),
                        url = c.String(),
                        height = c.Int(nullable: false),
                        Artist_id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.width);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        external_urls_spotify = c.String(),
                        followers_total = c.Int(nullable: false),
                        href = c.String(),
                        name = c.String(),
                        popularity = c.Int(nullable: false),
                        type = c.String(),
                        uri = c.String(),
                        SpotifyAlbum_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id);
            
            CreateIndex("dbo.ImageSPs", "Artist_id");
            CreateIndex("dbo.Artists", "SpotifyAlbum_ID");
            AddForeignKey("dbo.Artists", "SpotifyAlbum_ID", "dbo.SpotifyAlbums", "ID");
            AddForeignKey("dbo.ImageSPs", "Artist_id", "dbo.Artists", "id");
        }
    }
}
