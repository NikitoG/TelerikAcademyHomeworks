--1. What is SQL? What is DML? What is DDL? Recite the most important SQL commands.
--	- SQL - for Structured Query Language.SQL is used to communicate with a database, it is the standard language for relational database management systems.
--	Some common relational database management systems that use SQL are: Oracle, Sybase, Microsoft SQL Server, Access, Ingres, etc.
--	- A data manipulation language (DML) is a family of computer languages including commands permitting users to manipulate data in a database. 
--	This manipulation involves inserting data into database tables, retrieving existing data, deleting data from existing tables and modifying existing data. 
--	DML is mostly incorporated in SQL databases.
--	- Data Definition Language (DDL) is a standard for commands that define the different structures in a database. DDL statements create, modify, 
--	and remove database objects such as tables, indexes, and users. Common DDL statements are CREATE, ALTER, and DROP.

--2. What is Transact-SQL (T-SQL)?
--	- T-SQL (Transact-SQL) is a set of programming extensions from Sybase and Microsoft that add several features to the Structured Query Language (SQL) 
--	including transaction control, exception and error handling, row processing, and declared variables. 

--3. Start SQL Management Studio and connect to the database TelerikAcademy. Examine the major tables in the "TelerikAcademy" database.
--	- Done :)
	
--4. Write a SQL query to find all information about all departments (use "TelerikAcademy" database).

USE TelerikAcademy
SELECT *
FROM Departments

--5. Write a SQL query to find all department names.

USE TelerikAcademy
SELECT Name
FROM Departments

--6. Write a SQL query to find the salary of each employee.

USE TelerikAcademy
SELECT FirstName + ' ' + LastName AS FullName, Salary
FROM Employees

--7. Write a SQL to find the full name of each employee.

USE TelerikAcademy
SELECT FirstName + ' ' + LastName AS FullName
FROM Employees

--8. Write a SQL query to find the email addresses of each employee (by his first and last name). 
--Consider that the mail domain is telerik.com. Emails should look like "John.Doe@telerik.com". The produced column should be named "Full Email Addresses".

USE TelerikAcademy
SELECT FirstName + '.' + LastName + '@telerik.com' AS [Full Email Addresses]
FROM Employees

--9. Write a SQL query to find all different employee salaries.

USE TelerikAcademy
SELECT DISTINCT Salary
FROM Employees

--10. Write a SQL query to find all information about the employees whose job title is “Sales Representative“.

USE TelerikAcademy
SELECT FirstName + ' ' + LastName AS [Full Name], JobTitle
FROM Employees
WHERE JobTitle = 'Sales Representative'

--11. Write a SQL query to find the names of all employees whose first name starts with "SA"

USE TelerikAcademy
SELECT FirstName + ' ' + LastName AS [Full Name]
FROM Employees
WHERE FirstName LIKE 'SA%'

--12. Write a SQL query to find the names of all employees whose last name contains "ei".

USE TelerikAcademy
SELECT FirstName + ' ' + LastName AS [Full Name]
FROM Employees
WHERE LastName LIKE '%ei%'

--13. Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].

USE TelerikAcademy
SELECT FirstName + ' ' + LastName AS [Full Name], Salary
FROM Employees
WHERE Salary > 20000 AND Salary < 30000

--14. Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.

USE TelerikAcademy
SELECT FirstName + ' ' + LastName AS [Full Name], Salary
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600)

--15. Write a SQL query to find all employees that do not have manager.

USE TelerikAcademy
SELECT FirstName + ' ' + LastName AS [Full Name]
FROM Employees
WHERE ManagerID IS NULL

--16. Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary.

USE TelerikAcademy
SELECT FirstName + ' ' + LastName AS [Full Name], Salary
FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC

--17. Write a SQL query to find the top 5 best paid employees.

USE TelerikAcademy
SELECT TOP 5 FirstName + ' ' + LastName AS [Full Name], Salary
FROM Employees
ORDER BY Salary DESC

--18. Write a SQL query to find all employees along with their address. Use inner join with ON clause.

USE TelerikAcademy
SELECT e.FirstName + ' ' + e.LastName AS [Full Name], a.AddressText
FROM Employees e
INNER JOIN Addresses a
ON e.AddressID = a.AddressID

--19. Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause).

USE TelerikAcademy
SELECT e.FirstName + ' ' + e.LastName AS [Full name], a.AddressText
FROM Employees e, Addresses a
WHERE e.AddressID = a.AddressID

--20. Write a SQL query to find all employees along with their manager.

USE TelerikAcademy
SELECT e.FirstName + ' ' + e.LastName AS [Employee full name], m.FirstName + ' ' + m.LastName AS [Manager full name]
FROM Employees e 
INNER JOIN Employees m
ON e.ManagerID = m.EmployeeID

--21. Write a SQL query to find all employees, along with their manager and their address. Join the 3 tables: Employees e, Employees m and Addresses a.

USE TelerikAcademy
SELECT e.FirstName + ' ' + e.LastName AS [Employee full name], m.FirstName + ' ' + m.LastName AS [Manager full name], a.AddressText
FROM Employees e, Employees m, Addresses a
WHERE e.ManagerID = m.EmployeeID AND e.AddressID = a.AddressID

--22. Write a SQL query to find all departments and all town names as a single list. Use UNION.

USE TelerikAcademy
SELECT Name AS [Depatments and Towns Name]
FROM Departments
UNION
SELECT Name
FROM Towns AS [Depatments and Towns Name]

--23. Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager. 
--Use right outer join. Rewrite the query to use left outer join.

-- Right outer join
USE TelerikAcademy
SELECT e.FirstName + ' ' + e.LastName as Employee,
ISNULL(m.FirstName + ' ' + m.LastName, 'Big Boss') as Manager
FROM Employees m
RIGHT OUTER JOIN Employees e
ON e.ManagerID = m.EmployeeID

--Left outer join
USE TelerikAcademy
SELECT e.FirstName + ' ' + e.LastName as Employee,
ISNULL(m.FirstName + ' ' + m.LastName, 'Big Boss') as Manager
FROM Employees e
LEFT OUTER JOIN Employees m
ON e.ManagerID = m.EmployeeID

--24. Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005.

USE TelerikAcademy
SELECT e.FirstName + ' ' + e.LastName AS [Full Name], d.Name, e.HireDate
FROM Employees e, Departments d
WHERE e.DepartmentID = d.DepartmentID AND d.Name IN ('Sales', 'Finance') AND YEAR(HireDate) BETWEEN 1995 AND 2005
