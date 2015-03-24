namespace DataApp.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Checks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AddedOn = c.DateTime(nullable: false),
                        Notes = c.String(),
                        TransactionAccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CheckTransactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Notes = c.String(),
                        VoucherId = c.Int(nullable: false),
                        CheckId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Checks", t => t.CheckId, cascadeDelete: true)
                .ForeignKey("dbo.Vouchers", t => t.VoucherId, cascadeDelete: true)
                .Index(t => t.VoucherId)
                .Index(t => t.CheckId);
            
            CreateTable(
                "dbo.Vouchers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsExpense = c.Boolean(nullable: false),
                        AddedOn = c.DateTime(nullable: false),
                        IssuedOn = c.DateTime(nullable: false),
                        Notes = c.String(),
                        TransactionAccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VoucherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vouchers", t => t.VoucherId, cascadeDelete: true)
                .Index(t => t.VoucherId);
            
            CreateTable(
                "dbo.ExpenseItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseDate = c.DateTime(nullable: false),
                        Notes = c.String(),
                        ORNumber = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Category = c.Int(nullable: false),
                        ExpenseId = c.Int(nullable: false),
                        TransactionAccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Expenses", t => t.ExpenseId, cascadeDelete: true)
                .Index(t => t.ExpenseId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Notes = c.String(),
                        ExpenseItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExpenseItems", t => t.ExpenseItemId, cascadeDelete: true)
                .Index(t => t.ExpenseItemId);
            
            CreateTable(
                "dbo.TransactionAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Notes = c.String(),
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
            DropForeignKey("dbo.Expenses", "VoucherId", "dbo.Vouchers");
            DropForeignKey("dbo.Projects", "ExpenseItemId", "dbo.ExpenseItems");
            DropForeignKey("dbo.ExpenseItems", "ExpenseId", "dbo.Expenses");
            DropForeignKey("dbo.CheckTransactions", "VoucherId", "dbo.Vouchers");
            DropForeignKey("dbo.CheckTransactions", "CheckId", "dbo.Checks");
            DropIndex("dbo.Projects", new[] { "ExpenseItemId" });
            DropIndex("dbo.ExpenseItems", new[] { "ExpenseId" });
            DropIndex("dbo.Expenses", new[] { "VoucherId" });
            DropIndex("dbo.CheckTransactions", new[] { "CheckId" });
            DropIndex("dbo.CheckTransactions", new[] { "VoucherId" });
            DropTable("dbo.Users");
            DropTable("dbo.TransactionAccounts");
            DropTable("dbo.Projects");
            DropTable("dbo.ExpenseItems");
            DropTable("dbo.Expenses");
            DropTable("dbo.Vouchers");
            DropTable("dbo.CheckTransactions");
            DropTable("dbo.Checks");
        }
    }
}
