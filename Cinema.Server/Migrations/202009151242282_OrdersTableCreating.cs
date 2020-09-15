namespace Cinema.Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrdersTableCreating : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SeatsCount = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false),
                        FilmSessionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FilmSessions", t => t.FilmSessionId, cascadeDelete: true)
                .Index(t => t.FilmSessionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "FilmSessionId", "dbo.FilmSessions");
            DropIndex("dbo.Orders", new[] { "FilmSessionId" });
            DropTable("dbo.Orders");
        }
    }
}
