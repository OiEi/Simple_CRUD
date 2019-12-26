namespace DataAcces.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Companyid = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Companyid);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Phone = c.String(),
                        CompanyId = c.Int(),
                        PasportId = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .ForeignKey("dbo.Pasports", t => t.PasportId)
                .Index(t => t.CompanyId)
                .Index(t => t.PasportId);
            
            CreateTable(
                "dbo.Pasports",
                c => new
                    {
                        Pasportid = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Number = c.String(),
                    })
                .PrimaryKey(t => t.Pasportid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "PasportId", "dbo.Pasports");
            DropForeignKey("dbo.Employees", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Employees", new[] { "PasportId" });
            DropIndex("dbo.Employees", new[] { "CompanyId" });
            DropTable("dbo.Pasports");
            DropTable("dbo.Employees");
            DropTable("dbo.Companies");
        }
    }
}
