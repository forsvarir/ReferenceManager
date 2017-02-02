namespace ReferenceManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Publisher : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        PublisherId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PublisherId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Publishers");
        }
    }
}
