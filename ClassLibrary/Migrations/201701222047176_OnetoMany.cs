namespace ClassLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OnetoMany : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GeneralTopics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TopicName = c.String(),
                        ProfileID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProfileDet", t => t.ProfileID, cascadeDelete: true)
                .Index(t => t.ProfileID);
            
            CreateTable(
                "dbo.ProfileDet",
                c => new
                    {
                        ProfileID = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                        ItemDescription = c.String(),
                        ItemType = c.String(),
                        Gender = c.Int(nullable: false),
                        ItemImage = c.Binary(),
                    })
                .PrimaryKey(t => t.ProfileID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GeneralTopics", "ProfileID", "dbo.ProfileDet");
            DropIndex("dbo.GeneralTopics", new[] { "ProfileID" });
            DropTable("dbo.ProfileDet");
            DropTable("dbo.GeneralTopics");
        }
    }
}
