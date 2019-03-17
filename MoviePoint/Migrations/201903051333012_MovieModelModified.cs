namespace MoviePoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieModelModified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "MovieUrl", c => c.String());
            AddColumn("dbo.Movies", "Language", c => c.String());
            AddColumn("dbo.Movies", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Description");
            DropColumn("dbo.Movies", "Language");
            DropColumn("dbo.Movies", "MovieUrl");
        }
    }
}
