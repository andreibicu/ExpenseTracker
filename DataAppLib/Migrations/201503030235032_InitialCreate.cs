namespace DataApp.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Checks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IssuedOn = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Notes = c.String(),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CheckTransactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CheckId = c.Int(nullable: false),
                        VoucherId = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Checks", t => t.CheckId, cascadeDelete: true)
                .ForeignKey("dbo.Vouchers", t => t.VoucherId, cascadeDelete: true)
                .Index(t => t.CheckId)
                .Index(t => t.VoucherId);
            
            CreateTable(
                "dbo.Vouchers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountId = c.Int(nullable: false),
                        Notes = c.String(),
                        IssuedOn = c.String(),
                        AddedOn = c.String(),
                        Category = c.Int(nullable: false),
                        IsExpense = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CheckTransactions", "VoucherId", "dbo.Vouchers");
            DropForeignKey("dbo.CheckTransactions", "CheckId", "dbo.Checks");
            DropIndex("dbo.CheckTransactions", new[] { "VoucherId" });
            DropIndex("dbo.CheckTransactions", new[] { "CheckId" });
            DropTable("dbo.Users");
            DropTable("dbo.Vouchers");
            DropTable("dbo.CheckTransactions");
            DropTable("dbo.Checks");
            DropTable("dbo.Accounts");
        }
    }
}
