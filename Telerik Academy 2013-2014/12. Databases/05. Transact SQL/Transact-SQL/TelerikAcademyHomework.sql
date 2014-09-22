USE TelerikAcademy;

/*
	07. Define a function in the database TelerikAcademy that returns 
	all Employee's names (first or middle or last name) and all town's 
	names that are comprised of given set of letters. Example 'oistmiahf' 
	will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.
*/
GO;

CREATE FUNCTION ufn_AllCharsEquals(
	@word NVARCHAR(50),
	@expression NVARCHAR(50))
	RETURNS BIT
AS
BEGIN;
	IF(@word IS NULL)
	BEGIN;
		RETURN 0;
	END;

	DECLARE @index INT = 0;
	DECLARE @wordsLength INT = LEN(@word);

	WHILE(@index < @wordsLength)
	BEGIN;
		IF(CHARINDEX(
			SUBSTRING(@word, @index + 1, 1), @expression COLLATE Latin1_General_CI_AS) <= 0)
			BEGIN;
				RETURN 0;
			END;

		SET @index = @index + 1;
	END;

	RETURN 1;
END;

GO;

CREATE FUNCTION ufn_CalculateSumWithInterest(
	@setOfLetters NVARCHAR(50))
	RETURNS TABLE
AS
RETURN (
	SELECT FirstName AS [Name]
	FROM Employees
	WHERE dbo.ufn_AllCharsEquals(FirstName, @setOfLetters) = 1
	UNION
	SELECT MiddleName AS [Name]
	FROM Employees
	WHERE dbo.ufn_AllCharsEquals(MiddleName, @setOfLetters) = 1
	UNION
	SELECT LastName AS [Name]
	FROM Employees
	WHERE dbo.ufn_AllCharsEquals(LastName, @setOfLetters) = 1
	UNION
	SELECT Name
	FROM Towns
	WHERE dbo.ufn_AllCharsEquals(Name, @setOfLetters) = 1
);

GO;

SELECT * FROM
dbo.ufn_CalculateSumWithInterest('oistmiahf');

--------------------------------------------------------------------------------------------

/*
	08. Using database cursor write a T-SQL script that scans all employees and 
	their addresses and prints all pairs of employees that live in the same town.
*/
DECLARE empCursor CURSOR READ_ONLY FOR
  SELECT t1.Name AS [Town Name],
		 e1.FirstName + ' ' + e1.LastName AS [First Employee],
		 e2.FirstName + ' ' + e2.LastName AS [Second Employee]
  FROM Employees e1
  INNER JOIN Addresses a1
  ON e1.AddressID = a1.AddressID
  INNER JOIN Towns t1
  ON a1.TownID = t1.TownID,
  Employees e2
  INNER JOIN Addresses a2 
  ON e2.AddressID = a2.AddressID
  INNER JOIN Towns t2 
  ON a2.TownID = t2.TownID
  WHERE t1.TownID = t2.TownID AND e1.EmployeeID <> e2.EmployeeID
  ORDER BY [Town Name];

OPEN empCursor
DECLARE @townName NCHAR(50), @firstEmployee NCHAR(50), @secondEmployee NCHAR(50)
FETCH NEXT FROM empCursor INTO @townName, @secondEmployee, @firstEmployee

WHILE @@FETCH_STATUS = 0
  BEGIN
    PRINT @townName + ' ' + @firstEmployee + ' ' + @secondEmployee
    FETCH NEXT FROM empCursor 
    INTO @townName, @secondEmployee, @firstEmployee
  END

CLOSE empCursor
DEALLOCATE empCursor

--------------------------------------------------------------------------------------------

/*
	09. Write a T-SQL script that shows for each town a list of all employees 
	that live in it. Sample output:

	Sofia -> Svetlin Nakov, Martin Kulov, George Denchev
	Ottawa -> Jose Saraiva
	…
*/
SELECT e.FirstName + ' ' + e.LastName AS EmployeeName, t.TownID
INTO #TempEmployeesWithTowns
FROM Employees e 
INNER JOIN Addresses a 
ON e.AddressID = a.AddressID
INNER JOIN Towns t 
ON a.TownID = t.TownID 
CREATE INDEX Idx_TemTown 
ON #TempEmployeesWithTowns(TownID)

DECLARE townCursor CURSOR READ_ONLY FOR
SELECT TownID, Name 
FROM Towns
ORDER BY Name

OPEN townCursor
DECLARE @townID INT, @cityName NVARCHAR(50)
FETCH NEXT FROM townCursor 
INTO @townID, @cityName
WHILE @@FETCH_STATUS = 0
  BEGIN
    DECLARE empCursor CURSOR READ_ONLY FOR
	SELECT EmployeeName FROM #TempEmployeesWithTowns
	WHERE TownID = @townID

	OPEN empCursor
	DECLARE @employeeName NVARCHAR(150), @employeesList NVARCHAR(MAX)
	SET @employeesList = ''
	FETCH NEXT FROM empCursor INTO @employeeName

	WHILE @@FETCH_STATUS = 0	
	  BEGIN
		SET @employeesList = CONCAT(@employeesList, @employeeName, ', ')
		FETCH NEXT FROM empCursor INTO @employeeName
	  END  
	CLOSE empCursor
	DEALLOCATE empCursor
	SET @employeesList = LEFT(@employeesList, LEN(@employeesList) - 1)
	PRINT @cityName + ' -> ' + @employeesList
	FETCH NEXT FROM townCursor INTO @townID, @cityName         
  END
CLOSE townCursor
DEALLOCATE townCursor
DROP TABLE #TempEmployeesWithTowns

--------------------------------------------------------------------------------------------

/*
	10. Define a .NET aggregate function StrConcat that takes as input 
	a sequence of strings and return a single string that consists of the 
	input strings separated by ','. For example the following SQL statement 
	should return a single string:

	SELECT StrConcat(FirstName + ' ' + LastName)
	FROM Employees
*/
IF OBJECT_ID('dbo.StrConcat') IS NOT NULL DROP Aggregate StrConcat 
GO 

IF EXISTS (SELECT * FROM sys.assemblies WHERE name = 'concat_assembly') 
       DROP assembly concat_assembly; 
GO      

DECLARE @path nvarchar(256)
-- You must change this path to the folder where the .dll with the CLR function is.
SET @path = 'C:\PathToFile'

CREATE Assembly concat_assembly 
   AUTHORIZATION dbo 
   FROM @path+'\ConcatAggregateSqlFunction.dll' 
   WITH PERMISSION_SET = SAFE; 
GO 

CREATE AGGREGATE dbo.StrConcat ( 

    @Value NVARCHAR(MAX),
	@Delimiter NVARCHAR(4000) 

) RETURNS NVARCHAR(MAX) 
EXTERNAL Name concat_assembly.Concat; 
GO

-- Enable execution of CLR code 
sp_configure 'clr enabled',1
GO
RECONFIGURE
GO
--sp_configure 'clr enabled'  -- make sure it took
--GO

SELECT [dbo].StrConcat(FirstName + ' ' + LastName, ', ') as Names
FROM Employees

-- Disable execution of CLR code 
/*
sp_configure 'clr enabled',0
GO
RECONFIGURE
GO
sp_configure 'clr enabled'  -- make sure it took
GO
*/