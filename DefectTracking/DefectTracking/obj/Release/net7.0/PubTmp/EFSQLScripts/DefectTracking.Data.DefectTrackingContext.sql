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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230302192811_Initial')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230302192811_Initial')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230302192811_Initial')
BEGIN
    CREATE TABLE [Employee] (
        [EmpId] int NOT NULL IDENTITY,
        [UserName] nvarchar(max) NOT NULL,
        [Password] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Employee] PRIMARY KEY ([EmpId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230302192811_Initial')
BEGIN
    CREATE TABLE [Supplier] (
        [SupId] int NOT NULL IDENTITY,
        [UserName] nvarchar(max) NOT NULL,
        [Password] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Supplier] PRIMARY KEY ([SupId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230302192811_Initial')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230302192811_Initial')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230302192811_Initial')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230302192811_Initial')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230302192811_Initial')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230302192811_Initial')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230302192811_Initial')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230302192811_Initial')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230302192811_Initial')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230302192811_Initial')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230302192811_Initial')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230302192811_Initial')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230302192811_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230302192811_Initial', N'7.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230302193316_UpdateDatabase')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230302193316_UpdateDatabase', N'7.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230302201232_UpdateLoginViewModel')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230302201232_UpdateLoginViewModel', N'7.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230302203551_AddedClasses')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230302203551_AddedClasses', N'7.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230302234036_UpdateCode')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230302234036_UpdateCode', N'7.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230303140232_UpdatedCode')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230303140232_UpdatedCode', N'7.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230303160526_UpdatedCode1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230303160526_UpdatedCode1', N'7.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230303172622_DeletedEmplyeeAndSupplier')
BEGIN
    DROP TABLE [Employee];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230303172622_DeletedEmplyeeAndSupplier')
BEGIN
    DROP TABLE [Supplier];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230303172622_DeletedEmplyeeAndSupplier')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230303172622_DeletedEmplyeeAndSupplier', N'7.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230303183753_AddedEmployeeUser')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230303183753_AddedEmployeeUser', N'7.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230303225453_UdatedRolesAndCreatedRegisterFunction')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230303225453_UdatedRolesAndCreatedRegisterFunction', N'7.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230306225709_UpdateDBContextAddedNewTable')
BEGIN
    CREATE TABLE [ManufacturingDefects] (
        [Id] int NOT NULL IDENTITY,
        [SerialNumber] int NOT NULL,
        [UnitType] nvarchar(max) NOT NULL,
        [Display] int NOT NULL,
        [CalibrationMissingCalibration] int NOT NULL,
        [MechanicalAssemblyError] int NOT NULL,
        [DeadorDyingBatteries] int NOT NULL,
        [PCBBoardDefect] int NOT NULL,
        [Other] int NOT NULL,
        [OtherDesc] nvarchar(max) NOT NULL,
        [ProblemDesc] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_ManufacturingDefects] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230306225709_UpdateDBContextAddedNewTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230306225709_UpdateDBContextAddedNewTable', N'7.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230307033601_Changed_a_field_value')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ManufacturingDefects]') AND [c].[name] = N'UnitType');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [ManufacturingDefects] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [ManufacturingDefects] ALTER COLUMN [UnitType] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230307033601_Changed_a_field_value')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ManufacturingDefects]') AND [c].[name] = N'SerialNumber');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [ManufacturingDefects] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [ManufacturingDefects] ALTER COLUMN [SerialNumber] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230307033601_Changed_a_field_value')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ManufacturingDefects]') AND [c].[name] = N'ProblemDesc');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [ManufacturingDefects] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [ManufacturingDefects] ALTER COLUMN [ProblemDesc] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230307033601_Changed_a_field_value')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ManufacturingDefects]') AND [c].[name] = N'OtherDesc');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [ManufacturingDefects] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [ManufacturingDefects] ALTER COLUMN [OtherDesc] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230307033601_Changed_a_field_value')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230307033601_Changed_a_field_value', N'7.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230307055945_FixedTableAgain')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ManufacturingDefects]') AND [c].[name] = N'SerialNumber');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [ManufacturingDefects] DROP CONSTRAINT [' + @var4 + '];');
    EXEC(N'UPDATE [ManufacturingDefects] SET [SerialNumber] = 0 WHERE [SerialNumber] IS NULL');
    ALTER TABLE [ManufacturingDefects] ALTER COLUMN [SerialNumber] int NOT NULL;
    ALTER TABLE [ManufacturingDefects] ADD DEFAULT 0 FOR [SerialNumber];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230307055945_FixedTableAgain')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230307055945_FixedTableAgain', N'7.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230307210020_DeliveryDefects')
BEGIN
    CREATE TABLE [DeliveryDefects] (
        [Id] int NOT NULL IDENTITY,
        [SerialNumber] int NOT NULL,
        [UnitType] nvarchar(max) NULL,
        [Display] int NOT NULL,
        [CalibrationMissingCalibration] int NOT NULL,
        [MechanicalAssemblyError] int NOT NULL,
        [DeadorDyingBatteries] int NOT NULL,
        [PCBBoardDefect] int NOT NULL,
        [Other] int NOT NULL,
        [OtherDesc] nvarchar(max) NULL,
        [ProblemDesc] nvarchar(max) NULL,
        CONSTRAINT [PK_DeliveryDefects] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230307210020_DeliveryDefects')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230307210020_DeliveryDefects', N'7.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230307222058_CombinedAllCodeTogether')
BEGIN
    CREATE TABLE [WarrantyDefects] (
        [Id] int NOT NULL IDENTITY,
        [SerialNumber] int NOT NULL,
        [UnitType] nvarchar(max) NULL,
        [Display] int NOT NULL,
        [CalibrationMissingCalibration] int NOT NULL,
        [MechanicalAssemblyError] int NOT NULL,
        [DeadorDyingBatteries] int NOT NULL,
        [PCBBoardDefect] int NOT NULL,
        [Other] int NOT NULL,
        [OtherDesc] nvarchar(max) NULL,
        [ProblemDesc] nvarchar(max) NULL,
        CONSTRAINT [PK_WarrantyDefects] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230307222058_CombinedAllCodeTogether')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230307222058_CombinedAllCodeTogether', N'7.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230316220528_CreatedCommonDefectTableWithData')
BEGIN
    CREATE TABLE [CommonDefects] (
        [Id] int NOT NULL IDENTITY,
        [CommonDefectName] nvarchar(max) NULL,
        CONSTRAINT [PK_CommonDefects] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230316220528_CreatedCommonDefectTableWithData')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CommonDefectName') AND [object_id] = OBJECT_ID(N'[CommonDefects]'))
        SET IDENTITY_INSERT [CommonDefects] ON;
    EXEC(N'INSERT INTO [CommonDefects] ([Id], [CommonDefectName])
    VALUES (1, N''Speaker quiet''),
    (2, N''No sound''),
    (3, N''Switch not working''),
    (4, N''Button not working''),
    (5, N''Enclosure Defect'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CommonDefectName') AND [object_id] = OBJECT_ID(N'[CommonDefects]'))
        SET IDENTITY_INSERT [CommonDefects] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230316220528_CreatedCommonDefectTableWithData')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230316220528_CreatedCommonDefectTableWithData', N'7.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317031326_AddedOneValueToCommonDefects')
BEGIN
    EXEC(N'UPDATE [CommonDefects] SET [CommonDefectName] = N''''
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317031326_AddedOneValueToCommonDefects')
BEGIN
    EXEC(N'UPDATE [CommonDefects] SET [CommonDefectName] = N''Speaker quiet''
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317031326_AddedOneValueToCommonDefects')
BEGIN
    EXEC(N'UPDATE [CommonDefects] SET [CommonDefectName] = N''No sound''
    WHERE [Id] = 3;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317031326_AddedOneValueToCommonDefects')
BEGIN
    EXEC(N'UPDATE [CommonDefects] SET [CommonDefectName] = N''Switch not working''
    WHERE [Id] = 4;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317031326_AddedOneValueToCommonDefects')
BEGIN
    EXEC(N'UPDATE [CommonDefects] SET [CommonDefectName] = N''Button not working''
    WHERE [Id] = 5;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317031326_AddedOneValueToCommonDefects')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CommonDefectName') AND [object_id] = OBJECT_ID(N'[CommonDefects]'))
        SET IDENTITY_INSERT [CommonDefects] ON;
    EXEC(N'INSERT INTO [CommonDefects] ([Id], [CommonDefectName])
    VALUES (6, N''Enclosure Defect'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CommonDefectName') AND [object_id] = OBJECT_ID(N'[CommonDefects]'))
        SET IDENTITY_INSERT [CommonDefects] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317031326_AddedOneValueToCommonDefects')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230317031326_AddedOneValueToCommonDefects', N'7.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317032342_UpdateDeleiveryDefectsWithCommonDefectField')
BEGIN
    ALTER TABLE [DeliveryDefects] ADD [CommonDefectId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317032342_UpdateDeleiveryDefectsWithCommonDefectField')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230317032342_UpdateDeleiveryDefectsWithCommonDefectField', N'7.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317042431_CreateRelationshipAgain')
BEGIN
    EXEC sp_rename N'[CommonDefects].[Id]', N'CommonDefectId', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317042431_CreateRelationshipAgain')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230317042431_CreateRelationshipAgain', N'7.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317043529_PleaseJustWorkAlready')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230317043529_PleaseJustWorkAlready', N'7.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317055822_NotSureWhatIDid')
BEGIN
    EXEC sp_rename N'[DeliveryDefects].[CommonDefectID]', N'CommonDefectId', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317055822_NotSureWhatIDid')
BEGIN
    ALTER TABLE [DeliveryDefects] ADD [CommonDefectsCommonDefectId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317055822_NotSureWhatIDid')
BEGIN
    CREATE INDEX [IX_DeliveryDefects_CommonDefectsCommonDefectId] ON [DeliveryDefects] ([CommonDefectsCommonDefectId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317055822_NotSureWhatIDid')
BEGIN
    ALTER TABLE [DeliveryDefects] ADD CONSTRAINT [FK_DeliveryDefects_CommonDefects_CommonDefectsCommonDefectId] FOREIGN KEY ([CommonDefectsCommonDefectId]) REFERENCES [CommonDefects] ([CommonDefectId]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317055822_NotSureWhatIDid')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230317055822_NotSureWhatIDid', N'7.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317070612_UpdateAllTables')
BEGIN
    ALTER TABLE [WarrantyDefects] ADD [CommonDefectId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317070612_UpdateAllTables')
BEGIN
    ALTER TABLE [WarrantyDefects] ADD [CommonDefectsCommonDefectId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317070612_UpdateAllTables')
BEGIN
    ALTER TABLE [ManufacturingDefects] ADD [CommonDefectId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317070612_UpdateAllTables')
BEGIN
    ALTER TABLE [ManufacturingDefects] ADD [CommonDefectsCommonDefectId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317070612_UpdateAllTables')
BEGIN
    CREATE INDEX [IX_WarrantyDefects_CommonDefectsCommonDefectId] ON [WarrantyDefects] ([CommonDefectsCommonDefectId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317070612_UpdateAllTables')
BEGIN
    CREATE INDEX [IX_ManufacturingDefects_CommonDefectsCommonDefectId] ON [ManufacturingDefects] ([CommonDefectsCommonDefectId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317070612_UpdateAllTables')
BEGIN
    ALTER TABLE [ManufacturingDefects] ADD CONSTRAINT [FK_ManufacturingDefects_CommonDefects_CommonDefectsCommonDefectId] FOREIGN KEY ([CommonDefectsCommonDefectId]) REFERENCES [CommonDefects] ([CommonDefectId]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317070612_UpdateAllTables')
BEGIN
    ALTER TABLE [WarrantyDefects] ADD CONSTRAINT [FK_WarrantyDefects_CommonDefects_CommonDefectsCommonDefectId] FOREIGN KEY ([CommonDefectsCommonDefectId]) REFERENCES [CommonDefects] ([CommonDefectId]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317070612_UpdateAllTables')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230317070612_UpdateAllTables', N'7.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230323203711_CreatedNewRelationSHipForCommonDefectsTable')
BEGIN
    ALTER TABLE [DeliveryDefects] DROP CONSTRAINT [FK_DeliveryDefects_CommonDefects_CommonDefectsCommonDefectId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230323203711_CreatedNewRelationSHipForCommonDefectsTable')
BEGIN
    ALTER TABLE [ManufacturingDefects] DROP CONSTRAINT [FK_ManufacturingDefects_CommonDefects_CommonDefectsCommonDefectId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230323203711_CreatedNewRelationSHipForCommonDefectsTable')
BEGIN
    ALTER TABLE [WarrantyDefects] DROP CONSTRAINT [FK_WarrantyDefects_CommonDefects_CommonDefectsCommonDefectId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230323203711_CreatedNewRelationSHipForCommonDefectsTable')
BEGIN
    DROP INDEX [IX_WarrantyDefects_CommonDefectsCommonDefectId] ON [WarrantyDefects];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230323203711_CreatedNewRelationSHipForCommonDefectsTable')
BEGIN
    DROP INDEX [IX_ManufacturingDefects_CommonDefectsCommonDefectId] ON [ManufacturingDefects];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230323203711_CreatedNewRelationSHipForCommonDefectsTable')
BEGIN
    DROP INDEX [IX_DeliveryDefects_CommonDefectsCommonDefectId] ON [DeliveryDefects];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230323203711_CreatedNewRelationSHipForCommonDefectsTable')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[WarrantyDefects]') AND [c].[name] = N'CommonDefectsCommonDefectId');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [WarrantyDefects] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [WarrantyDefects] DROP COLUMN [CommonDefectsCommonDefectId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230323203711_CreatedNewRelationSHipForCommonDefectsTable')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ManufacturingDefects]') AND [c].[name] = N'CommonDefectsCommonDefectId');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [ManufacturingDefects] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [ManufacturingDefects] DROP COLUMN [CommonDefectsCommonDefectId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230323203711_CreatedNewRelationSHipForCommonDefectsTable')
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DeliveryDefects]') AND [c].[name] = N'CommonDefectsCommonDefectId');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [DeliveryDefects] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [DeliveryDefects] DROP COLUMN [CommonDefectsCommonDefectId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230323203711_CreatedNewRelationSHipForCommonDefectsTable')
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ManufacturingDefects]') AND [c].[name] = N'ProblemDesc');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [ManufacturingDefects] DROP CONSTRAINT [' + @var8 + '];');
    EXEC(N'UPDATE [ManufacturingDefects] SET [ProblemDesc] = N'''' WHERE [ProblemDesc] IS NULL');
    ALTER TABLE [ManufacturingDefects] ALTER COLUMN [ProblemDesc] nvarchar(max) NOT NULL;
    ALTER TABLE [ManufacturingDefects] ADD DEFAULT N'' FOR [ProblemDesc];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230323203711_CreatedNewRelationSHipForCommonDefectsTable')
BEGIN
    CREATE INDEX [IX_WarrantyDefects_CommonDefectId] ON [WarrantyDefects] ([CommonDefectId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230323203711_CreatedNewRelationSHipForCommonDefectsTable')
BEGIN
    CREATE INDEX [IX_ManufacturingDefects_CommonDefectId] ON [ManufacturingDefects] ([CommonDefectId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230323203711_CreatedNewRelationSHipForCommonDefectsTable')
BEGIN
    CREATE INDEX [IX_DeliveryDefects_CommonDefectId] ON [DeliveryDefects] ([CommonDefectId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230323203711_CreatedNewRelationSHipForCommonDefectsTable')
BEGIN
    ALTER TABLE [DeliveryDefects] ADD CONSTRAINT [FK_deliveryDefects_commonDefects] FOREIGN KEY ([CommonDefectId]) REFERENCES [CommonDefects] ([CommonDefectId]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230323203711_CreatedNewRelationSHipForCommonDefectsTable')
BEGIN
    ALTER TABLE [ManufacturingDefects] ADD CONSTRAINT [FK_manufacturingDefects_commonDefects] FOREIGN KEY ([CommonDefectId]) REFERENCES [CommonDefects] ([CommonDefectId]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230323203711_CreatedNewRelationSHipForCommonDefectsTable')
BEGIN
    ALTER TABLE [WarrantyDefects] ADD CONSTRAINT [FK_warrantyDefects_commonDefects] FOREIGN KEY ([CommonDefectId]) REFERENCES [CommonDefects] ([CommonDefectId]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230323203711_CreatedNewRelationSHipForCommonDefectsTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230323203711_CreatedNewRelationSHipForCommonDefectsTable', N'7.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230518182440_removecommondefects')
BEGIN
    ALTER TABLE [DeliveryDefects] DROP CONSTRAINT [FK_deliveryDefects_commonDefects];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230518182440_removecommondefects')
BEGIN
    ALTER TABLE [ManufacturingDefects] DROP CONSTRAINT [FK_manufacturingDefects_commonDefects];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230518182440_removecommondefects')
BEGIN
    ALTER TABLE [WarrantyDefects] DROP CONSTRAINT [FK_warrantyDefects_commonDefects];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230518182440_removecommondefects')
BEGIN
    DROP TABLE [CommonDefects];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230518182440_removecommondefects')
BEGIN
    DROP INDEX [IX_WarrantyDefects_CommonDefectId] ON [WarrantyDefects];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230518182440_removecommondefects')
BEGIN
    DROP INDEX [IX_ManufacturingDefects_CommonDefectId] ON [ManufacturingDefects];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230518182440_removecommondefects')
BEGIN
    DROP INDEX [IX_DeliveryDefects_CommonDefectId] ON [DeliveryDefects];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230518182440_removecommondefects')
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[WarrantyDefects]') AND [c].[name] = N'CommonDefectId');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [WarrantyDefects] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [WarrantyDefects] DROP COLUMN [CommonDefectId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230518182440_removecommondefects')
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ManufacturingDefects]') AND [c].[name] = N'CommonDefectId');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [ManufacturingDefects] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [ManufacturingDefects] DROP COLUMN [CommonDefectId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230518182440_removecommondefects')
BEGIN
    DECLARE @var11 sysname;
    SELECT @var11 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DeliveryDefects]') AND [c].[name] = N'CommonDefectId');
    IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [DeliveryDefects] DROP CONSTRAINT [' + @var11 + '];');
    ALTER TABLE [DeliveryDefects] DROP COLUMN [CommonDefectId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230518182440_removecommondefects')
BEGIN
    DECLARE @var12 sysname;
    SELECT @var12 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ManufacturingDefects]') AND [c].[name] = N'ProblemDesc');
    IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [ManufacturingDefects] DROP CONSTRAINT [' + @var12 + '];');
    ALTER TABLE [ManufacturingDefects] ALTER COLUMN [ProblemDesc] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230518182440_removecommondefects')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230518182440_removecommondefects', N'7.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519181013_updateDatabaseTables')
BEGIN
    ALTER TABLE [WarrantyDefects] ADD [ButtonNotWorking] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519181013_updateDatabaseTables')
BEGIN
    ALTER TABLE [WarrantyDefects] ADD [Date] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519181013_updateDatabaseTables')
BEGIN
    ALTER TABLE [WarrantyDefects] ADD [EnclosureDefect] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519181013_updateDatabaseTables')
BEGIN
    ALTER TABLE [WarrantyDefects] ADD [NoSound] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519181013_updateDatabaseTables')
BEGIN
    ALTER TABLE [WarrantyDefects] ADD [SpeakerQuiet] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519181013_updateDatabaseTables')
BEGIN
    ALTER TABLE [WarrantyDefects] ADD [SwitchNotWorking] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519181013_updateDatabaseTables')
BEGIN
    ALTER TABLE [ManufacturingDefects] ADD [ButtonNotWorking] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519181013_updateDatabaseTables')
BEGIN
    ALTER TABLE [ManufacturingDefects] ADD [Date] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519181013_updateDatabaseTables')
BEGIN
    ALTER TABLE [ManufacturingDefects] ADD [EnclosureDefect] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519181013_updateDatabaseTables')
BEGIN
    ALTER TABLE [ManufacturingDefects] ADD [NoSound] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519181013_updateDatabaseTables')
BEGIN
    ALTER TABLE [ManufacturingDefects] ADD [SpeakerQuiet] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519181013_updateDatabaseTables')
BEGIN
    ALTER TABLE [ManufacturingDefects] ADD [SwitchNotWorking] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519181013_updateDatabaseTables')
BEGIN
    ALTER TABLE [DeliveryDefects] ADD [ButtonNotWorking] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519181013_updateDatabaseTables')
BEGIN
    ALTER TABLE [DeliveryDefects] ADD [Date] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519181013_updateDatabaseTables')
BEGIN
    ALTER TABLE [DeliveryDefects] ADD [EnclosureDefect] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519181013_updateDatabaseTables')
BEGIN
    ALTER TABLE [DeliveryDefects] ADD [NoSound] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519181013_updateDatabaseTables')
BEGIN
    ALTER TABLE [DeliveryDefects] ADD [SpeakerQuiet] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519181013_updateDatabaseTables')
BEGIN
    ALTER TABLE [DeliveryDefects] ADD [SwitchNotWorking] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519181013_updateDatabaseTables')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230519181013_updateDatabaseTables', N'7.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519190514_UpdateWarrantyDefectTable')
BEGIN
    ALTER TABLE [WarrantyDefects] ADD [WorkPerformed] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519190514_UpdateWarrantyDefectTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230519190514_UpdateWarrantyDefectTable', N'7.0.3');
END;
GO

COMMIT;
GO

