namespace DataApp.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelrefactoraddedcheckVoucherandexpense : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CheckTransactions", "CheckId", "dbo.Checks");
            DropForeignKey("dbo.CheckTransactions", "VoucherId", "dbo.Vouchers");
            DropForeignKey("dbo.ExpenseItems", "ExpenseId", "dbo.Expenses");
            DropForeignKey("dbo.ExpenseItems", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Expenses", "VoucherId", "dbo.Vouchers");
            DropIndex("dbo.CheckTransactions", new[] { "VoucherId" });
            DropIndex("dbo.CheckTransactions", new[] { "CheckId" });
            DropIndex("dbo.Expenses", new[] { "VoucherId" });
            DropIndex("dbo.ExpenseItems", new[] { "ExpenseId" });
            DropIndex("dbo.ExpenseItems", new[] { "ProjectId" });
            CreateTable(
                "dbo.CheckVouchers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DueDate = c.DateTime(nullable: false),
                        EntryDate = c.DateTime(nullable: false),
                        CheckNo = c.String(),
                        VoucherNo = c.String(),
                        Notes = c.String(),
                        PayeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Expenses", "PurchaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Expenses", "ORNumber", c => c.String());
            AddColumn("dbo.Expenses", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Expenses", "Category", c => c.Int(nullable: false));
            AddColumn("dbo.Expenses", "ProjectId", c => c.Int(nullable: false));
            AddColumn("dbo.Expenses", "CheckVoucherId", c => c.Int(nullable: false));
            AddColumn("dbo.Expenses", "CompanyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Expenses", "ProjectId");
            CreateIndex("dbo.Expenses", "CheckVoucherId");
            AddForeignKey("dbo.Expenses", "CheckVoucherId", "dbo.CheckVouchers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Expenses", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
            DropColumn("dbo.Expenses", "VoucherId");
            DropTable("dbo.Checks");
            DropTable("dbo.CheckTransactions");
            DropTable("dbo.Vouchers");
            DropTable("dbo.ExpenseItems");
        }
        
        public override void Down()
        {
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
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.CheckTransactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Notes = c.String(),
                        VoucherId = c.Int(nullable: false),
                        CheckId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            AddColumn("dbo.Expenses", "VoucherId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Expenses", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Expenses", "CheckVoucherId", "dbo.CheckVouchers");
            DropIndex("dbo.Expenses", new[] { "CheckVoucherId" });
            DropIndex("dbo.Expenses", new[] { "ProjectId" });
            DropColumn("dbo.Expenses", "CompanyId");
            DropColumn("dbo.Expenses", "CheckVoucherId");
            DropColumn("dbo.Expenses", "ProjectId");
            DropColumn("dbo.Expenses", "Category");
            DropColumn("dbo.Expenses", "Amount");
            DropColumn("dbo.Expenses", "ORNumber");
            DropColumn("dbo.Expenses", "PurchaseDate");
            DropTable("dbo.CheckVouchers");
            CreateIndex("dbo.ExpenseItems", "ProjectId");
            CreateIndex("dbo.ExpenseItems", "ExpenseId");
            CreateIndex("dbo.Expenses", "VoucherId");
            CreateIndex("dbo.CheckTransactions", "CheckId");
            CreateIndex("dbo.CheckTransactions", "VoucherId");
            AddForeignKey("dbo.Expenses", "VoucherId", "dbo.Vouchers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ExpenseItems", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ExpenseItems", "ExpenseId", "dbo.Expenses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CheckTransactions", "VoucherId", "dbo.Vouchers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CheckTransactions", "CheckId", "dbo.Checks", "Id", cascadeDelete: true);
        }
    }
}
