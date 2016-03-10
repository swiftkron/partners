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
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        City = c.String(),
                        YearCertified = c.String(),
                        PremierTrainer = c.String(),
                        Select = c.String(),
                    })
                .PrimaryKey(t => t.AccID)
                .ForeignKey("dbo.Company", t => t.CompanyID, cascadeDelete: true)
                .ForeignKey("dbo.State", t => t.StateID, cascadeDelete: true)
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
                .ForeignKey("dbo.Company", t => t.CompanyID, cascadeDelete: true)
                .ForeignKey("dbo.State", t => t.StateID, cascadeDelete: true)
                .Index(t => t.CompanyID)
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
                .ForeignKey("dbo.Country", t => t.CountryID, cascadeDelete: true)
                .Index(t => t.CountryID);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        CountryID = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                    })
                .PrimaryKey(t => t.CountryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Acc", "StateID", "dbo.State");
            DropForeignKey("dbo.Acc", "CompanyID", "dbo.Company");
            DropForeignKey("dbo.Unit", "StateID", "dbo.State");
            DropForeignKey("dbo.State", "CountryID", "dbo.Country");
            DropForeignKey("dbo.Unit", "CompanyID", "dbo.Company");
            DropIndex("dbo.State", new[] { "CountryID" });
            DropIndex("dbo.Unit", new[] { "StateID" });
            DropIndex("dbo.Unit", new[] { "CompanyID" });
            DropIndex("dbo.Acc", new[] { "StateID" });
            DropIndex("dbo.Acc", new[] { "CompanyID" });
            DropTable("dbo.Country");
            DropTable("dbo.State");
            DropTable("dbo.Unit");
            DropTable("dbo.Company");
            DropTable("dbo.Acc");
        }
    }
}
