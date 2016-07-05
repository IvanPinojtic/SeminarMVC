namespace SeminarMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Grads",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Drzava = c.String(nullable: false),
                        Ime = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Restorans",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Adresa = c.String(),
                        Kapacitet = c.Int(nullable: false),
                        GradID = c.Int(nullable: false),
                        Ime = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Grads", t => t.GradID, cascadeDelete: false)
                .Index(t => t.GradID);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Cijena = c.Int(nullable: false),
                        RestoranID = c.Int(nullable: false),
                        Ime = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Restorans", t => t.RestoranID, cascadeDelete: false)
                .Index(t => t.RestoranID);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Pozicija = c.String(nullable: false),
                        Zvez = c.Int(nullable: false),
                        RestoranID = c.Int(nullable: false),
                        Ime = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Restorans", t => t.RestoranID, cascadeDelete: false)
                .Index(t => t.RestoranID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Staffs", "RestoranID", "dbo.Restorans");
            DropForeignKey("dbo.Menus", "RestoranID", "dbo.Restorans");
            DropForeignKey("dbo.Restorans", "GradID", "dbo.Grads");
            DropIndex("dbo.Staffs", new[] { "RestoranID" });
            DropIndex("dbo.Menus", new[] { "RestoranID" });
            DropIndex("dbo.Restorans", new[] { "GradID" });
            DropTable("dbo.Staffs");
            DropTable("dbo.Menus");
            DropTable("dbo.Restorans");
            DropTable("dbo.Grads");
        }
    }
}
