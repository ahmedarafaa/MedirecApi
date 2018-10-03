namespace Medirec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropAddFieldsCalendersDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CalendersDetails", "TimeFrom", c => c.String());
            AddColumn("dbo.CalendersDetails", "TimeTo", c => c.String());
            AddColumn("dbo.CalendersDetails", "Date", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CalendersDetails", "Date");
            DropColumn("dbo.CalendersDetails", "TimeTo");
            DropColumn("dbo.CalendersDetails", "TimeFrom");
        }
    }
}
