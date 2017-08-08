namespace ClassLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OnetoManyModelNewProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProfileDet", "ItemType1", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProfileDet", "ItemType1");
        }
    }
}
