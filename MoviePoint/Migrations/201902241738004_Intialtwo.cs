namespace MoviePoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Intialtwo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Producers",
                c => new
                    {
                        ProducerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Bio = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProducerId);
            
            AddColumn("dbo.Movies", "ProducerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "ProducerId");
            AddForeignKey("dbo.Movies", "ProducerId", "dbo.Producers", "ProducerId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "ProducerId", "dbo.Producers");
            DropIndex("dbo.Movies", new[] { "ProducerId" });
            DropColumn("dbo.Movies", "ProducerId");
            DropTable("dbo.Producers");
        }
    }
}
