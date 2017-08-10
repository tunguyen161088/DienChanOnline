namespace DienChanOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerAndForm : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 50),
                        BirthDay = c.DateTime(nullable: false),
                        Job = c.String(nullable: false),
                        Address1 = c.String(nullable: false),
                        Address2 = c.String(),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Zip = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        Purpose = c.String(nullable: false),
                        FormId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Forms", t => t.FormId, cascadeDelete: true)
                .Index(t => t.FormId);
            
            CreateTable(
                "dbo.Forms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        TitleFr = c.String(nullable: false),
                        TitleVn = c.String(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "FormId", "dbo.Forms");
            DropIndex("dbo.Customers", new[] { "FormId" });
            DropTable("dbo.Forms");
            DropTable("dbo.Customers");
        }
    }
}
