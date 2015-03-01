
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/01/2015 21:56:34
-- Generated from EDMX file: C:\Users\pixel\Desktop\DataAppTemplate\DataAppLib\Models2\AppDbContext.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ATMDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CheckCheckTransaction]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CheckTransactions] DROP CONSTRAINT [FK_CheckCheckTransaction];
GO
IF OBJECT_ID(N'[dbo].[FK_CheckAccount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Checks] DROP CONSTRAINT [FK_CheckAccount];
GO
IF OBJECT_ID(N'[dbo].[FK_VoucherCheckTransaction]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vouchers] DROP CONSTRAINT [FK_VoucherCheckTransaction];
GO
IF OBJECT_ID(N'[dbo].[FK_VoucherAccount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vouchers] DROP CONSTRAINT [FK_VoucherAccount];
GO
IF OBJECT_ID(N'[dbo].[FK_ExpenseVoucher]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Expenses] DROP CONSTRAINT [FK_ExpenseVoucher];
GO
IF OBJECT_ID(N'[dbo].[FK_ExpenseExpenseItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ExpenseItems] DROP CONSTRAINT [FK_ExpenseExpenseItem];
GO
IF OBJECT_ID(N'[dbo].[FK_ExpenseItemAccount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ExpenseItems] DROP CONSTRAINT [FK_ExpenseItemAccount];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectExpenseItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ExpenseItems] DROP CONSTRAINT [FK_ProjectExpenseItem];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Checks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Checks];
GO
IF OBJECT_ID(N'[dbo].[Vouchers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vouchers];
GO
IF OBJECT_ID(N'[dbo].[Accounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Accounts];
GO
IF OBJECT_ID(N'[dbo].[CheckTransactions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CheckTransactions];
GO
IF OBJECT_ID(N'[dbo].[Expenses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Expenses];
GO
IF OBJECT_ID(N'[dbo].[ExpenseItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExpenseItems];
GO
IF OBJECT_ID(N'[dbo].[Projects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Projects];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Checks'
CREATE TABLE [dbo].[Checks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IssueDate] datetime  NOT NULL,
    [Amount] decimal(18,0)  NOT NULL,
    [Notes] nvarchar(max)  NOT NULL,
    [PayeeAccount_Id] int  NOT NULL
);
GO

-- Creating table 'Vouchers'
CREATE TABLE [dbo].[Vouchers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IssueDate] datetime  NOT NULL,
    [EntryDate] datetime  NOT NULL,
    [Type] int  NOT NULL,
    [CheckTransaction_Id] int  NOT NULL,
    [PayeeAccount_Id] int  NOT NULL
);
GO

-- Creating table 'Accounts'
CREATE TABLE [dbo].[Accounts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Contact] nvarchar(max)  NOT NULL,
    [Notes] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CheckTransactions'
CREATE TABLE [dbo].[CheckTransactions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CheckId] int  NOT NULL,
    [Amount] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'Expenses'
CREATE TABLE [dbo].[Expenses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Voucher_Id] int  NOT NULL
);
GO

-- Creating table 'ExpenseItems'
CREATE TABLE [dbo].[ExpenseItems] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ExpenseId] int  NOT NULL,
    [PurchaseDate] datetime  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [ORNumber] nvarchar(max)  NOT NULL,
    [ProjectId] int  NOT NULL,
    [Amount] decimal(18,0)  NOT NULL,
    [Category] int  NOT NULL,
    [CompanyAccount_Id] int  NOT NULL
);
GO

-- Creating table 'Projects'
CREATE TABLE [dbo].[Projects] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Checks'
ALTER TABLE [dbo].[Checks]
ADD CONSTRAINT [PK_Checks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Vouchers'
ALTER TABLE [dbo].[Vouchers]
ADD CONSTRAINT [PK_Vouchers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [PK_Accounts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CheckTransactions'
ALTER TABLE [dbo].[CheckTransactions]
ADD CONSTRAINT [PK_CheckTransactions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Expenses'
ALTER TABLE [dbo].[Expenses]
ADD CONSTRAINT [PK_Expenses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ExpenseItems'
ALTER TABLE [dbo].[ExpenseItems]
ADD CONSTRAINT [PK_ExpenseItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [PK_Projects]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CheckId] in table 'CheckTransactions'
ALTER TABLE [dbo].[CheckTransactions]
ADD CONSTRAINT [FK_CheckCheckTransaction]
    FOREIGN KEY ([CheckId])
    REFERENCES [dbo].[Checks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CheckCheckTransaction'
CREATE INDEX [IX_FK_CheckCheckTransaction]
ON [dbo].[CheckTransactions]
    ([CheckId]);
GO

-- Creating foreign key on [PayeeAccount_Id] in table 'Checks'
ALTER TABLE [dbo].[Checks]
ADD CONSTRAINT [FK_CheckAccount]
    FOREIGN KEY ([PayeeAccount_Id])
    REFERENCES [dbo].[Accounts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CheckAccount'
CREATE INDEX [IX_FK_CheckAccount]
ON [dbo].[Checks]
    ([PayeeAccount_Id]);
GO

-- Creating foreign key on [CheckTransaction_Id] in table 'Vouchers'
ALTER TABLE [dbo].[Vouchers]
ADD CONSTRAINT [FK_VoucherCheckTransaction]
    FOREIGN KEY ([CheckTransaction_Id])
    REFERENCES [dbo].[CheckTransactions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VoucherCheckTransaction'
CREATE INDEX [IX_FK_VoucherCheckTransaction]
ON [dbo].[Vouchers]
    ([CheckTransaction_Id]);
GO

-- Creating foreign key on [PayeeAccount_Id] in table 'Vouchers'
ALTER TABLE [dbo].[Vouchers]
ADD CONSTRAINT [FK_VoucherAccount]
    FOREIGN KEY ([PayeeAccount_Id])
    REFERENCES [dbo].[Accounts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VoucherAccount'
CREATE INDEX [IX_FK_VoucherAccount]
ON [dbo].[Vouchers]
    ([PayeeAccount_Id]);
GO

-- Creating foreign key on [Voucher_Id] in table 'Expenses'
ALTER TABLE [dbo].[Expenses]
ADD CONSTRAINT [FK_ExpenseVoucher]
    FOREIGN KEY ([Voucher_Id])
    REFERENCES [dbo].[Vouchers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExpenseVoucher'
CREATE INDEX [IX_FK_ExpenseVoucher]
ON [dbo].[Expenses]
    ([Voucher_Id]);
GO

-- Creating foreign key on [ExpenseId] in table 'ExpenseItems'
ALTER TABLE [dbo].[ExpenseItems]
ADD CONSTRAINT [FK_ExpenseExpenseItem]
    FOREIGN KEY ([ExpenseId])
    REFERENCES [dbo].[Expenses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExpenseExpenseItem'
CREATE INDEX [IX_FK_ExpenseExpenseItem]
ON [dbo].[ExpenseItems]
    ([ExpenseId]);
GO

-- Creating foreign key on [CompanyAccount_Id] in table 'ExpenseItems'
ALTER TABLE [dbo].[ExpenseItems]
ADD CONSTRAINT [FK_ExpenseItemAccount]
    FOREIGN KEY ([CompanyAccount_Id])
    REFERENCES [dbo].[Accounts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExpenseItemAccount'
CREATE INDEX [IX_FK_ExpenseItemAccount]
ON [dbo].[ExpenseItems]
    ([CompanyAccount_Id]);
GO

-- Creating foreign key on [ProjectId] in table 'ExpenseItems'
ALTER TABLE [dbo].[ExpenseItems]
ADD CONSTRAINT [FK_ProjectExpenseItem]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[Projects]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectExpenseItem'
CREATE INDEX [IX_FK_ProjectExpenseItem]
ON [dbo].[ExpenseItems]
    ([ProjectId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------