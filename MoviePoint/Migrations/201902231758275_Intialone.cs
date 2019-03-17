namespace MoviePoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Intialone : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        ActorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Bio = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ActorId);
            
            CreateTable(
                "dbo.ActorToMovies",
                c => new
                    {
                        ActorToMovieId = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        ActorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ActorToMovieId)
                .ForeignKey("dbo.Actors", t => t.ActorId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.ActorId);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        YearOfRelease = c.String(),
                    })
                .PrimaryKey(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ActorToMovies", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.ActorToMovies", "ActorId", "dbo.Actors");
            DropIndex("dbo.ActorToMovies", new[] { "ActorId" });
            DropIndex("dbo.ActorToMovies", new[] { "MovieId" });
            DropTable("dbo.Movies");
            DropTable("dbo.ActorToMovies");
            DropTable("dbo.Actors");
        }
    }
}
