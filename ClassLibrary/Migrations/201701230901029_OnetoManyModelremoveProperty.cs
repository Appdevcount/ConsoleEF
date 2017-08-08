namespace ClassLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OnetoManyModelremoveProperty : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProfileDet", "ItemType1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProfileDet", "ItemType1", c => c.String());
        }
    }
}
