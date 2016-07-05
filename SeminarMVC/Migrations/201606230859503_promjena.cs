namespace SeminarMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class promjena : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restorans", "Zvez", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restorans", "Zvez");
        }
    }
}
