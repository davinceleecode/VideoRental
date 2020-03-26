namespace VideoRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddPhone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Phone", c => c.Int(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Phone");
        }
    }
}
