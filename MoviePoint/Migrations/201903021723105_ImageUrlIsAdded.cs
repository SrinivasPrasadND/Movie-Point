namespace MoviePoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageUrlIsAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actors", "ImageUrl", c => c.String());
            AddColumn("dbo.Movies", "ImageUrl", c => c.String());
            AddColumn("dbo.Producers", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Producers", "ImageUrl");
            DropColumn("dbo.Movies", "ImageUrl");
            DropColumn("dbo.Actors", "ImageUrl");
        }
    }
}
