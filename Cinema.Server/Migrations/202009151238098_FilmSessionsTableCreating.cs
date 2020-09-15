namespace Cinema.Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FilmSessionsTableCreating : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FilmSessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        SeatsCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FilmSessions");
        }
    }
}
