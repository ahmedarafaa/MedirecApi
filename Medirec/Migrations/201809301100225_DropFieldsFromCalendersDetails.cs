namespace Medirec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropFieldsFromCalendersDetails : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CalendersDetails", "TimeFrom");
            DropColumn("dbo.CalendersDetails", "TimeTo");
            DropColumn("dbo.CalendersDetails", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CalendersDetails", "Date", c => c.DateTime());
            AddColumn("dbo.CalendersDetails", "TimeTo", c => c.Time(precision: 7));
            AddColumn("dbo.CalendersDetails", "TimeFrom", c => c.Time(precision: 7));
        }
    }
}
