CREATE TABLE Logs(
  Id int NOT NULL IDENTITY,
  LogDate datetime,
  MsgText nvarchar(300),
  CONSTRAINT PK_Logs_Id PRIMARY KEY (Id)
)

GO

ALTER PROC usp_Add10MilionLogs
AS
DECLARE @counter int
SET @counter = 1;
WHILE(@counter < 10000000)
BEGIN
  DECLARE @Date datetime
	SET @Date = 
	DATEADD(month, CONVERT(varbinary, newid()) % (50 * 12), getdate())
	INSERT INTO Logs (LogDate, MsgText)
	VALUES(@Date, 'dsd')
	SET @counter = @counter + 1;
END
GO

EXEC usp_Add10MilionLogs


CHECKPOINT; DBCC DROPCLEANBUFFERS;

----------------------------TASK 1--------------------------------
SELECT l.LogDate
FROM Logs l
WHERE YEAR(l.LogDate) < 2012 AND YEAR(l.LogDate) > 2001

----------------------------TASK 2--------------------------------

CREATE INDEX IDX_Logs_LogDate ON Logs(LogDate)
DROP INDEX Logs.IDX_Logs_LogDate

SELECT l.LogDate
FROM Logs l
WHERE YEAR(l.LogDate) < 2012 AND YEAR(l.LogDate) > 2001

----------------------------TASK 3--------------------------------

DROP INDEX Logs.IDX_Logs_LogDate
CREATE INDEX IDX_Logs_MsgText ON Logs(MsgText)

SELECT l.MsgText
FROM Logs l
WHERE YEAR(l.LogDate) < 2012 AND YEAR(l.LogDate) > 2001