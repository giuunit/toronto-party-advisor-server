
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/28/2015 04:15:47
-- Generated from EDMX file: C:\Users\Abp\documents\visual studio 2013\Projects\TorontoPartyAdvisor\TorontoPartyAdvisor.Commands\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PartyAdvisor];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Position_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Position] DROP CONSTRAINT [FK_Position_User];
GO
IF OBJECT_ID(N'[dbo].[FK_PositionPlace_Place]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PositionPlace] DROP CONSTRAINT [FK_PositionPlace_Place];
GO
IF OBJECT_ID(N'[dbo].[FK_PositionPlace_Position]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PositionPlace] DROP CONSTRAINT [FK_PositionPlace_Position];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Place]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Place];
GO
IF OBJECT_ID(N'[dbo].[Position]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Position];
GO
IF OBJECT_ID(N'[dbo].[PositionPlace]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PositionPlace];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Places'
CREATE TABLE [dbo].[Places] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Latitude] float  NOT NULL,
    [Longitude] float  NOT NULL,
    [RadiusMeters] int  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [StreetName] nvarchar(200)  NOT NULL,
    [Number] int  NOT NULL,
    [City] nvarchar(50)  NOT NULL,
    [Country] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Positions'
CREATE TABLE [dbo].[Positions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Latitude] float  NOT NULL,
    [Longitude] float  NOT NULL,
    [UserId] int  NOT NULL,
    [Date] datetimeoffset  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(75)  NOT NULL,
    [LastName] nvarchar(75)  NOT NULL,
    [Gender] nvarchar(10)  NOT NULL,
    [FacebookToken] nvarchar(255)  NOT NULL,
    [Email] nvarchar(100)  NOT NULL,
    [FacebookId] nvarchar(25)  NOT NULL,
    [Timezone] int  NOT NULL,
    [Locale] nvarchar(10)  NOT NULL,
    [DateCreated] datetimeoffset  NOT NULL,
    [LastLoginDate] datetimeoffset  NOT NULL,
    [Points] int  NOT NULL
);
GO

-- Creating table 'PositionPlaces'
CREATE TABLE [dbo].[PositionPlaces] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PlaceId] int  NOT NULL,
    [PositionId] int  NOT NULL,
    [Date] datetimeoffset  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Places'
ALTER TABLE [dbo].[Places]
ADD CONSTRAINT [PK_Places]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Positions'
ALTER TABLE [dbo].[Positions]
ADD CONSTRAINT [PK_Positions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PositionPlaces'
ALTER TABLE [dbo].[PositionPlaces]
ADD CONSTRAINT [PK_PositionPlaces]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'Positions'
ALTER TABLE [dbo].[Positions]
ADD CONSTRAINT [FK_Position_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Position_User'
CREATE INDEX [IX_FK_Position_User]
ON [dbo].[Positions]
    ([UserId]);
GO

-- Creating foreign key on [PlaceId] in table 'PositionPlaces'
ALTER TABLE [dbo].[PositionPlaces]
ADD CONSTRAINT [FK_PositionPlace_Place]
    FOREIGN KEY ([PlaceId])
    REFERENCES [dbo].[Places]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PositionPlace_Place'
CREATE INDEX [IX_FK_PositionPlace_Place]
ON [dbo].[PositionPlaces]
    ([PlaceId]);
GO

-- Creating foreign key on [PositionId] in table 'PositionPlaces'
ALTER TABLE [dbo].[PositionPlaces]
ADD CONSTRAINT [FK_PositionPlace_Position1]
    FOREIGN KEY ([PositionId])
    REFERENCES [dbo].[Positions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PositionPlace_Position1'
CREATE INDEX [IX_FK_PositionPlace_Position1]
ON [dbo].[PositionPlaces]
    ([PositionId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------