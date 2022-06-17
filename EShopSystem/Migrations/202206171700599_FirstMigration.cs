namespace EShopSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductPrice = c.Single(nullable: false),
                        ProductStock = c.Single(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        CustomerMobile = c.String(),
                        CustomerPhone = c.String(),
                        CustomerEmail = c.String(),
                        CustomerAddress = c.String(),
                        CustomerBalance = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                        DepartmentIsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(),
                        EmployeeMobile = c.String(),
                        EmployeeEmail = c.String(),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Department", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.PaymentMode",
                c => new
                    {
                        PaymentModeId = c.Int(nullable: false, identity: true),
                        PaymentModeName = c.String(),
                        PaymentModeIsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentModeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Product", "CategoryId", "dbo.Category");
            DropIndex("dbo.Employee", new[] { "DepartmentId" });
            DropIndex("dbo.Product", new[] { "CategoryId" });
            DropTable("dbo.PaymentMode");
            DropTable("dbo.Employee");
            DropTable("dbo.Department");
            DropTable("dbo.Customer");
            DropTable("dbo.Product");
            DropTable("dbo.Category");
        }
    }
}
