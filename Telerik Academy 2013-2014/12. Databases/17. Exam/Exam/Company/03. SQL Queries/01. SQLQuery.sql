USE [Company]
GO

SELECT FirstName + ' ' + LastName AS [Full name], YearSalary
FROM Employees
WHERE YearSalary >= 100000 AND YearSalary <= 150000
ORDER BY YearSalary;