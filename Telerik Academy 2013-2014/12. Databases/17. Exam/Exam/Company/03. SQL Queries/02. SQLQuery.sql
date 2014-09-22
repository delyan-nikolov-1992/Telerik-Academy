USE [Company]
GO

SELECT d.Name AS [Department name], 
	   COUNT(*) AS [Number of Employees]
FROM Employees e
INNER JOIN Departments d
ON e.DepartmentId = d.Id
GROUP BY d.Name
ORDER BY COUNT(*) DESC;