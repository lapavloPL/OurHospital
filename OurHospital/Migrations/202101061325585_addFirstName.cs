namespace OurHospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFirstName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "PeselNumber", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "PWZNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "PWZNumber");
            DropColumn("dbo.AspNetUsers", "PeselNumber");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
