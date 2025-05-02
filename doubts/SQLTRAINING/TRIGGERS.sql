/*------------------------------------------------------------TRIGGERS--------------------------------------------------------------------------------*/
/*3 TYPES
  1.DML Triggers
  2.DDL triggers
  3.Logon triggers
*/

/*DML Tiggers are 2 types 
1.After triggers/FOR triggers 
2.Instead of triggers*/


/*AFTER DML TRIGGERS*/
/*inserted table is created automatically for the table(Customers) used in triggers when we try to insert 
---from this table we can fetch info to store in any other table as it contains the row info that we r inserting(Sales for ex)
inserted table schema is same as trigger table(customers)
inserted table can be used only inside the trigger and it is in-memory storage*/
ALTER TRIGGER tr_insert
ON Customers
FOR INSERT
AS
BEGIN
    --Declare @Id int;
	--SELECT @Id=CustomerID FROM inserted;
	--INSERT INTO Sales VALUES(@Id,'samsung',12300);
	SELECT *FROM inserted
END

INSERT INTO Customers VALUES(67,'ABC',3300,'F')
SELECT *FROM Sales
SELECT *FROM CUSTOMERS;

/*AFTER DELETE TRIGGER*/
/*deleted table contains the row getting deleted*/
CREATE TRIGGER tr_delete
ON Customers
FOR delete
AS
BEGIN
    DECLARE @Id int;
	SELECT @Id=CustomerID from deleted;
	INSERT INTO Sales VALUES(21,'deleted',23456);
END

DELETE FROM Customers WHERE Name='MARKONI'
SELECT *FROM Customers; 
SELECT *FROM Sales;



/*AFTER UPDATE TRIGGER*/
/*here the inserted table contains the new data and the deleted table contains the row to be  deleted*/



/*instead of Update trigger*/
SELECT *FROM Employees
SELECT *FROM Department
SELECT *FROM triggered_View
/*if we try to update multiple tables using view then we get error like multiple base tables getting modified....
if we try to update a single table then we dont get any error but the data will be inconsisitent*/
Update triggered_View SET DepartName='Pals' WHERE EmployeeID='E99'
CREATE TRIGGER insteadUpdate
ON triggered_View
INSTEAD OF update
AS
BEGIN
    if(UPDATE(DepartName))        --UPDATE is the function that tells what column is being updated in the update statement
	  BEGIN
	      DECLARE @DeptID varchar(7);
		  SELECT 
	  END

END