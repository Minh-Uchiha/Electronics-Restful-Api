IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220607032523_Initial-Create')
BEGIN
    CREATE TABLE [Laptops] (
        [Id] int NOT NULL IDENTITY,
        [Size] float NOT NULL,
        [RamSize] float NOT NULL,
        [SSD] float NOT NULL,
        [HDD] float NOT NULL,
        [MonitorSpeed] int NOT NULL,
        [BatteryLife] int NOT NULL,
        [CPU] nvarchar(max) NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Brand] nvarchar(max) NOT NULL,
        [Price] float NOT NULL,
        [Origin] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NULL,
        [ImageUrl] nvarchar(max) NULL,
        CONSTRAINT [PK_Laptops] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220607032523_Initial-Create')
BEGIN
    CREATE TABLE [Phones] (
        [Id] int NOT NULL IDENTITY,
        [Size] float NOT NULL,
        [RamSize] float NOT NULL,
        [Screen] nvarchar(max) NOT NULL,
        [BatteryLife] int NOT NULL,
        [Camera] nvarchar(max) NOT NULL,
        [Chip] nvarchar(max) NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Brand] nvarchar(max) NOT NULL,
        [Price] float NOT NULL,
        [Origin] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NULL,
        [ImageUrl] nvarchar(max) NULL,
        CONSTRAINT [PK_Phones] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220607032523_Initial-Create')
BEGIN
    CREATE TABLE [Keyboards] (
        [Id] int NOT NULL IDENTITY,
        [Type] nvarchar(max) NOT NULL,
        [Switch] nvarchar(max) NOT NULL,
        [HasRGB] bit NOT NULL,
        [ConnectivityTech] nvarchar(max) NOT NULL,
        [HasBackLit] bit NOT NULL,
        [Color] nvarchar(max) NOT NULL,
        [LaptopId] int NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Brand] nvarchar(max) NOT NULL,
        [Price] float NOT NULL,
        [Origin] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NULL,
        [ImageUrl] nvarchar(max) NULL,
        CONSTRAINT [PK_Keyboards] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Keyboards_Laptops_LaptopId] FOREIGN KEY ([LaptopId]) REFERENCES [Laptops] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220607032523_Initial-Create')
BEGIN
    CREATE TABLE [Headphones] (
        [Id] int NOT NULL IDENTITY,
        [Color] nvarchar(max) NOT NULL,
        [connectivityTech] nvarchar(max) NOT NULL,
        [BatteryLife] float NOT NULL,
        [PhoneId] int NOT NULL,
        [LaptopId] int NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Brand] nvarchar(max) NOT NULL,
        [Price] float NOT NULL,
        [Origin] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NULL,
        [ImageUrl] nvarchar(max) NULL,
        CONSTRAINT [PK_Headphones] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Headphones_Laptops_LaptopId] FOREIGN KEY ([LaptopId]) REFERENCES [Laptops] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Headphones_Phones_PhoneId] FOREIGN KEY ([PhoneId]) REFERENCES [Phones] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220607032523_Initial-Create')
BEGIN
    CREATE INDEX [IX_Headphones_LaptopId] ON [Headphones] ([LaptopId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220607032523_Initial-Create')
BEGIN
    CREATE INDEX [IX_Headphones_PhoneId] ON [Headphones] ([PhoneId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220607032523_Initial-Create')
BEGIN
    CREATE INDEX [IX_Keyboards_LaptopId] ON [Keyboards] ([LaptopId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220607032523_Initial-Create')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220607032523_Initial-Create', N'6.0.5');
END;
GO

COMMIT;
GO

