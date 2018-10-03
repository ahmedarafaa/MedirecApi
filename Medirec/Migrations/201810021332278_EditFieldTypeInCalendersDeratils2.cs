namespace Medirec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditFieldTypeInCalendersDeratils2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CalendersDetails", "TimeFrom", c => c.DateTime());
            AlterColumn("dbo.CalendersDetails", "TimeTo", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CalendersDetails", "TimeTo", c => c.Time(precision: 7));
            AlterColumn("dbo.CalendersDetails", "TimeFrom", c => c.Time(precision: 7));
        }
    }
}
