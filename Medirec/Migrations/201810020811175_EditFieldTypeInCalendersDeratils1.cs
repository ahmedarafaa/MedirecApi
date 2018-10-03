namespace Medirec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditFieldTypeInCalendersDeratils1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CalendersDetails", "TimeTo", c => c.Time(precision: 7));
            AlterColumn("dbo.CalendersDetails", "Date", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CalendersDetails", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.CalendersDetails", "TimeTo", c => c.Time(nullable: false, precision: 7));
        }
    }
}
