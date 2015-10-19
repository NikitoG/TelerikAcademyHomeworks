-- 1. Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance).

	USE master
	GO

	CREATE DATABASE BankAcount
	GO

	USE BankAcount
	GO

	CREATE TABLE Persons(
	PersonID int IDENTITY PRIMARY KEY,
	FirstName nvarchar(50) NOT NULL,
	LastName nvarchar(50)  NOT NULL,
	SSN nvarchar(10) NOT NULL
	)
	GO

	CREATE TABLE Accounts (
	AccountId int IDENTITY PRIMARY KEY,
	PersonID int NOT NULL,
	Balance money NOT NULL,
	
	CONSTRAINT FK_Persons_Accounts
		FOREIGN KEY(PersonID) 
		REFERENCES Persons(PersonID)
	)
	GO
	
--		- Insert few records for testing.

	DECLARE @counter int
	SET @counter = 1
	WHILE @counter <= 30
		BEGIN
			INSERT INTO Persons(FirstName, LastName, SSN)
			VALUES ('Gosho #' + CAST(@counter AS nvarchar(50)), 'Peshov #' + CAST(@counter AS nvarchar(50)), 1000000000 + @counter)
			SET @counter = @counter + 1
		END
	GO
	

--		- Write a stored procedure that selects the full names of all persons.

	DECLARE @counter int
	SET @counter = 1
	WHILE @counter <= 50
		BEGIN
			IF (EXISTS(SELECT * FROM Persons WHERE PersonID = @counter))
			BEGIN
				INSERT INTO Accounts(PersonID, Balance)
				VALUES (@counter, 1000 * @counter)
			END
			SET @counter = @counter + 1
		END
	GO
	
-- 2. Create a stored procedure that accepts a number as a parameter and returns all persons who have more money in their accounts than the supplied number.

	USE BankAcount
	GO

	CREATE PROCEDURE usp_GetAllPersonsWithBalanceGreaterThan (
		@money money = 0)
	AS 
		SELECT *
		FROM Persons p
		JOIN Accounts a
			ON p.PersonID= a.PersonId
		WHERE a.Balance > @money
		ORDER BY a.Balance DESC
	GO
	
-- 3. Create a function that accepts as parameters – sum, yearly interest rate and number of months.
--		- It should calculate and return the new sum.

	USE BankAcount
	GO

	CREATE FUNCTION	ufn_CalculateSum (
	@sum money, @yeralyInterestRate money, @months int)
	RETURNS money
	AS
		BEGIN
			DECLARE @result int
			SET @result = @sum * (1 + ((@yeralyInterestRate / 12) * @months / 100))
			RETURN @result
		END
	GO
	

--		- Write a SELECT to test whether the function works as expected.

	USE BankAcount
	GO

	SELECT Balance, ROUND(dbo.ufn_CalculateSum(Balance, 12, 8), 2) as [Total]
	FROM Accounts
	
-- 4. Create a stored procedure that uses the function from the previous example to give an interest to a person's account for one month.

	USE BankAcount
	GO

	ALTER PROCEDURE usp_GetInterestToPersonAccount(
		@accountId int, @yearlyInterestRate float)
	AS
		DECLARE @balance money
		SELECT @balance = Balance 
		FROM Accounts 
		WHERE AccountId = @accountId
	
		DECLARE @interestForMonth money
		SELECT @interestForMonth = dbo.ufn_CalculateSum(@balance, @yearlyInterestRate, 1) - @balance
	
		SELECT p.FirstName + ' ' +  p.LastName AS FullName, a.Balance, @interestForMonth AS [InterestForMonth]
		FROM Persons p
		JOIN Accounts a
			ON p.PersonID = a.PersonId
		WHERE a.AccountId = @accountId
	GO

	USE BankAcount
	GO
	
--		- It should take the AccountId and the interest rate as parameters.

	EXEC usp_GetInterestToPersonAccount 5, 12
	
-- 5. Add two more stored procedures WithdrawMoney(AccountId, money) and DepositMoney(AccountId, money) that operate in transactions.

	USE BankAcount
	GO

	CREATE PROC usp_WithdrawMoney(
	@accountId money, @money money)
	AS
		BEGIN TRAN
			IF ((SELECT Balance FROM Accounts WHERE AccountId = @accountId) - @money >= 0)
				BEGIN
					UPDATE Accounts
					SET Balance -= @money
					WHERE AccountId = @accountId
				END
			ELSE
				BEGIN
					RAISERROR('Does not have enough money in this account', 16, 1)
				END
		COMMIT TRAN
	GO
	
-- DepositMoney
	
	USE BankAcount
	GO

	CREATE PROC usp_DepositMoney(
	@accountId money, @money money)
	AS
		BEGIN TRAN
			BEGIN
				UPDATE Accounts
				SET Balance += @money
				WHERE AccountId = @accountId
			END
		COMMIT TRAN
	GO

-- 6. Create another table – Logs(LogID, AccountID, OldSum, NewSum).

	USE BankAcount
	GO

	CREATE TABLE Logs (
    LogId int IDENTITY PRIMARY KEY,
    AccountId int NOT NULL,
    OldSum money NOT NULL,
    NewSum money NOT NULL,

	CONSTRAINT FK_Persons_Accounts
		FOREIGN KEY(AccountId) 
		REFERENCES Accounts(AccountId)
	)
	GO
	

--		- Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes.

	USE BankAcount
	GO

	CREATE TRIGGER tr_LogChanges ON Accounts FOR UPDATE
	AS
		DECLARE @oldSum money;
		SELECT @oldSum = Balance FROM deleted;

		INSERT INTO Logs(AccountId, OldSum, NewSum)
		SELECT AccountId, @oldSum, Balance
		FROM inserted
	GO
	
-- 7. Define a function in the database TelerikAcademy that returns all Employee's names (first or middle or last name) and all town's names that are comprised of given set of letters.
--		- Example: 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.


	USE TelerikAcademy
	GO

	CREATE FUNCTION	ufn_GetAllNamesWhoMatchpattern (@pattern nvarchar(50))
	RETURNS @MatchNames Table(MatchedNames nvarchar(50))
	AS
		BEGIN
			INSERT @MatchNames
			SELECT *
			FROM (
				SELECT FirstName
				FROM Employees
				UNION
				SELECT LastName
				FROM Employees
				UNION
				SELECT Name
				FROM Towns
			)  as temp(Name)
			WHERE PATINDEX('%[' + @pattern + ']', Name) > 0
			RETURN
		END
	GO

-- 8. Using database cursor write a T-SQL script that scans all employees and their addresses and prints all pairs of employees that live in the same town.

	DECLARE empCursor CURSOR READ_ONLY FOR
    SELECT e.FirstName + ' ' + e.LastName AS FullName, t.Name AS Town
	FROM Employees e, Addresses a, Towns t
	WHERE e.AddressID = a.AddressID AND a.TownID = t.TownID

	OPEN empCursor

	DECLARE @employee nvarchar(100), @town nvarchar(50)        
	FETCH NEXT FROM empCursor INTO @employee, @town

	WHILE @@FETCH_STATUS = 0
		BEGIN
				DECLARE sameTownCursor CURSOR READ_ONLY FOR
				SELECT e.FirstName + ' ' + e.LastName AS FullName, t.Name AS Town
				FROM Employees e, Addresses a, Towns t
				WHERE e.AddressID = a.AddressID AND a.TownID = t.TownID

				OPEN sameTownCursor

				DECLARE @neighborhood nvarchar(100), @sameTown nvarchar(50)        
				FETCH NEXT FROM sameTownCursor INTO @neighborhood, @sameTown

				WHILE @@FETCH_STATUS = 0
					BEGIN
					IF(@town = @sameTown AND @employee <> @neighborhood)
					BEGIN
						PRINT @employee + ' ----- ' + @neighborhood + ' -> ' + @sameTown;
					END

						FETCH NEXT FROM sameTownCursor 
						INTO @neighborhood, @sameTown
					END

				CLOSE sameTownCursor
				DEALLOCATE sameTownCursor
		FETCH NEXT FROM empCursor 
		INTO @employee, @town
		END

	CLOSE empCursor
	DEALLOCATE empCursor
	GO
	
-- 9. *Write a T-SQL script that shows for each town a list of all employees that live in it.

	DECLARE empCursor CURSOR READ_ONLY FOR
    SELECT e.FirstName + ' ' + e.LastName AS FullName, t.Name AS Town
	FROM Employees e, Addresses a, Towns t
	WHERE e.AddressID = a.AddressID AND a.TownID = t.TownID
	ORDER BY Town

	OPEN empCursor

	DECLARE @employee nvarchar(100), @town nvarchar(50)        
	FETCH NEXT FROM empCursor INTO @employee, @town

	WHILE @@FETCH_STATUS = 0
		BEGIN
				DECLARE @result nvarchar(MAX)
				SET @result = @town + ' -> ' + @employee
				DECLARE @sameTown nvarchar(100)
				SET @sameTown = @town
				WHILE @@FETCH_STATUS = 0 AND @sameTown = @town
				BEGIN
					SET @result += ', ' + @employee
					FETCH NEXT FROM empCursor 
					INTO @employee, @town
				END

		PRINT @result 
		FETCH NEXT FROM empCursor 
		INTO @employee, @town
		END

	CLOSE empCursor
	DEALLOCATE empCursor
	GO
	
-- 10. Define a .NET aggregate function StrConcat that takes as input a sequence of strings and return a single string that consists of the input strings separated by ','.
	
	USE TelerikAcademy
	GO
	IF NOT EXISTS (
		SELECT value
		FROM sys.configurations
		WHERE name = 'clr enabled' AND value = 1
	)
	BEGIN
		EXEC sp_configure @configname = clr_enabled, @configvalue = 1
		RECONFIGURE
	END
	GO
	IF (OBJECT_ID('dbo.concat') IS NOT NULL) 
		DROP Aggregate concat; 
	GO 
	IF EXISTS (SELECT * FROM sys.assemblies WHERE name = 'concat_assembly') 
		DROP assembly concat_assembly; 
	GO      
	CREATE Assembly concat_assembly 
	   AUTHORIZATION dbo 
	   FROM 'D:\Telerik\Homework\TelerikAcademyHomeworks\Database\Transact-SQL\SqlStringConcatenation.dll' --- CHANGE THE LOCATION (SAME AS THIS .sql FILE)
	   WITH PERMISSION_SET = SAFE; 
	GO 
	CREATE AGGREGATE dbo.concat ( 
		@Value NVARCHAR(MAX),
		@Delimiter NVARCHAR(4000) 
	) 
		RETURNS NVARCHAR(MAX) 
		EXTERNAL Name concat_assembly.concat; 
	GO 
	SELECT dbo.concat(FirstName + ' ' + LastName, ', ')
	FROM Employees
	GO
	DROP Aggregate concat; 
	DROP assembly concat_assembly; 
	GO

	