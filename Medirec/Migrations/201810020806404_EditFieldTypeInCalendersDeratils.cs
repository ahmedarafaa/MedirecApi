namespace Medirec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditFieldTypeInCalendersDeratils : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CalendersDetails", "TimeFrom", c => c.Time(precision: 7));
            AlterColumn("dbo.CalendersDetails", "TimeTo", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.CalendersDetails", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CalendersDetails", "Date", c => c.String());
            AlterColumn("dbo.CalendersDetails", "TimeTo", c => c.String());
            AlterColumn("dbo.CalendersDetails", "TimeFrom", c => c.String());
        }
    }
}
