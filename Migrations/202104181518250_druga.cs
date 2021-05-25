namespace platformy_NET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class druga : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SimplifiedArtistObjects", "SimplifiedAlbumObject_id", "dbo.SimplifiedAlbumObjects");
            DropForeignKey("dbo.ImageSPs", "SimplifiedAlbumObject_id", "dbo.SimplifiedAlbumObjects");
            DropForeignKey("dbo.SpotifyTracks", "Album_id", "dbo.SimplifiedAlbumObjects");
            DropForeignKey("dbo.Artists", "SpotifyTrack_ID", "dbo.SpotifyTracks");
            DropIndex("dbo.Artists", new[] { "SpotifyTrack_ID" });
            DropIndex("dbo.ImageSPs", new[] { "SimplifiedAlbumObject_id" });
            DropIndex("dbo.SpotifyTracks", new[] { "Album_id" });
            DropIndex("dbo.SimplifiedArtistObjects", new[] { "SimplifiedAlbumObject_id" });
            DropColumn("dbo.Artists", "SpotifyTrack_ID");
            DropColumn("dbo.ImageSPs", "SimplifiedAlbumObject_id");
            DropTable("dbo.SpotifyTracks");
            DropTable("dbo.SimplifiedAlbumObjects");
            DropTable("dbo.SimplifiedArtistObjects");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SimplifiedArtistObjects",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        external_urls_spotify = c.String(),
                        href = c.String(),
                        name = c.String(),
                        type = c.String(),
                        uri = c.String(),
                        SimplifiedAlbumObject_id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.SimplifiedAlbumObjects",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        album_group = c.String(),
                        albym_type = c.String(),
                        external_urls_spotify = c.String(),
                        href = c.String(),
                        name = c.String(),
                        release_date = c.String(),
                        release_date_precision = c.String(),
                        restrictions_reason = c.String(),
                        type = c.String(),
                        uri = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.SpotifyTracks",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Popularity = c.Int(nullable: false),
                        Image = c.String(),
                        Album_id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.ImageSPs", "SimplifiedAlbumObject_id", c => c.String(maxLength: 128));
            AddColumn("dbo.Artists", "SpotifyTrack_ID", c => c.String(maxLength: 128));
            CreateIndex("dbo.SimplifiedArtistObjects", "SimplifiedAlbumObject_id");
            CreateIndex("dbo.SpotifyTracks", "Album_id");
            CreateIndex("dbo.ImageSPs", "SimplifiedAlbumObject_id");
            CreateIndex("dbo.Artists", "SpotifyTrack_ID");
            AddForeignKey("dbo.Artists", "SpotifyTrack_ID", "dbo.SpotifyTracks", "ID");
            AddForeignKey("dbo.SpotifyTracks", "Album_id", "dbo.SimplifiedAlbumObjects", "id");
            AddForeignKey("dbo.ImageSPs", "SimplifiedAlbumObject_id", "dbo.SimplifiedAlbumObjects", "id");
            AddForeignKey("dbo.SimplifiedArtistObjects", "SimplifiedAlbumObject_id", "dbo.SimplifiedAlbumObjects", "id");
        }
    }
}
