IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Employees] (
    [Id] int NOT NULL IDENTITY,
    [Birthday] datetime2 NOT NULL,
    [Branch] int NOT NULL,
    [Name] nvarchar(255) NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [EmployeeStatistics] (
    [Id] int NOT NULL IDENTITY,
    [BilledHours] int NOT NULL,
    [CompletedTasks] int NOT NULL,
    [DrunkedCups] int NOT NULL,
    [EmployeeId] int NOT NULL,
    [Month] int NOT NULL,
    [PlayedMcGames] int NOT NULL,
    [Year] int NOT NULL,
    CONSTRAINT [PK_EmployeeStatistics] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EmployeeStatistics_Employees_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_EmployeeStatistics_EmployeeId] ON [EmployeeStatistics] ([EmployeeId]);

GO

CREATE UNIQUE INDEX [IX_EmployeeStatistics_Year_Month] ON [EmployeeStatistics] ([Year], [Month]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180416023402_Initial', N'2.0.2-rtm-10011');

GO

