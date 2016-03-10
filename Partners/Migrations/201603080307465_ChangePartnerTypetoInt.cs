namespace Partners.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePartnerTypetoInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Acc", "PremierTrainer", c => c.Int());
            AlterColumn("dbo.Acc", "Select", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Acc", "Select", c => c.String());
            AlterColumn("dbo.Acc", "PremierTrainer", c => c.String());
        }
    }
}
