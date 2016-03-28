namespace Partners.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Acc",
                c => new
                    {
                        AccID = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        StateID = c.Int(nullable: false),
                        CityID = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        YearCertified = c.String(),
                        PremierTrainer = c.Int(),
                        Select = c.Int(),
                    })
                .PrimaryKey(t => t.AccID)
                .ForeignKey("dbo.City", t => t.CityID)
                .ForeignKey("dbo.Company", t => t.CompanyID)
                .ForeignKey("dbo.State", t => t.StateID)
                .Index(t => t.CompanyID)
                .Index(t => t.StateID)
                .Index(t => t.CityID);
            
            CreateTable(
                "dbo.City",
                c => new
                    {
                        CityID = c.Int(nullable: false, identity: true),
                        StateID = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CityID)
                .ForeignKey("dbo.State", t => t.StateID)
                .Index(t => t.StateID);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        StateID = c.Int(nullable: false, identity: true),
                        CountryID = c.Int(nullable: false),
                        Abbr = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.StateID)
                .ForeignKey("dbo.Country", t => t.CountryID)
                .Index(t => t.CountryID);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        CountryID = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                    })
                .PrimaryKey(t => t.CountryID);
            
            CreateTable(
                "dbo.Unit",
                c => new
                    {
                        UnitID = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        StateID = c.Int(nullable: false),
                        UUM = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UnitID)
                .ForeignKey("dbo.Company", t => t.CompanyID)
                .ForeignKey("dbo.State", t => t.StateID)
                .Index(t => t.CompanyID)
                .Index(t => t.StateID);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        CompanyID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Website = c.String(),
                        Phone = c.String(),
                        Tier = c.String(),
                    })
                .PrimaryKey(t => t.CompanyID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Acc", "StateID", "dbo.State");
            DropForeignKey("dbo.Acc", "CompanyID", "dbo.Company");
            DropForeignKey("dbo.Acc", "CityID", "dbo.City");
            DropForeignKey("dbo.City", "StateID", "dbo.State");
            DropForeignKey("dbo.Unit", "StateID", "dbo.State");
            DropForeignKey("dbo.Unit", "CompanyID", "dbo.Company");
            DropForeignKey("dbo.State", "CountryID", "dbo.Country");
            DropIndex("dbo.Unit", new[] { "StateID" });
            DropIndex("dbo.Unit", new[] { "CompanyID" });
            DropIndex("dbo.State", new[] { "CountryID" });
            DropIndex("dbo.City", new[] { "StateID" });
            DropIndex("dbo.Acc", new[] { "CityID" });
            DropIndex("dbo.Acc", new[] { "StateID" });
            DropIndex("dbo.Acc", new[] { "CompanyID" });
            DropTable("dbo.Company");
            DropTable("dbo.Unit");
            DropTable("dbo.Country");
            DropTable("dbo.State");
            DropTable("dbo.City");
            DropTable("dbo.Acc");
        }
    }
}
