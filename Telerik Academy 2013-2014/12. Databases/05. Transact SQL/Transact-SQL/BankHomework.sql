/*
	01. Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) 
	and Accounts(Id(PK), PersonId(FK), Balance). Insert few records for testing. 
	Write a stored procedure that selects the full names of all persons.
*/
CREATE DATABASE Bank;

USE Bank;

CREATE TABLE Persons(
	Id INT IDENTITY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	SSN NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_Persons PRIMARY KEY(Id)
);

CREATE TABLE Accounts(
	Id INT IDENTITY NOT NULL,
	Balance MONEY NOT NULL,
	PersonId INT NOT NULL,
	CONSTRAINT PK_Accounts PRIMARY KEY(Id)
);

ALTER TABLE Accounts
ADD CONSTRAINT FK_Accounts_Persons
FOREIGN KEY(PersonId)
REFERENCES Persons(Id);

INSERT INTO Persons(FirstName, LastName, SSN)
VALUES ('Krasimir', 'Argirov', '011214D245');

INSERT INTO Persons(FirstName, LastName, SSN) 
VALUES ('Petar', 'Jekov', '1j6mc3329s');

INSERT INTO Persons(FirstName, LastName, SSN) 
VALUES ('Stanimir', 'Vasilev', '12145114De');

INSERT INTO Persons(FirstName, LastName, SSN)
 VALUES ('Stefan', 'Arnaudov', '15371047dj');

INSERT INTO Persons(FirstName, LastName, SSN) 
VALUES ('Petar', 'Petrov', '1234567890');

INSERT INTO Accounts(Balance, PersonId) 
VALUES (13347, 1);

INSERT INTO Accounts(Balance, PersonId) 
VALUES (1000000, 2);

INSERT INTO Accounts(Balance, PersonId) 
VALUES (5, 3);

INSERT INTO Accounts(Balance, PersonId) 
VALUES (14, 4);

INSERT INTO Accounts(Balance, PersonId) 
VALUES (20000, 5)

GO;

CREATE PROC usp_SelectPersonsFullNames
AS
SELECT FirstName + ' ' + LastName AS [Full Name]
FROM Persons;

EXEC usp_SelectPersonsFullNames;

--------------------------------------------------------------------------------------------

/*
	02. Create a stored procedure that accepts a number as a parameter 
	and returns all persons who have more money in their accounts than 
	the supplied number.
*/
GO;

CREATE PROC usp_SelectPersonsWithMoreMoneyThan(
	@moneyInAccount INT)
AS
SELECT p.FirstName, p.LastName, p.SSN, a.Balance
FROM Persons p
INNER JOIN Accounts a
ON p.Id = a.PersonId
WHERE a.Balance > @moneyInAccount;

EXEC usp_SelectPersonsWithMoreMoneyThan 50;

--------------------------------------------------------------------------------------------

/*
	03. Create a function that accepts as parameters – sum, yearly interest rate 
	and number of months. It should calculate and return the new sum. 
	Write a SELECT to test whether the function works as expected.
*/
GO;

CREATE FUNCTION ufn_CalculateSumWithInterest(
	@sum MONEY, 
	@yearlyInterestRate FLOAT, 
	@numberOfMonths INT)
	RETURNS MONEY
AS
BEGIN;
	RETURN @sum + (@sum * ((@yearlyInterestRate / 100) / 12) * @numberOfMonths);
END;

GO;

SELECT dbo.ufn_CalculateSumWithInterest(1000, 12, 10) AS [Sum with Interest];

--------------------------------------------------------------------------------------------

/*
	04. Create a stored procedure that uses the function from the previous example 
	to give an interest to a person's account for one month. It should take 
	the AccountId and the interest rate as parameters.
*/
GO;

CREATE PROC usp_GiveInterestToAccount(
	@accountId INT,
	@interestRate FLOAT)
AS
UPDATE Accounts
SET Balance = dbo.ufn_CalculateSumWithInterest(Balance, @interestRate, 1)
WHERE Id = @accountId;

-- before executing usp_GiveInterestToAccount
SELECT * 
FROM Accounts
WHERE Id = 3;

EXEC usp_GiveInterestToAccount 3, 10;

-- after executing usp_GiveInterestToAccount
SELECT * 
FROM Accounts
WHERE Id = 3;

--------------------------------------------------------------------------------------------

/*
	05. Add two more stored procedures WithdrawMoney( AccountId, money) and 
	DepositMoney (AccountId, money) that operate in transactions.
*/
GO;

CREATE PROC usp_WithdrawMoney(
	@accountId INT,
	@money MONEY)
AS
BEGIN TRAN;
	IF(@accountId < 1)
	BEGIN;
		RAISERROR('The id of the account should be positive!', 16, 1);
		ROLLBACK TRAN;
		RETURN;
	END;
	ELSE IF(@money < 0)
	BEGIN;
		RAISERROR('The amount of the withdrowed money should be positive!', 16, 1);
		ROLLBACK TRAN;
		RETURN;
	END;
	ELSE IF NOT EXISTS(SELECT * FROM Accounts WHERE Id = @accountId)
	BEGIN;
		RAISERROR('No existing account with the specified id', 16, 1);
		ROLLBACK TRAN;
		RETURN;
	END;
	DECLARE @newBalance MONEY;
	SELECT @newBalance = Balance - @money
	FROM Accounts
	WHERE Id = @accountId;
	IF(@newBalance < 0)
	BEGIN;
		RAISERROR('Not enough money to withdraw!', 16, 1);
		ROLLBACK TRAN;
		RETURN;
	END;
	UPDATE Accounts
	SET Balance = @newBalance
	WHERE Id = @accountId;
COMMIT;

GO;

CREATE PROC usp_DepositMoney(
	@accountId INT,
	@money MONEY)
AS
BEGIN TRAN;
	IF(@accountId < 1)
	BEGIN;
		RAISERROR('The id of the account should be positive!', 16, 1);
		ROLLBACK TRAN;
		RETURN;
	END;
	ELSE IF(@money < 0)
	BEGIN;
		RAISERROR('The amount of the withdrowed money should be positive!', 16, 1);
		ROLLBACK TRAN;
		RETURN;
	END;
	ELSE IF NOT EXISTS(SELECT * FROM Accounts WHERE Id = @accountId)
	BEGIN;
		RAISERROR('No existing account with the specified id', 16, 1);
		ROLLBACK TRAN;
		RETURN;
	END;
	UPDATE Accounts
	SET Balance = Balance + @money
	WHERE Id = @accountId;
COMMIT;

-- before executing usp_WithdrawMoney
SELECT * 
FROM Accounts
WHERE Id = 1;

EXEC usp_WithdrawMoney 1, 1000;

-- after executing usp_WithdrawMoney
SELECT * 
FROM Accounts
WHERE Id = 1;

-- before executing usp_DepositMoney
SELECT * 
FROM Accounts
WHERE Id = 1;

EXEC usp_DepositMoney 1, 1000;

-- after executing usp_DepositMoney
SELECT * 
FROM Accounts
WHERE Id = 1;

--------------------------------------------------------------------------------------------

/*
	06. Create another table – Logs(LogID, AccountID, OldSum, NewSum). 
	Add a trigger to the Accounts table that enters a new entry into 
	the Logs table every time the sum on an account changes.
*/
CREATE TABLE [dbo].[Logs](
	LogID INT IDENTITY NOT NULL,
	OldSum MONEY NULL,
	NewSum MONEY NULL,
	AccountID INT NOT NULL,
	CONSTRAINT PK_Logs PRIMARY KEY(LogID) 
);

ALTER TABLE Logs 
ADD CONSTRAINT FK_Logs_Accounts 
FOREIGN KEY(AccountID)
REFERENCES Accounts(Id);

IF OBJECT_ID('tr_AccountsBalanceInsert','TR') IS NOT NULL
DROP TRIGGER tr_AccountsBalanceInsert;

GO;

CREATE TRIGGER tr_AccountsBalanceInsert ON Accounts FOR INSERT
AS
INSERT INTO Logs(
	NewSum, AccountID)
SELECT i.Balance, i.Id
FROM inserted i;

IF OBJECT_ID('tr_AccountsBalanceUpdate','TR') IS NOT NULL
DROP TRIGGER tr_AccountsBalanceUpdate;

GO;

CREATE TRIGGER tr_AccountsBalanceUpdate ON Accounts FOR UPDATE
AS
INSERT INTO Logs(
	OldSum, NewSum, AccountID)
SELECT d.Balance, i.Balance, i.Id
FROM deleted d 
INNER JOIN inserted i 
ON d.Id = i.Id;

IF OBJECT_ID('tr_AccountsBalanceDelete','TR') IS NOT NULL
DROP TRIGGER tr_AccountsBalanceDelete;

GO;

CREATE TRIGGER tr_AccountsBalanceDelete ON Accounts FOR DELETE
AS
INSERT INTO Logs(
	OldSum, AccountID)
SELECT d.Balance, d.Id
FROM deleted d;

-- testing trigger tr_AccountsBalanceInsert
INSERT INTO Persons(FirstName, LastName, SSN)
VALUES ('Kolio', 'Ficheto', '1234567QW');

INSERT INTO Accounts(Balance, PersonId)
VALUES (1002, 6);

-- testing trigger tr_AccountsBalanceUpdate
EXEC usp_DepositMoney 1, 1000;

/*
	Testing trigger tr_AccountsBalanceDelete is clear, but it can't be done
	because there is a foreign key constraint between the tables Logs and Accounts.
	The foreign key can be deleted only for the test and then added again or 
	just to make a flag in the Accounts table whether the account is deleted or not.
*/

SELECT *
FROM Logs;