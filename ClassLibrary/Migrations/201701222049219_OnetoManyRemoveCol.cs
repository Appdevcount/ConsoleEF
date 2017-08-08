namespace ClassLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OnetoManyRemoveCol : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProfileDet", "ItemDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProfileDet", "ItemDescription", c => c.String());
        }
    }
}
