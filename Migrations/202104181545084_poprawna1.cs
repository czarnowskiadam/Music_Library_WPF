namespace platformy_NET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class poprawna1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SpotifyTracks",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        album = c.String(),
                        artist = c.String(),
                        Name = c.String(),
                        Popularity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.SpotifyAlbums", "Artists", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SpotifyAlbums", "Artists");
            DropTable("dbo.SpotifyTracks");
        }
    }
}
