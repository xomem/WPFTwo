
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/24/2017 22:10:59
-- Generated from EDMX file: C:\Users\Edward\source\repos\WpfApp\WpfApp\MainModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MainDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[employment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[employment];
GO
IF OBJECT_ID(N'[dbo].[hardDrive]', 'U') IS NOT NULL
    DROP TABLE [dbo].[hardDrive];
GO
IF OBJECT_ID(N'[dbo].[normTech]', 'U') IS NOT NULL
    DROP TABLE [dbo].[normTech];
GO
IF OBJECT_ID(N'[dbo].[room]', 'U') IS NOT NULL
    DROP TABLE [dbo].[room];
GO
IF OBJECT_ID(N'[dbo].[systemCharacteristic]', 'U') IS NOT NULL
    DROP TABLE [dbo].[systemCharacteristic];
GO
IF OBJECT_ID(N'[dbo].[technic]', 'U') IS NOT NULL
    DROP TABLE [dbo].[technic];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'hardDrives'
CREATE TABLE [dbo].[hardDrives] (
    [PCID] int  NOT NULL,
    [company] nvarchar(50)  NULL,
    [serialNumber] nvarchar(50)  NULL,
    [space] nvarchar(50)  NULL
);
GO

-- Creating table 'normTeches'
CREATE TABLE [dbo].[normTeches] (
    [techID] int  NOT NULL,
    [employID] int  NOT NULL
);
GO

-- Creating table 'systemCharacteristics'
CREATE TABLE [dbo].[systemCharacteristics] (
    [PCID] int  NOT NULL,
    [processorName] nvarchar(50)  NULL,
    [processorModel] nvarchar(50)  NULL,
    [RAM] nchar(10)  NULL,
    [capacity] nchar(10)  NULL,
    [operatingSystem] nvarchar(50)  NULL
);
GO

-- Creating table 'technics'
CREATE TABLE [dbo].[technics] (
    [ID] int  NOT NULL,
    [type] nvarchar(50)  NOT NULL,
    [company] nvarchar(50)  NULL,
    [model] nvarchar(50)  NULL,
    [businessNumber] nvarchar(50)  NULL,
    [serialNumber] nvarchar(50)  NULL
);
GO

-- Creating table 'employments'
CREATE TABLE [dbo].[employments] (
    [ID] int  NOT NULL,
    [surname] nvarchar(50)  NOT NULL,
    [name] nvarchar(50)  NOT NULL,
    [patronymic] nvarchar(50)  NULL,
    [room_employID] int  NOT NULL
);
GO

-- Creating table 'rooms'
CREATE TABLE [dbo].[rooms] (
    [employID] int  NOT NULL,
    [roomNumber] nvarchar(50)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [PCID] in table 'hardDrives'
ALTER TABLE [dbo].[hardDrives]
ADD CONSTRAINT [PK_hardDrives]
    PRIMARY KEY CLUSTERED ([PCID] ASC);
GO

-- Creating primary key on [techID], [employID] in table 'normTeches'
ALTER TABLE [dbo].[normTeches]
ADD CONSTRAINT [PK_normTeches]
    PRIMARY KEY CLUSTERED ([techID], [employID] ASC);
GO

-- Creating primary key on [PCID] in table 'systemCharacteristics'
ALTER TABLE [dbo].[systemCharacteristics]
ADD CONSTRAINT [PK_systemCharacteristics]
    PRIMARY KEY CLUSTERED ([PCID] ASC);
GO

-- Creating primary key on [ID] in table 'technics'
ALTER TABLE [dbo].[technics]
ADD CONSTRAINT [PK_technics]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'employments'
ALTER TABLE [dbo].[employments]
ADD CONSTRAINT [PK_employments]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [employID] in table 'rooms'
ALTER TABLE [dbo].[rooms]
ADD CONSTRAINT [PK_rooms]
    PRIMARY KEY CLUSTERED ([employID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [room_employID] in table 'employments'
ALTER TABLE [dbo].[employments]
ADD CONSTRAINT [FK_roomemployment]
    FOREIGN KEY ([room_employID])
    REFERENCES [dbo].[rooms]
        ([employID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_roomemployment'
CREATE INDEX [IX_FK_roomemployment]
ON [dbo].[employments]
    ([room_employID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------