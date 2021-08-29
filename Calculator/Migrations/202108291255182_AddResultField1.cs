namespace Calculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddResultField1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Results", "result", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Results", "result", c => c.String());
        }
    }
}
