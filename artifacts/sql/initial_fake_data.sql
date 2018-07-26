INSERT INTO [metrics].[dbo].[Employees] (
	[Birthday],
	[Branch],
	[Name]
) VALUES
('1994-11-22', 1, 'Test'),
('1993-10-23', 2, 'BestBH'),
('1992-12-24', 3, 'BestCT'),
('1996-11-25', 3, 'BestDC'),
('1997-10-26', 2, 'BestPMC'),
('1995-10-27', 2, 'Test2')


DECLARE @Test INT = (SELECT [Id] FROM [metrics].[dbo].[Employees] WHERE [Name] = 'Test')
DECLARE @BestBH INT = (SELECT [Id] FROM [metrics].[dbo].[Employees] WHERE [Name] = 'BestBH')
DECLARE @BestCT INT = (SELECT [Id] FROM [metrics].[dbo].[Employees] WHERE [Name] = 'BestCT')
DECLARE @BestDC INT = (SELECT [Id] FROM [metrics].[dbo].[Employees] WHERE [Name] = 'BestDC')
DECLARE @BestPMC INT = (SELECT [Id] FROM [metrics].[dbo].[Employees] WHERE [Name] = 'BestPMC')
DECLARE @Test2 INT = (SELECT [Id] FROM [metrics].[dbo].[Employees] WHERE [Name] = 'Test2')


INSERT INTO [metrics].[dbo].[EmployeeStatistics] (
	[BilledHours],
	[CompletedTasks],
	[DrunkedCups],
	[PlayedMcGames],
	[EmployeeId],
	[Month],
	[Year]
) VALUES
(8, 12, 2, 3, @Test, 7, 2018),

(9999, 12, 5, 4, @BestBH, 7, 2018),
(9999, 135, 12, 234, @BestBH, 3, 2018),
(9999, 56, 14, 623, @BestBH, 5, 2018),
(9999, 85, 15, 523, @BestBH, 4, 2018),
(9999, 2, 123, 643, @BestBH, 7, 2017),
(9999, 345, 645, 23, @BestBH, 6, 2018),
(9999, 42, 97, 678, @BestBH, 1, 2018),
(9999, 20, 50, 90, @BestBH, 2, 2018),
(9999, 29, 27, 47, @BestBH, 7, 2016),
(9999, 74, 53, 231, @BestBH, 7, 2015),
(9999, 98, 23, 63, @BestBH, 7, 2014),

(12, 9999, 5, 4, @BestCT, 7, 2018),
(135, 9999, 12, 234, @BestCT, 3, 2018),
(56, 9999, 14, 623, @BestCT, 5, 2018),
(85, 9999, 15, 523, @BestCT, 4, 2018),
(2, 9999, 123, 643, @BestCT, 7, 2017),
(345, 9999, 645, 23, @BestCT, 6, 2018),
(42, 9999, 97, 678, @BestCT, 1, 2018),
(20, 9999, 50, 90, @BestCT, 2, 2018),
(29, 9999, 27, 47, @BestCT, 7, 2016),
(74, 9999, 53, 231, @BestCT, 7, 2015),
(98, 9999, 23, 63, @BestCT, 7, 2014),

(12, 5, 9999, 4, @BestDC, 7, 2018),
(135, 12, 9999, 234, @BestDC, 3, 2018),
(56, 14, 9999, 623, @BestDC, 5, 2018),
(85, 15, 9999, 523, @BestDC, 4, 2018),
(2, 123, 9999, 643, @BestDC, 7, 2017),
(345, 645, 9999, 23, @BestDC, 6, 2018),
(42, 97, 9999, 678, @BestDC, 1, 2018),
(20, 50, 9999, 90, @BestDC, 2, 2018),
(29, 27, 9999, 47, @BestDC, 7, 2016),
(74, 53, 9999, 231, @BestDC, 7, 2015),
(98, 23, 9999, 63, @BestDC, 7, 2014),

(12, 5, 4, 9999, @BestPMC, 7, 2018),
(135, 12, 234, 9999, @BestPMC, 3, 2018),
(56, 14, 623, 9999, @BestPMC, 5, 2018),
(85, 15, 523, 9999, @BestPMC, 4, 2018),
(2, 123, 643, 9999, @BestPMC, 7, 2017),
(345, 645, 23, 9999, @BestPMC, 6, 2018),
(42, 97, 678, 9999, @BestPMC, 1, 2018),
(20, 50, 90, 9999, @BestPMC, 2, 2018),
(29, 27, 47, 9999, @BestPMC, 7, 2016),
(74, 53, 231, 9999, @BestPMC, 7, 2015),
(98, 23, 63, 9999, @BestPMC, 7, 2014),

(777, 12, 5, 4, @Test2, 7, 2018),
(777, 135, 12, 234, @Test2, 3, 2018),
(56, 14, 777, 623, @Test2, 5, 2018),
(85, 15, 523, 777, @Test2, 4, 2018),
(777, 2, 123, 643, @Test2, 7, 2017),
(345, 777, 645, 23, @Test2, 6, 2018),
(42, 97, 777, 678, @Test2, 1, 2018),
(20, 50, 90, 777, @Test2, 2, 2018),
(777, 29, 27, 47, @Test2, 7, 2016),
(74, 777, 53, 231, @Test2, 7, 2015),
(98, 23, 777, 63, @Test2, 7, 2014)