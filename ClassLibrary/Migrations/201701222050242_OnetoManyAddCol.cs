namespace ClassLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OnetoManyAddCol : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProfileDet", "ItemDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProfileDet", "ItemDescription");
        }
    }
}
