
BEGIN TRANSACTION;
GO

CREATE TABLE [LicenseLicense] (
    [IdPadre] int NOT NULL,
    [IdHijo] int NOT NULL
);
GO

CREATE TABLE [Licenses] (
    [Id] int NOT NULL IDENTITY,
    [IdUser] int NOT NULL,
    [Name] nvarchar(max) NULL,
    [HasChilds] bit NOT NULL,
    CONSTRAINT [PK_Licenses] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [User] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(150) NULL,
    [Password] nvarchar(20) NULL,
    [Key] nvarchar(36) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY ([Id])
);
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[User]') AND [c].[name] = N'Password');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [User] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [User] ALTER COLUMN [Password] nvarchar(20) NOT NULL;
ALTER TABLE [User] ADD DEFAULT N'' FOR [Password];
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[User]') AND [c].[name] = N'Name');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [User] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [User] ALTER COLUMN [Name] nvarchar(150) NOT NULL;
ALTER TABLE [User] ADD DEFAULT N'' FOR [Name];
GO

CREATE UNIQUE NONCLUSTERED INDEX IX_UQ_NameUniqueColumn ON [dbo].[User] (Name) WHERE Name IS NOT NULL; 
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [User] DROP CONSTRAINT [PK_User];
GO

EXEC sp_rename N'[User]', N'AdminUsers';
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AdminUsers]') AND [c].[name] = N'Password');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [AdminUsers] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [AdminUsers] ALTER COLUMN [Password] nvarchar(200) NOT NULL;
GO

ALTER TABLE [AdminUsers] ADD CONSTRAINT [PK_AdminUsers] PRIMARY KEY ([Id]);
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Licenses]') AND [c].[name] = N'IdUser');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Licenses] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Licenses] DROP COLUMN [IdUser];
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Licenses]') AND [c].[name] = N'HasChilds');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Licenses] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Licenses] DROP COLUMN [HasChilds];
GO

ALTER TABLE [Licenses] ADD [Code] int NOT NULL DEFAULT 0;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO AdminUsers ([Name], [Password], [Key]) VALUES ('Admin','WDJIcOK+M7SHQmUCmL/mBWFI5LXAYCT7V/n2S8pXnQtlQ9f2AGakXgDU4061IC1iOsbAgNseVq7+PF2dwlTn3MRQesJs', '27b2feeb-71de-4994-8e10-e22f867ce6d1')
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Languajes] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Code] int NOT NULL,
    [Key] nvarchar(36) NOT NULL,
    CONSTRAINT [PK_Languajes] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Words] (
    [Id] int NOT NULL IDENTITY,
    [LanguajeId] int NULL,
    [IdLanguaje] int NOT NULL,
    [Translate] nvarchar(max) NOT NULL,
    [Code] int NOT NULL,
    [Key] nvarchar(36) NOT NULL,
    CONSTRAINT [PK_Words] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Words_Languajes_LanguajeId] FOREIGN KEY ([LanguajeId]) REFERENCES [Languajes] ([Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_Words_LanguajeId] ON [Words] ([LanguajeId]);
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DROP TABLE [LicenseLicense];
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [LicenseLicense] (
    [Id] int NOT NULL IDENTITY,
    [IdPadre] int NOT NULL,
    [IdHijo] int NOT NULL
);
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

SET IDENTITY_INSERT Licenses ON
GO

INSERT INTO Licenses ([Id], [Name], [Code]) VALUES (1, 'All', 1)
GO

INSERT INTO Licenses ([Id], [Name], [Code]) VALUES (2, 'Restorant', 2)
GO

INSERT INTO Licenses ([Id], [Name], [Code]) VALUES (3, 'Edit menu', 3)
GO

INSERT INTO Licenses ([Id], [Name], [Code]) VALUES (4, 'Name', 4)
GO

INSERT INTO Licenses ([Id], [Name], [Code]) VALUES (5, 'Price', 5)
GO

INSERT INTO Licenses ([Id], [Name], [Code]) VALUES (6, 'Section', 6)
GO

INSERT INTO Licenses ([Id], [Name], [Code]) VALUES (7, 'Schedule', 7)
GO

INSERT INTO Licenses ([Id], [Name], [Code]) VALUES (8, 'Week days', 8)
GO

INSERT INTO Licenses ([Id], [Name], [Code]) VALUES (9, 'Open time', 9)
GO

INSERT INTO Licenses ([Id], [Name], [Code]) VALUES (10, 'Close time', 10)
GO

SET IDENTITY_INSERT Licenses OFF
GO

INSERT INTO LicenseLicense ([IdPadre], [IdHijo]) VALUES (1, 2)
GO

INSERT INTO LicenseLicense ([IdPadre], [IdHijo]) VALUES (2, 3)
GO

INSERT INTO LicenseLicense ([IdPadre], [IdHijo]) VALUES (2, 7)
GO

INSERT INTO LicenseLicense ([IdPadre], [IdHijo]) VALUES (3, 4)
GO

INSERT INTO LicenseLicense ([IdPadre], [IdHijo]) VALUES (3, 5)
GO

INSERT INTO LicenseLicense ([IdPadre], [IdHijo]) VALUES (3, 6)
GO

INSERT INTO LicenseLicense ([IdPadre], [IdHijo]) VALUES (7, 8)
GO

INSERT INTO LicenseLicense ([IdPadre], [IdHijo]) VALUES (7, 9)
GO

INSERT INTO LicenseLicense ([IdPadre], [IdHijo]) VALUES (7, 10)
GO

COMMIT;
GO

