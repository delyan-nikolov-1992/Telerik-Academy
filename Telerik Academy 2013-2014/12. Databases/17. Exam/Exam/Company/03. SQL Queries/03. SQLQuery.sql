USE [Company]
GO

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
ORDER BY e.Id, p.Id;