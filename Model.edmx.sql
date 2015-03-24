
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/24/2015 00:21:21
-- Generated from EDMX file: C:\Users\pixel\Desktop\ExpenseManager-master\DataAppLib\Models\Model.edmx
-- --------------------------------------------------


create database expenseManagerDB;

SET QUOTED_IDENTIFIER OFF;
GO
USE expenseManagerDB;
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_VoucherCheckTransaction]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CheckTransactions] DROP CONSTRAINT [FK_VoucherCheckTransaction];
GO
IF OBJECT_ID(N'[dbo].[FK_CheckCheckTransaction]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CheckTransactions] DROP CONSTRAINT [FK_CheckCheckTransaction];
GO
IF OBJECT_ID(N'[dbo].[FK_VoucherExpense]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Expenses] DROP CONSTRAINT [FK_VoucherExpense];
GO
IF OBJECT_ID(N'[dbo].[FK_ExpenseExpenseItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ExpenseItems] DROP CONSTRAINT [FK_ExpenseExpenseItem];
GO
IF OBJECT_ID(N'[dbo].[FK_ExpenseItemProject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Projects] DROP CONSTRAINT [FK_ExpenseItemProject];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[TransactionAccounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TransactionAccounts];
GO
IF OBJECT_ID(N'[dbo].[Vouchers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vouchers];
GO
IF OBJECT_ID(N'[dbo].[Checks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Checks];
GO
IF OBJECT_ID(N'[dbo].[CheckTransactions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CheckTransactions];
GO
IF OBJECT_ID(N'[dbo].[ExpenseItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExpenseItems];
GO
IF OBJECT_ID(N'[dbo].[Expenses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Expenses];
GO
IF OBJECT_ID(N'[dbo].[Projects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Projects];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TransactionAccounts'
CREATE TABLE [dbo].[TransactionAccounts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Notes] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Vouchers'
CREATE TABLE [dbo].[Vouchers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IsExpense] bit  NOT NULL,
    [AddedOn] datetime  NOT NULL,
    [IssuedOn] datetime  NOT NULL,
    [Notes] nvarchar(max)  NOT NULL,
    [TransactionAccountId] int  NOT NULL
);
GO

-- Creating table 'Checks'
CREATE TABLE [dbo].[Checks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Amount] decimal(18,0)  NOT NULL,
    [AddedOn] datetime  NOT NULL,
    [Notes] nvarchar(max)  NOT NULL,
    [TransactionAccountId] int  NOT NULL
);
GO

-- Creating table 'CheckTransactions'
CREATE TABLE [dbo].[CheckTransactions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Amount] decimal(18,0)  NOT NULL,
    [Notes] nvarchar(max)  NOT NULL,
    [VoucherId] int  NOT NULL,
    [CheckId] int  NOT NULL
);
GO

-- Creating table 'ExpenseItems'
CREATE TABLE [dbo].[ExpenseItems] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PurchaseDate] datetime  NOT NULL,
    [Notes] nvarchar(max)  NOT NULL,
    [ORNumber] nvarchar(max)  NOT NULL,
    [Amount] decimal(18,0)  NOT NULL,
    [Category] int  NOT NULL,
    [ExpenseId] int  NOT NULL,
    [TransactionAccountId] int  NOT NULL
);
GO

-- Creating table 'Expenses'
CREATE TABLE [dbo].[Expenses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [VoucherId] int  NOT NULL
);
GO

-- Creating table 'Projects'
CREATE TABLE [dbo].[Projects] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Notes] nvarchar(max)  NOT NULL,
    [ExpenseItemId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TransactionAccounts'
ALTER TABLE [dbo].[TransactionAccounts]
ADD CONSTRAINT [PK_TransactionAccounts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Vouchers'
ALTER TABLE [dbo].[Vouchers]
ADD CONSTRAINT [PK_Vouchers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Checks'
ALTER TABLE [dbo].[Checks]
ADD CONSTRAINT [PK_Checks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CheckTransactions'
ALTER TABLE [dbo].[CheckTransactions]
ADD CONSTRAINT [PK_CheckTransactions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ExpenseItems'
ALTER TABLE [dbo].[ExpenseItems]
ADD CONSTRAINT [PK_ExpenseItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Expenses'
ALTER TABLE [dbo].[Expenses]
ADD CONSTRAINT [PK_Expenses]
    PRIMARY KEY CLUSTERED ([Id] ASC),
	ON DELETE CASCADE;
GO

-- Creating primary key on [Id] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [PK_Projects]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [VoucherId] in table 'CheckTransactions'
ALTER TABLE [dbo].[CheckTransactions]
ADD CONSTRAINT [FK_VoucherCheckTransaction]
    FOREIGN KEY ([VoucherId])
    REFERENCES [dbo].[Vouchers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VoucherCheckTransaction'
CREATE INDEX [IX_FK_VoucherCheckTransaction]
ON [dbo].[CheckTransactions]
    ([VoucherId]);
GO

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

-- Creating foreign key on [VoucherId] in table 'Expenses'
ALTER TABLE [dbo].[Expenses]
ADD CONSTRAINT [FK_VoucherExpense]
    FOREIGN KEY ([VoucherId])
    REFERENCES [dbo].[Vouchers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VoucherExpense'
CREATE INDEX [IX_FK_VoucherExpense]
ON [dbo].[Expenses]
    ([VoucherId]);
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

-- Creating foreign key on [ExpenseItemId] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [FK_ExpenseItemProject]
    FOREIGN KEY ([ExpenseItemId])
    REFERENCES [dbo].[ExpenseItems]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExpenseItemProject'
CREATE INDEX [IX_FK_ExpenseItemProject]
ON [dbo].[Projects]
    ([ExpenseItemId]);
GO

-- Creating foreign key on [TransactionAccountId] in table 'Vouchers'
ALTER TABLE [dbo].[Vouchers]
ADD CONSTRAINT [FK_TransactionAccountVoucher]
    FOREIGN KEY ([TransactionAccountId])
    REFERENCES [dbo].[TransactionAccounts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TransactionAccountVoucher'
CREATE INDEX [IX_FK_TransactionAccountVoucher]
ON [dbo].[Vouchers]
    ([TransactionAccountId]);
GO

-- Creating foreign key on [TransactionAccountId] in table 'Checks'
ALTER TABLE [dbo].[Checks]
ADD CONSTRAINT [FK_TransactionAccountCheck]
    FOREIGN KEY ([TransactionAccountId])
    REFERENCES [dbo].[TransactionAccounts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TransactionAccountCheck'
CREATE INDEX [IX_FK_TransactionAccountCheck]
ON [dbo].[Checks]
    ([TransactionAccountId]);
GO

-- Creating foreign key on [TransactionAccountId] in table 'ExpenseItems'
ALTER TABLE [dbo].[ExpenseItems]
ADD CONSTRAINT [FK_TransactionAccountExpenseItem]
    FOREIGN KEY ([TransactionAccountId])
    REFERENCES [dbo].[TransactionAccounts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TransactionAccountExpenseItem'
CREATE INDEX [IX_FK_TransactionAccountExpenseItem]
ON [dbo].[ExpenseItems]
    ([TransactionAccountId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------