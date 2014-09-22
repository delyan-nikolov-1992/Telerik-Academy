USE [Company]
GO

CREATE PROC dbo.usp_CreateCacheTable
AS
  CREATE TABLE [dbo].[Cache](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Full name] [nvarchar](41) NOT NULL,
	[Project name] [nvarchar](50) NOT NULL,
	[Department name] [nvarchar](50) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[Number of reports] [int] NOT NULL
	CONSTRAINT [PK_Cache] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
GO

EXEC usp_CreateCacheTable
GO

CREATE PROC dbo.usp_InsertIntoCacheTable
AS
  INSERT INTO Cache([Full name], [Project name], 
    [Department name], [StartDate], [EndDate], [Number of reports])
	   SELECT e.FirstName + ' ' + e.LastName AS [Full name], 
	   p.Name AS [Project name], d.Name AS [Department name], 
	   ep.StartDate, ep.EndDate,
	   (SELECT COUNT(*) 
		FROM Reports r
		WHERE r.EmployeeId = e.Id 
			  AND r.ReportTime >= ep.StartDate 
			  AND r.ReportTime <= ep.EndDate) AS [Number of reports]
		FROM Employees e
		INNER JOIN EmployeesProjects ep
		ON e.Id = ep.EmployeeId
		INNER JOIN Projects p
		ON p.Id = ep.EmployeeId
		INNER JOIN Departments d
		ON e.DepartmentId = d.Id
		ORDER BY e.Id, p.Id
GO

EXEC usp_InsertIntoCacheTable
GO