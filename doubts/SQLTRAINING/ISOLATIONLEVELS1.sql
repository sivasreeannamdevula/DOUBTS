SET TRANSACTION ISOLATION LEVEL READ COMMITTED
SELECT *FROM Employees
DBCC USEROPTIONS
SELECT @@TRANCOUNT


/*DIRTY READ*/
BEGIN TRANSACTION
UPDATE Employees SET Emp_Name='read committed' WHERE EmployeeID='E1'
ROLLBACK TRANSACTION

/*Phantom READ*/
BEGIN TRANSACTION
SELECT *FROM Employees WHERE DepartmentID='D7'
--after executing transaction2,where we inserted/deleted rows....then the no.of rows varies
SELECT *FROM Employees WHERE DepartmentID='D7'
ROLLBACK TRANSACTION

/*NON-REPEATABLE READ*/
BEGIN TRANSACTION
SELECT *FROM Employees WHERE EmployeeID='E0'
SELECT *FROM Employees WHERE EmployeeID='E0'
COMMIT TRANSACTION

/*-----------------------------------------------------------REPEATABLE READ----------------------------------------------------------------------*/
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
/*DIRTY READ*/
BEGIN TRANSACTION
UPDATE Employees SET Emp_Name='read committed' WHERE EmployeeID='E1'
ROLLBACK TRANSACTION

/*NON-REPEATABLE READ*/
BEGIN TRANSACTION
SELECT *FROM Employees WHERE EmployeeID='E0'
SELECT *FROM Employees WHERE EmployeeID='E0'
COMMIT TRANSACTION

/*Phantom READ*/
BEGIN TRANSACTION
SELECT *FROM Employees WHERE DepartmentID='D7'
--after executing transaction2,where we inserted/deleted rows....then the no.of rows varies
SELECT *FROM Employees WHERE DepartmentID='D7'
ROLLBACK TRANSACTION


/*-------------------------------------------------------SERIALISABLE-----------------------------------------------------------------------------*/
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
/*DIRTY READ*/
BEGIN TRANSACTION
UPDATE Employees SET Emp_Name='read committed' WHERE EmployeeID='E1'
ROLLBACK TRANSACTION

/*NON-REPEATABLE READ*/
BEGIN TRANSACTION
SELECT *FROM Employees WHERE EmployeeID='E0'
SELECT *FROM Employees WHERE EmployeeID='E0'
COMMIT TRANSACTION

/*Phantom READ*/
BEGIN TRANSACTION
SELECT *FROM Employees WHERE DepartmentID='D7'
--after executing transaction2,where we inserted/deleted rows....then the no.of rows varies
SELECT *FROM Employees WHERE DepartmentID='D7'
ROLLBACK TRANSACTION

