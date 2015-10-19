--1. Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company.
--	- Use a nested SELECT statement.
	
	USE TelerikAcademy
	SELECT FirstName + ' ' + LastName AS [Full name], Salary
	FROM Employees
	WHERE Salary = (SELECT MIN(Salary) FROM Employees)
	
--2. Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.
	
	USE TelerikAcademy
	SELECT FirstName + ' ' + LastName AS [Full name], Salary
	FROM Employees
	WHERE Salary <= (SELECT MIN(Salary) * 1.1 FROM Employees)
	ORDER BY Salary DESC	
	
--3. Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department.
--	- Use a nested SELECT statement.

	USE TelerikAcademy
	SELECT FirstName + ' ' + LastName AS [Full name], Salary, d.Name
	FROM Employees e, Departments d
	WHERE e.DepartmentID = d.DepartmentID AND
	Salary = (SELECT MIN(Salary) FROM Employees empl WHERE e.DepartmentID = empl.DepartmentID)
	ORDER BY Salary
	
--4. Write a SQL query to find the average salary in the department #1.

	USE TelerikAcademy
	SELECT AVG(Salary) AS [Average salary], DepartmentID
	FROM Employees
	GROUP BY DepartmentID
	HAVING DepartmentID = 1
	
--5. Write a SQL query to find the average salary in the "Sales" department.

	USE TelerikAcademy
	SELECT AVG(Salary) AS [Average salary], d.Name
	FROM Employees e, Departments d
	WHERE e.DepartmentID = d.DepartmentID
	GROUP BY d.Name
	HAVING d.Name = 'Sales'
	
--6. Write a SQL query to find the number of employees in the "Sales" department.

	USE TelerikAcademy
	SELECT d.Name AS [Departments name], COUNT(*) AS [Number of Employees]
	FROM Employees e, Departments d
	WHERE e.DepartmentID = d.DepartmentID
	GROUP BY d.Name
	HAVING d.Name = 'Sales'
	
--7. Write a SQL query to find the number of all employees that have manager.

	USE TelerikAcademy
	SELECT COUNT(ManagerID) AS [Number of Employees with Manager]
	FROM Employees
	
--8. Write a SQL query to find the number of all employees that have no manager.

	USE TelerikAcademy
	SELECT COUNT(*) AS [Number of Big Boss]
	FROM Employees
	WHERE ManagerID IS NULL
	
--9. Write a SQL query to find all departments and the average salary for each of them.

	USE TelerikAcademy
	SELECT d.Name AS [Department], AVG(e.Salary) AS [Average salary]
	FROM Employees e, Departments d
	WHERE e.DepartmentID = d.DepartmentID
	GROUP BY d.Name
	ORDER BY [Average salary]
	
--10. Write a SQL query to find the count of all employees in each department and for each town.

	USE TelerikAcademy
	SELECT d.Name AS Department,t.Name AS Town, COUNT(*) AS [Employees]
	FROM Employees e, Departments d, Addresses a, Towns t
	WHERE e.DepartmentID = d.DepartmentID AND e.AddressID = a.AddressID AND a.TownID = t.TownID
	GROUP BY d.Name, t.Name
	ORDER BY Department, Town
	
--11. Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.

	USE TelerikAcademy
	SELECT m.EmployeeID AS [Manager ID], m.FirstName + ' ' + m.LastName AS [Full Name], COUNT(*) AS Employee
	FROM Employees e
		JOIN Employees m
		ON e.ManagerID = m.EmployeeID
	GROUP BY m.FirstName, m.LastName, m.EmployeeID
	HAVING COUNT(*) = 5
	
--12. Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)".

	USE TelerikAcademy
	SELECT CONCAT(e.FirstName, ' ', e.LastName) AS Employee, ISNULL((m.FirstName + ' ' + m.LastName), 'no manager') AS Manager
	FROM Employees e
		LEFT JOIN Employees m
		ON e.ManagerID = m.EmployeeID
		
--13. Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function.

	USE TelerikAcademy
	SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name]
	FROM Employees
	WHERE LEN(LastName) = 5
	
--14. Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds".
--		- Search in Google to find how to format dates in SQL Server.

	SELECT FORMAT(GETDATE(),'dd.MM.yyyy HH.mm.ss.fff') AS [Current Date and Time]
	
--15. Write a SQL statement to create a table Users. Users should have username, password, full name and last login time.
--		-Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint.
--		-Define the primary key column as identity to facilitate inserting records.
--		-Define unique constraint to avoid repeating usernames.
--		-Define a check constraint to ensure the password is at least 5 characters long.

	CREATE TABLE Users (
	UserId int IDENTITY,
	Username nvarchar(20) NOT NULL,
	[Password] nvarchar(20) NOT NULL,
	FullName nvarchar(50) NOT NULL,
	LastLoginTime datetime,
	CONSTRAINT PK_Users PRIMARY KEY(UserId), 
	CONSTRAINT AK_Username UNIQUE(Username),
	CONSTRAINT CHK_Password_Users CHECK(Len([Password]) >= 5)   
	)
	GO
	
-- 16. Write a SQL statement to create a view that displays the users from the Users table that have been in the system today.
--		- Test if the view works correctly.

	CREATE VIEW [Users logged today] AS
	SELECT UserId, Username, FullName, LastLoginTime
	FROM Users
	WHERE DATEDIFF(DAY, LastLoginTime, GETDATE()) = 0
	
-- 17. Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint).
--		- Define primary key and identity column.

	CREATE TABLE Groups(
		GroupId int IDENTITY PRIMARY KEY,
		Name nvarchar(50) NOT NULL UNIQUE
		)
	GO
	
-- 18. Write a SQL statement to add a column GroupID to the table Users.
--		- Fill some data in this new column and as well in the `Groups table.
--		- Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.

	ALTER TABLE Users
	ADD GroupId int
	GO
	
	ALTER TABLE Users
	ADD CONSTRAINT FK_Users_Groups
		FOREIGN KEY (GroupID) REFERENCES Groups(GroupId)
	GO  
	
-- 19. Write SQL statements to insert several records in the Users and Groups tables.

	INSERT INTO Groups VALUES
		('First group'),
		('Second group'),
		('Third group'),
		('Fourth group'),
		('Fifth group')

	INSERT INTO Users VALUES
		('Username1', 123456, 'User Name1', '10/18/15', 1),
		('Username2', 123456, 'User Name2', '10/16/15', 3),
		('Username3', 123456, 'User Name3', '10/17/15', 4),
		('Username4', 123456, 'User Name4', '10/18/15', 1),
		('Username5', 123456, 'User Name5', '10/18/15', 4),
		('Username6', 123456, 'User Name6', '10/13/15', 7),
		('Username7', 123456, 'User Name7', '10/11/15', 1)

-- 20. Write SQL statements to update some of the records in the Users and Groups tables.

	UPDATE Users
	SET FullName = 'User from group 4'
	WHERE GroupId = 4
	
	UPDATE Groups
	SET Name = REPLACE(Name, 'Second', '2nd')
	WHERE GroupId = 4

-- 21. Write SQL statements to delete some of the records from the Users and Groups tables.

	DELETE
	FROM Groups
	WHERE GroupId = 6
	
	DELETE
	FROM Users
	WHERE FullName LIKE 'User%' AND UserId % 4 = 0
	
-- 22. Write SQL statements to insert in the Users table the names of all employees from the Employees table.
--		- Combine the first and last names as a full name.
--		- For username use the first letter of the first name + the last name (in lowercase).
--		- Use the same for the password, and NULL for last login time

	ALTER TABLE Users
	ALTER COLUMN [Password] nvarchar(100)
	
	INSERT INTO Users (Username, [Password], FullName)
	SELECT LEFT(FirstName, 1) + LOWER(LastName) + CAST(EmployeeID AS nvarchar(10)), LEFT(FirstName, 1) + LOWER(LastName) + CAST(EmployeeID AS nvarchar(10)), FirstName + ' ' + LastName
	FROM Employees
	
-- 23. Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.

	UPDATE Users
	SET [Password] = NULL
	WHERE DATEDIFF(DAY, LastLoginTime, '10/03/10') > 0
	
-- 24. Write a SQL statement that deletes all users without passwords (NULL password).

	DELETE 
	FROM Users
	WHERE [Password] IS NULL
	
-- 25. Write a SQL query to display the average employee salary by department and job title.

	USE TelerikAcademy
	SELECT AVG(Salary), e.JobTitle, d.Name AS Departments
	FROM Employees e, Departments d
	WHERE e.DepartmentID = d.DepartmentID
	GROUP BY d.Name, e.JobTitle
	ORDER BY Departments
	
-- 26. Write a SQL query to display the minimal employee salary by department and job 
--		title along with the name of some of the employees that take it.

	USE TelerikAcademy
	SELECT d.Name AS Departments, e.JobTitle, MIN(Salary) AS [Minimal salary], MIN(CONCAT(e.FirstName, ' ', e.LastName)) AS [Employee]
	FROM Employees e, Departments d
	WHERE e.DepartmentID = d.DepartmentID
	GROUP BY d.Name, e.JobTitle
	ORDER BY Departments
	
-- 27. Write a SQL query to display the town where maximal number of employees work.

	USE TelerikAcademy
	SELECT TOP 1 t.Name, COUNT(t.Name) AS [Number of Employee]
	FROM Employees e, Towns t, Addresses a
	WHERE e.AddressID = a.AddressID AND a.TownID = t.TownID
	GROUP BY t.Name
	ORDER BY [Number of Employee] DESC
	
-- 28. Write a SQL query to display the number of managers from each town.

	USE TelerikAcademy
	SELECT t.Name, COUNT(t.Name) AS [Number of Manager]
	FROM Employees e, Towns t, Addresses a
	WHERE e.AddressID = a.AddressID AND a.TownID = t.TownID
	GROUP BY t.Name, e.ManagerID
	ORDER BY [Number of Manager] DESC
	
-- 29. Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments).
--		- Don't forget to define identity, primary key and appropriate foreign key.
--		- Issue few SQL statements to insert, update and delete of some data in the table.
--		- Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
--		- For each change keep the old record data, the new record data and the command (insert / update / delete).

	CREATE TABLE WorkHours (
	WorkReportId int IDENTITY,
	EmployeeId int NOT NULL,
	[Date] datetime NOT NULL,
	Task nvarchar(300),
	[Hours] int NOT NULL,
	Comments nvarchar(500),
	CONSTRAINT PK_WorkReport PRIMARY KEY(WorkReportId),
	CONSTRAINT FK_WorkHours_Employee
		FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId)
	)
	GO
	
	
-- insert

	DECLARE @counter int
	SET @counter = 1
	WHILE @counter <= 30
	BEGIN
		INSERT INTO WorkHours (EmployeeId, [Date], Task, [Hours])
		VALUES (@counter % 6, GETDATE(), 'Task #' + CAST(@counter AS nvarchar(20)), @counter % 7)
		SET @counter += 1
	END
	
-- update 

	UPDATE WorkHours
	SET Comments = 'Work hard'
	WHERE [Hours] > 4
	
-- delete

	DELETE
	FROM WorkHours
	WHERE [Hours] = 0
	
-- WorkHoursLogs table

	CREATE TABLE WorkHoursLogs (
	Id int IDENTITY PRIMARY KEY,
	WorkReportId int,
	EmployeeId int NOT NULL,
	[Date] datetime NOT NULL,
	Task nvarchar(300),
	[Hours] int NOT NULL,
	Comments nvarchar(500),
	[Changes] varchar(10) NOT NULL,
	CONSTRAINT FK_WorkHoursLogs_Employee
		FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId)
	)
	GO
	
-- delete

	CREATE TRIGGER TRG_WorkReports_WorkHours
	ON WorkHours
	FOR DELETE
	AS 
	INSERT INTO WorkHoursLogs  (WorkReportId, EmployeeId, [Date], Task, [Hours], Comments, [Changes])
    SELECT WorkReportId, EmployeeId, [Date], Task, [Hours], Comments, 'DELETE'
    FROM DELETED
	GO
	
-- insert
	
	CREATE TRIGGER TRG_WorkReportsInsert_WorkHours
	ON WorkHours
	FOR INSERT
	AS 
	INSERT INTO WorkHoursLogs  (WorkReportId, EmployeeId, [Date], Task, [Hours], Comments, [Changes])
    SELECT WorkReportId, EmployeeId, [Date], Task, [Hours], Comments, 'INSERT'
    FROM inserted
	GO
	
-- update

	CREATE TRIGGER TRG_WorkReportsUpdate_WorkHours
	ON WorkHours
	FOR UPDATE
	AS 
	INSERT INTO WorkHoursLogs  (WorkReportId, EmployeeId, [Date], Task, [Hours], Comments, [Changes])
    SELECT WorkReportId, EmployeeId, [Date], Task, [Hours], Comments, 'InsertUpdate'
    FROM inserted

	INSERT INTO WorkHoursLogs  (WorkReportId, EmployeeId, [Date], Task, [Hours], Comments, [Changes])
    SELECT WorkReportId, EmployeeId, [Date], Task, [Hours], Comments, 'DeleteUpdate'
    FROM deleted
	GO

-- 30. Start a database transaction, delete all employees from the 'Sales' department along with all dependent records from the pother tables.
--		- At the end rollback the transaction.

	BEGIN TRAN
		ALTER TABLE Departments
		DROP CONSTRAINT FK_Departments_Employees

		ALTER TABLE EmployeesProjects
		ADD CONSTRAINT FK_Departments_Employees_Cascade
		FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID) ON DELETE CASCADE
		GO

		DELETE e
			FROM Employees e
			JOIN Departments d
				ON e.DepartmentID = d.DepartmentID
			WHERE d.Name = 'Sales'

	ROLLBACK TRAN
	
-- 31. Start a database transaction and drop the table EmployeesProjects.
--		- Now how you could restore back the lost table data?

BEGIN TRANSACTION

    DROP TABLE EmployeesProjects

ROLLBACK TRANSACTION

-- 32. Find how to use temporary tables in SQL Server.
--		- Using temporary tables backup all records from EmployeesProjects and restore them back after dropping and re-creating the table.

	CREATE TABLE #TemporaryEmployeesProjects (
	EmployeeId int,
	ProjectId int
	)
	GO

	INSERT INTO #TemporaryEmployeesProjects
	SELECT *
	FROM EmployeesProjects
	GO

	DROP TABLE EmployeesProjects
	GO

	CREATE TABLE EmployeesProjects (
		EmployeeId int,
		ProjectId int,

		CONSTRAINT PK_EmployeesProjects 
		PRIMARY KEY(EmployeeID, ProjectId),

		CONSTRAINT FK_EmployeesProjects_Employees 
		FOREIGN KEY(EmployeeID) 
		REFERENCES Employees(EmployeeID),

		CONSTRAINT FK_EmployeesProjects_Projects 
		FOREIGN KEY(ProjectID) 
		REFERENCES Projects(ProjectID)
	)
	GO

	INSERT INTO EmployeesProjects
	SELECT *
	FROM #TemporaryEmployeesProjects
	GO