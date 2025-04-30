SET TRANSACTION ISOLATION LEVEL READ COMMITTED
DBCC USEROPTIONS
SELECT @@TRANCOUNT


/*DIRTY READ---If i try get records from employees I wont get and it will be in loop as dirty read is not possible for read committed isolation 
level*/
BEGIN TRANSACTION 
SELECT *FROM Employees
COMMIT TRANSACTION


/*PHANTOM READ*/
BEGIN TRANSACTION
INSERT INTO Employees VALUES('E0','NewPhantom',34000,'D7','M3')
COMMIT TRANSACTION

/*NONREPEATBLE READ*/
BEGIN TRANSACTION
UPDATE Employees SET Emp_Name='Paltech' WHERE EmployeeID='E0'
COMMIT TRANSACTION



/*------------------------------------------------------REPEATABLE READ-------------------------------------------------------------------------------*/
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
/*DIRTY READ*/
BEGIN TRANSACTION 
SELECT *FROM Employees
COMMIT TRANSACTION

/*NONREPEATBLE READ*/
BEGIN TRANSACTION
UPDATE Employees SET Emp_Name='sdfghj' WHERE EmployeeID='E0'
COMMIT TRANSACTION

/*PHANTOM READ*/
BEGIN TRANSACTION
INSERT INTO Employees VALUES('E01','NewPhantom',34000,'D7','M3')
COMMIT TRANSACTION


/*-----------------------------------------------------------SERIALIZABLE----------------------------------------------------------------------------*/
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
BEGIN TRANSACTION 
SELECT *FROM Employees
COMMIT TRANSACTION


/*NONREPEATBLE READ*/
BEGIN TRANSACTION
UPDATE Employees SET Emp_Name='sdfghj' WHERE EmployeeID='E0'
COMMIT TRANSACTION

/*PHANTOM READ*/
BEGIN TRANSACTION
INSERT INTO Employees VALUES('E01','NewPhantom',34000,'D7','M3')
COMMIT TRANSACTION