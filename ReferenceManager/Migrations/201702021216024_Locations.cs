namespace ReferenceManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Locations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        QuickName = c.String(),
                        Room = c.String(),
                        Shelf = c.String(),
                    })
                .PrimaryKey(t => t.LocationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Locations");
        }
    }
}
