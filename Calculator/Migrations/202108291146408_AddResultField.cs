namespace Calculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddResultField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Results", "result", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Results", "result");
        }
    }
}
