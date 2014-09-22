USE TelerikAcademy;

/*
	01. Write a SQL query to find the names and salaries of the employees 
	that take the minimal salary in the company. Use a nested SELECT statement.
*/
SELECT e.FirstName + ' ' + e.LastName AS [Full name], e.Salary
FROM Employees e
WHERE e.Salary = 
	  (SELECT MIN(em.Salary) FROM Employees em);

--------------------------------------------------------------------------------------------

/*
	02. Write a SQL query to find the names and salaries of the employees 
	that have a salary that is up to 10% higher than the minimal salary for the company.
*/
SELECT e.FirstName + ' ' + e.LastName AS [Full name], e.Salary
FROM Employees e
WHERE e.Salary <= 
	  (SELECT MIN(em.Salary) + (0.1 * MIN(em.Salary)) FROM Employees em);

--------------------------------------------------------------------------------------------

/*
	03. Write a SQL query to find the full name, salary and department of the employees 
	that take the minimal salary in their department. Use a nested SELECT statement.
*/
SELECT e.FirstName + ' ' + e.LastName AS [Full Name], e.Salary, d.Name AS [Department Name]
FROM Employees e, Departments d
WHERE e.DepartmentID = d.DepartmentID AND
	  e.Salary = 
	  (SELECT MIN(em.Salary) FROM Employees em
	  WHERE em.DepartmentID = e.DepartmentID);

--------------------------------------------------------------------------------------------

/*
	04. Write a SQL query to find the average salary in the department #1.
*/
SELECT 1 AS [Department ID], AVG(Salary) AS [Average Salary]
FROM Employees
WHERE DepartmentID = 1;

--------------------------------------------------------------------------------------------

/*
	05. Write a SQL query to find the average salary in the "Sales" department.
*/
SELECT 'Sales' AS [Department Name], AVG(e.Salary) AS [Average Salary]
FROM Employees e
INNER JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales';

--------------------------------------------------------------------------------------------

/*
	06. Write a SQL query to find the number of employees in the "Sales" department.
*/
SELECT 'Sales' AS [Department Name], COUNT(*) AS [Number of Employees]
FROM Employees e
INNER JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales';

--------------------------------------------------------------------------------------------

/*
	07. Write a SQL query to find the number of all employees that have manager.
*/
SELECT COUNT(*) AS [Number of Employees with Managers]
FROM Employees
WHERE ManagerID IS NOT NULL;

--------------------------------------------------------------------------------------------

/*
	08. Write a SQL query to find the number of all employees that have no manager.
*/
SELECT COUNT(*) AS [Number of Employees without Managers]
FROM Employees
WHERE ManagerID IS NULL;

--------------------------------------------------------------------------------------------

/*
	09. Write a SQL query to find all departments and the average salary for each of them.
*/
SELECT d.Name AS [Department Name], AVG(e.Salary) AS [Average Salary]
FROM Employees e
INNER JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name;

--------------------------------------------------------------------------------------------

/*
	10. Write a SQL query to find the count of all employees 
	in each department and for each town.
*/
SELECT d.Name AS [Department Name], t.Name AS [Town Name],
	   COUNT(*) AS [Number of Employees]
FROM Employees e
INNER JOIN Departments d
ON e.DepartmentID = d.DepartmentID
INNER JOIN Addresses a
ON e.AddressID = a.AddressID
INNER JOIN Towns t
ON a.TownID = t.TownID 
GROUP BY t.Name, d.Name;

--------------------------------------------------------------------------------------------

/*
	11. Write a SQL query to find all managers that have exactly 5 employees. 
	Display their first name and last name.
*/
SELECT m.FirstName, m.LastName
FROM Employees m 
JOIN Employees e
ON m.EmployeeID = e.ManagerID
GROUP BY m.FirstName, m.LastName
HAVING COUNT(*) = 5;

--------------------------------------------------------------------------------------------

/*
	12. Write a SQL query to find all employees along with their managers. 
	For employees that do not have manager display the value "(no manager)".
*/
SELECT e.FirstName + ' ' + e.LastName AS [Employee],
	   ISNULL(m.FirstName + ' ' + m.LastName, '(no manager)') AS [Manager]
FROM Employees e
LEFT OUTER JOIN Employees m
ON e.ManagerID = m.EmployeeID;

--------------------------------------------------------------------------------------------

/*
	13. Write a SQL query to find the names of all employees whose last 
	name is exactly 5 characters long. Use the built-in LEN(str) function.
*/
SELECT FirstName + ' ' + LastName AS [Full Name]
FROM Employees
WHERE LEN(LastName) = 5;

--------------------------------------------------------------------------------------------

/*
	14. Write a SQL query to display the current date and time in the 
	following format "day.month.year hour:minutes:seconds:milliseconds". 
	Search in  Google to find how to format dates in SQL Server.
*/
SELECT FORMAT(GETDATE(), 'dd.MM.yyyy HH:mm:ss:fff');

--------------------------------------------------------------------------------------------

/*
	15. Write a SQL statement to create a table Users. 
	Users should have username, password, full name and last login time. 
	Choose appropriate data types for the table fields. 
	Define a primary key column with a primary key constraint. 
	Define the primary key column as identity to facilitate inserting records. 
	Define unique constraint to avoid repeating usernames. 
	Define a check constraint to ensure the password is at least 5 characters long.
*/
CREATE TABLE Users(
	UserID INT IDENTITY,
	Username NVARCHAR(50) NOT NULL,
	UserPassword NVARCHAR(50) NULL,
	FullName NVARCHAR(50) NOT NULL,
	LastLoginTime SMALLDATETIME NULL,
	CONSTRAINT PK_Users PRIMARY KEY(UserID),
	CONSTRAINT UK_Users_Username UNIQUE(Username),
	CONSTRAINT CHK_Users_UserPassword CHECK(LEN(UserPassword) >= 5)
);

--------------------------------------------------------------------------------------------

/*
	16. Write a SQL statement to create a view that displays the 
	users from the Users table that have been in the system today. 
	Test if the view works correctly.
*/
GO;

CREATE VIEW [Users from Today] AS 
SELECT Username, LastLoginTime 
FROM Users
WHERE CONVERT(DATE, LastLoginTime) = CONVERT(DATE, GETDATE());

GO;

INSERT INTO Users(Username, UserPassword, FullName, LastLoginTime)
VALUES ('henry_ford', '1234567', 'Henry Ford', '20140824 09:57:00');

INSERT INTO Users(Username, UserPassword, FullName, LastLoginTime)
VALUES ('michel_selgado', 'wasup123', 'Michel Selgado', '20140824 12:00:00');

INSERT INTO Users(Username, UserPassword, FullName, LastLoginTime)
VALUES ('the_beast_1999', 'password', 'Dave Batista', '20140724 09:00:00');

INSERT INTO Users(Username, UserPassword, FullName, LastLoginTime)
VALUES ('triple_xxx', 'WhoIshere', 'Krasi Radkov', '20140820 11:43:30');

INSERT INTO Users(Username, UserPassword, FullName, LastLoginTime)
VALUES ('r_truth', 'ThereIsTheTruth', 'Michel Galfondrieus', '20030303 03:03:03');

SELECT * 
FROM [Users from Today];

--------------------------------------------------------------------------------------------

/*
	17. Write a SQL statement to create a table Groups. 
	Groups should have unique name (use unique constraint). 
	Define primary key and identity column.
*/
CREATE TABLE Groups(
	GroupID INT IDENTITY,
	Name NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_Groups PRIMARY KEY(GroupID),
	CONSTRAINT UK_Groups_Name UNIQUE(Name)
);

--------------------------------------------------------------------------------------------

/*
	18. Write a SQL statement to add a column GroupID to the table Users. 
	Fill some data in this new column and as well in the Groups table. 
	Write a SQL statement to add a foreign key constraint between 
	tables Users and Groups tables.
*/
ALTER TABLE Users 
ADD GroupID INT NULL;

ALTER TABLE Users
ADD CONSTRAINT FK_Users_Groups
FOREIGN KEY(GroupID)
REFERENCES Groups(GroupID);

INSERT INTO Groups(Name)
VALUES ('The Crazy gyus');

INSERT INTO Groups(Name)
VALUES ('The not so Crazu gyus');

UPDATE Users
SET GroupID = 1
WHERE UserID IN (1, 2, 5);

UPDATE Users
SET GroupID = 2
WHERE UserID IN (3, 4);

--------------------------------------------------------------------------------------------

/*
	19. Write SQL statements to insert several records in the Users and Groups tables.
*/
INSERT INTO Groups(Name)
VALUES ('Tigers');

INSERT INTO Groups(Name)
VALUES ('The Tigers Killers');

INSERT INTO Groups(Name)
VALUES ('The weak girls');

INSERT INTO Users(Username, UserPassword, FullName, LastLoginTime, GroupID)
VALUES ('pikachu', 'PokemonRulezzz', 'Ash Ketchum', '20080101 00:01:02', 3);

INSERT INTO Users(Username, UserPassword, FullName, LastLoginTime, GroupID)
VALUES ('the_dragon', 'From1To9', 'Serena Williams', '20140824 01:03:00', 4);

INSERT INTO Users(Username, UserPassword, FullName, LastLoginTime, GroupID)
VALUES ('Cracy_Forest_2014', 'DontStawkMyPass', 'Milena Krumova', '20110111 12:11:10', 1);

INSERT INTO Users(Username, UserPassword, FullName, LastLoginTime, GroupID)
VALUES ('titulovaniq', 'mnogoTitliImam', 'Cristiano Ronaldo', '20121224 13:13:13', 3);

INSERT INTO Users(Username, UserPassword, FullName, LastLoginTime, GroupID)
VALUES ('the_best_boxer_ever', 'IWillBeatKlitchko', 'Kubrat Pulev', '20140101 21:54:01', 2);

--------------------------------------------------------------------------------------------

/*
	20. Write SQL statements to update some of the records in the Users and Groups tables.
*/
UPDATE Groups
SET Name = 'The lions'
WHERE GroupID = 3;

UPDATE Users
SET FullName = 'Harrisson Ford'
WHERE UserID = 1;

UPDATE Users
SET Username = 'cant_remembe_old', UserPassword = 'newPassword'
WHERE UserID = 2;

--------------------------------------------------------------------------------------------

/*
	21. Write SQL statements to delete some of the records from the Users and Groups tables.
*/
DELETE FROM Users
WHERE UserID = 3;

DELETE FROM Users
WHERE GroupID = 4;

DELETE FROM Groups
WHERE GroupID = 4;

DELETE FROM Groups
WHERE Name = 'The weak girls';

--------------------------------------------------------------------------------------------

/*
	22. Write SQL statements to insert in the Users table the names of all 
	employees from the Employees table. Combine the first and last names as 
	a full name. For username use the first letter of the first name + the last name 
	(in lowercase). Use the same for the password, and NULL for last login time.

	HINT: There are duplicate usernames or the password is lower than 5 characters
	(as it is said in task 15) when we use the first letter of the first name + the 
	last name (in lowercase). Therefore I use the first THREE letters of the first name.
*/
INSERT INTO Users(Username, UserPassword, FullName)
SELECT LEFT(e.FirstName, 3) + LOWER(e.LastName), 
	   LEFT(e.FirstName, 3) + LOWER(e.LastName),
	   e.FirstName + ' ' + e.LastName
FROM Employees e;

--------------------------------------------------------------------------------------------

/*
	23. Write a SQL statement that changes the password to NULL for 
	all users that have not been in the system since 10.03.2010.
*/
UPDATE Users
SET UserPassword = NULL
WHERE CONVERT(DATE, LastLoginTime) <= '20100310';

--------------------------------------------------------------------------------------------

/*
	24. Write a SQL statement that deletes all users without passwords (NULL password).
*/
DELETE FROM Users
WHERE UserPassword IS NULL;

--------------------------------------------------------------------------------------------

/*
	25. Write a SQL query to display the average employee salary 
	by department and job title.
*/
SELECT d.Name AS [Department Name], e.JobTitle, AVG(e.Salary) AS [Average Salary]
FROM Employees e
INNER JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY e.JobTitle, d.Name;

--------------------------------------------------------------------------------------------

/*
	26. Write a SQL query to display the minimal employee salary by department 
	and job title along with the name of some of the employees that take it.
*/
SELECT d.Name AS [Department Name], e.JobTitle,
	   e.FirstName + ' ' + e.LastName AS [Full Name],
	   MIN(e.Salary) AS [Min Salary]
FROM Employees e
INNER JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle, e.FirstName + ' ' + e.LastName;

--------------------------------------------------------------------------------------------

/*
	27. Write a SQL query to display the town where maximal number of employees work.
*/
SELECT TOP 1 t.Name AS [Town Name], COUNT(*) AS [Number of Employees]
FROM Employees e
INNER JOIN Addresses a
ON e.AddressID = a.AddressID
INNER JOIN Towns t
ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY [Number of Employees] DESC;

--------------------------------------------------------------------------------------------

/*
	28. Write a SQL query to display the number of managers from each town.
*/
SELECT t.Name AS [Town Name], COUNT(DISTINCT(m.EmployeeID)) AS [Number of Managers]
FROM Employees m
INNER JOIN Employees e
ON m.EmployeeID = e.ManagerID
INNER JOIN Addresses a
ON m.AddressID = a.AddressID
INNER JOIN Towns t
ON a.TownID = t.TownID
GROUP BY t.Name;

--------------------------------------------------------------------------------------------

/*
	29. Write a SQL to create table WorkHours to store work reports for 
	each employee (employee id, date, task, hours, comments). 
	Don't forget to define  identity, primary key and appropriate foreign key. 
	Issue few SQL statements to insert, update and delete of some data in the table.
	Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers. 
	For each change keep the old record data, the new record data and the command 
	(insert / update / delete).
*/
CREATE TABLE WorkHours(
	WorkHoursID INT IDENTITY,
	WorkDate DATE NOT NULL,
	Task NVARCHAR(150) NOT NULL,
	HoursOfWork TINYINT NOT NULL,
	Comments NVARCHAR(150) NULL,
	EmployeeID INT NOT NULL,
	CONSTRAINT PK_WorkHours PRIMARY KEY(WorkHoursID)
);

ALTER TABLE WorkHours
ADD CONSTRAINT FK_WorkHours_Employees
FOREIGN KEY(EmployeeID)
REFERENCES Employees(EmployeeID);

CREATE TABLE WorkHoursLogs(
	WorkHoursLogsID INT IDENTITY,
	OldWorkHoursID INT NULL,
	OldWorkDate DATE NULL,
	OldTask NVARCHAR(150) NULL,
	OldHoursOfWork TINYINT NULL,
	OldComments NVARCHAR(150) NULL,
	OldEmployeeID INT NULL,
	NewWorkHoursID INT NULL,
	NewWorkDate DATE NULL,
	NewTask NVARCHAR(150) NULL,
	NewHoursOfWork TINYINT NULL,
	NewComments NVARCHAR(150) NULL,
	NewEmployeeID INT NULL,
	Command nvarchar(10) NOT NULL,
	CONSTRAINT PK_WorkHoursLogs PRIMARY KEY(WorkHoursLogsID)
);

IF OBJECT_ID('tr_WorkHoursInsert','TR') IS NOT NULL
DROP TRIGGER tr_WorkHoursInsert;

GO;

CREATE TRIGGER tr_WorkHoursInsert ON WorkHours FOR INSERT
AS
INSERT INTO WorkHoursLogs(
	NewWorkHoursID, NewWorkDate, NewTask, NewHoursOfWork, NewComments, NewEmployeeID, 
	Command)
SELECT i.WorkHoursID, i.WorkDate, i.Task, i.HoursOfWork, i.Comments, i.EmployeeID, 
	   'INSERT'
FROM inserted i;

IF OBJECT_ID('tr_WorkHoursUpdate','TR') IS NOT NULL
DROP TRIGGER tr_WorkHoursUpdate;

GO;

CREATE TRIGGER tr_WorkHoursUpdate ON WorkHours FOR UPDATE
AS
INSERT INTO WorkHoursLogs(
	OldWorkHoursID, OldWorkDate, OldTask,OldHoursOfWork, OldComments, OldEmployeeID,
	NewWorkHoursID, NewWorkDate, NewTask, NewHoursOfWork, NewComments, NewEmployeeID, 
	Command)
SELECT d.WorkHoursID, d.WorkDate, d.Task, d.HoursOfWork, d.Comments, d.EmployeeID,
	   i.WorkHoursID, i.WorkDate, i.Task, i.HoursOfWork, i.Comments, i.EmployeeID, 
	   'UPDATE'
FROM deleted d 
INNER JOIN inserted i 
ON d.WorkHoursID = i.WorkHoursID;

IF OBJECT_ID('tr_WorkHoursDelete','TR') IS NOT NULL
DROP TRIGGER tr_WorkHoursDelete;

GO;

CREATE TRIGGER tr_WorkHoursDelete ON WorkHours FOR DELETE
AS
INSERT INTO WorkHoursLogs(
	OldWorkHoursID, OldWorkDate, OldTask, OldHoursOfWork, OldComments, OldEmployeeID, 
	Command)
SELECT d.WorkHoursID, d.WorkDate, d.Task, d.HoursOfWork, d.Comments, d.EmployeeID, 
	   'DELETE'
FROM deleted d;

INSERT INTO WorkHours(WorkDate, Task, HoursOfWork, Comments, EmployeeID)
VALUES ('20091010', 'Clean up the office.', 5, 'Very tired from the cleaning', 10);

INSERT INTO WorkHours(WorkDate, Task, HoursOfWork, Comments, EmployeeID)
VALUES ('20060503', 'Fix the computer.', 1, 'The computer work normally', 2);

INSERT INTO WorkHours(WorkDate, Task, HoursOfWork, Comments, EmployeeID)
VALUES ('20140824', 'Make all tasks from the Advanced SQL homework', 15, 
		'Dont know what to say', 1);

UPDATE WorkHours
SET Comments = 'I am not tired. I want more work.'
WHERE WorkHoursID = 1;

DELETE FROM WorkHours
WHERE WorkHoursID = 1;

--------------------------------------------------------------------------------------------

/*
	30. Start a database transaction, delete all employees from the 'Sales' 
	department along with all dependent records from the pother tables. 
	At the end rollback the transaction.
*/
BEGIN TRAN; 

ALTER TABLE Departments 
DROP [FK_Departments_Employees];

DELETE FROM Employees 
WHERE DepartmentID = 
	(SELECT d.DepartmentID 
	FROM Departments d
	WHERE d.Name = 'Sales');

DELETE FROM Departments 
WHERE Name = 'Sales';

ROLLBACK TRAN;

--------------------------------------------------------------------------------------------

/*
	31. Start a database transaction and drop the table EmployeesProjects. 
	Now how you could restore back the lost table data?
*/
BEGIN TRAN;

DROP TABLE EmployeesProjects;

ROLLBACK TRAN;

--------------------------------------------------------------------------------------------

/*
	32. Find how to use temporary tables in SQL Server. Using temporary tables 
	backup all records from EmployeesProjects and restore them back after 
	dropping and re-creating the table.
*/
BEGIN TRAN;

SELECT * INTO #TempEmployeesProjects 
FROM EmployeesProjects;

DROP TABLE EmployeesProjects;

COMMIT;

CREATE TABLE EmployeesProjects(
	EmployeeID int NOT NULL,
	ProjectID int NOT NULL,
	CONSTRAINT PK_EmployeesProjects PRIMARY KEY CLUSTERED (EmployeeID ASC, ProjectID ASC)
);

ALTER TABLE EmployeesProjects
ADD CONSTRAINT FK_EmployeesProjects_Employees 
FOREIGN KEY(EmployeeID)
REFERENCES Employees(EmployeeID);

ALTER TABLE EmployeesProjects
ADD CONSTRAINT FK_EmployeesProjects_Projects 
FOREIGN KEY(ProjectID)
REFERENCES Projects(ProjectID);

INSERT INTO EmployeesProjects
SELECT * FROM #TempEmployeesProjects;

DROP TABLE #TempEmployeesProjects;