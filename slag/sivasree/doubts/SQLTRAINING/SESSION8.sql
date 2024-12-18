/*--------------------------------------------------------USER-DEFINED FUNCTIONS(3 types)----------------------------------------------------------------------*/
/*system parameterised function*/
SELECT SQUARE(2);
/*system parameterless function*/
SELECT GETDATE();

/*--------------------------------------------1.SCALAR FUNCTION----takes >=0 parametrs and returns a single value-----------------------------------*/
/*scalar is of 2 types : 1.inline scalar function(if there is only one operation in body)   
2.multiline scalar function(multiple operations in body)
*/
CREATE FUNCTION Scalarfun(@Gender varchar(30))
RETURNS INT
AS
BEGIN
   DECLARE @Res int;
   SELECT  @Res=COUNT(*) FROM Customers WHERE Gender=@Gender
   RETURN @Res;
END
/*while calling scalar function we have to use dbo.func_Name/DB_NAME.dbo.func_NAME*/
SELECT dbo.Scalarfun('M');
SELECT Prac.dbo.Scalarfun('f');

EXEC sp_helptext Scalarfun;
/*alter*/
ALTER FUNCTION Scalarfun(@Gender varchar(30))
RETURNS INT
AS
BEGIN
   DECLARE @Res int;
   SELECT  @Res=COUNT(Name) FROM Customers WHERE Gender=@Gender
   RETURN @Res;
END

/*DROPPPING FUNCTION*/
DROP FUNCTION Scalarfun;



/*---------------------------------------------------------2.INLINE Table fuctions(treat as table)------------------------------------------------------------*/
/*returns table---TREAT IT JUST AS TABLE AND PERFORM ALL KIND OF SQL COMMANDS LIKE JOINS,SELECT ETC...
  no begin,end
  structure of returned table is determined by select statement in the body
 */
CREATE FUNCTION getEmployeeByGender(@Gender varchar(30))
RETURNS Table
AS
Return (SELECT * from customers )

/*calling the inline function*/
SELECT *FROM getEmployeeByGender('M');
/*We can apply joins on inline table functions as below*/
SELECT c.Name,c.Gender FROM Customers c
JOIN getEmployeeByGender('M') g
ON g.CustomerID=c.CustomerID;




/*--------------------------------------------------MULTI TABLE valued FUNCTIONS--------------------------------------------------------------------------*/
CREATE FUNCTION MultiFunction()
RETURNS @Table TABLE(ID int,Name varchar(40))                 --we specify the structure of the returned table,@Table is a varaible
AS
BEGIN
     INSERT INTO @Table 
	 SELECT CustomerID,Name FROM Prac.dbo.Customers;
	 RETURN
END


/*CALLING MULTI TABLE FUNC*/
SELECT *FROM MultiFunction();


/*differences btw inline and multi
1.return table structure can be defined in multi
2.begin and end for multi
3.inline has more performance than multi----- bcus inline is treated as view and multi as stored proc
4.underlyding table can me modified using inline but not multi
*/
/*above 4th point prrof*/
UPDATE getEmployeeByGender('M') SET Name='MARKONI' WHERE Name='Mark'
UPDATE MultiFunction() SET Name='MARKONI23' WHERE Name='MARKONI'




/*-------------------------------------------------------ENCRYPTION,SCHEMA BINDING------------------------------------------------------------------*/

CREATE FUNCTION EncryptFunc()
RETURNS int
AS
BEGIN
    Return (SELECT COUNT(*) FROM Customers)
END

SELECT dbo.EncryptFunc()
EXEC sp_helptext EncryptFunc

ALTER FUNCTION EncryptFunc()
RETURNS int
WITH ENCRYPTION
AS
BEGIN
    Return (SELECT COUNT(*) FROM Customers)
END
EXEC sp_helptext EncryptFunc

/*if we drop the table and try to exeute the function we get error as underlying table is dropped*/
DROP TABLE Customers;
SELECT dbo.EncryptFunc()

/*so to avoid this kind of irregularities we make the function schema binding*/
CREATE TABLE Customers(CustomerID int,Name varchar(70),Salary int,Gender char(2));
INSERT INTO Customers Values(1,'Mark',5000,'M');
INSERT INTO Customers Values(1,'John',4500,'M');
INSERT INTO Customers Values(1,'Pam',5500,'F');
INSERT INTO Customers Values(1,'Sara',4000,'F');
INSERT INTO Customers Values(1,'Todd',3500,'M');
INSERT INTO Customers Values(1,'Mary',5000,'F');
INSERT INTO Customers Values(1,'Ben',6500,'M');
INSERT INTO Customers Values(1,'Jodi',7000,'f');
INSERT INTO Customers Values(1,'Tom',5500,'M');
INSERT INTO Customers Values(1,'Ron',5000,'M');
SELECT *FROM Customers

ALTER FUNCTION EncryptFunc()
RETURNS int
WITH SCHEMABINDING
AS
BEGIN
    Return (SELECT COUNT(*) FROM dbo.Customers)
END

/*now if we try dropping the customers table we get error as we have made the function schema binding that means underlying table cant be modified*/
DROP TABLE Customers;

/*we can alter and truncate*/
TRUNCATE TABLE Customers
ALTER TABLE Customers
ALTER COLUMN Name varchar(90)
EXEC sp_help Customers;
ALTER TABLE Customers
ADD  NName varchar(90)
ALTER TABLE Customers
DROP COLUMN  NName 
SELECT dbo.EncryptFunc()





/*---------------------------------------------------------------CURSORS------------------------------------------------------------------------------*/
/*CURSORS CAN BE REPLACED BY JOINS AS ITS PERFORMANCE IS LOW(as it is row by row)
JOINS work on set basis so they are fast*/
/*operate on row by row basis as it is a pointer to a row*/
/*LIFE CYCLE OF CURSOR has 3 steps*/
/*1.DECLARE the Cursor*/
DECLARE @ID int,@Name varchar(67);
DECLARE cursor_pointer1 CURSOR FOR 
SELECT CustomerID,Name FROM Customers;

/*2.Open the cursor, here the cursor is populated with result set of the query written*/
OPEN cursor_pointer1

/*In the beginning cursor is not pointing to any row but later we moved the cursor to point the first row as below*/
FETCH NEXT FROM cursor_pointer1 into @ID, @Name
/*3.fetching the rows*/
WHILE(@@FETCH_STATUS =0)                                                 --as lomg as we have rows in resultset @@Fetch_Status returns 0
BEGIN 
/*4.processing fetched rows*/
    PRINT  'ID=' +CAST(@ID AS varchar(89))+ 'Name=' + @Name
    FETCH NEXT FROM cursor_pointer1 into @ID,@Name
/*5.loop through the cursor*/
END
/*6.Close the cursor*/
CLOSE cursor_pointer1
/*7.Deallocate the cursor*/
DEALLOCATE cursor_pointer1




/*---------------------------------------------------------TYPES OF CURSORS-------------------------------------------------------------------------*/
/*STATIC CURSOSRS---makes the copy of result set i.e; why though we make any changes to the original tables they dont get reflected in cursor
in tempdb result set is stored
 These are scrollable LAST,FIRST,PRIOR,ABSOLUTE,RELATIVE,NEXT*/

DECLARE @Name varchar(67);
DECLARE StaticCursor_Pointer CURSOR STATIC FOR 
SELECT Name FROM Customers;

OPEN StaticCursor_Pointer
FETCH RELATIVE 11 FROM StaticCursor_Pointer INTO @Name
WHILE(@@FETCH_STATUS =0)
BEGIN
    
    waitfor delay '00:00:02'
    PRINT 'Name is ' + @Name
	FETCH NEXT FROM StaticCursor_Pointer INTO @Name
END
CLOSE StaticCursor_Pointer
DEALLOCATE StaticCursor_Pointer


SELECT *FROM Customers;
INSERT INTO Customers VALUES(2,'SRIVALLI',8000,'F')



/*FORWARD ONLY STATIC CURSOR-----STATIC + NEXT*/
DECLARE @Name varchar(67);
DECLARE StaticCursor_Pointer CURSOR  
FORWARD_ONLY STATIC
FOR
SELECT Name FROM Customers;

OPEN StaticCursor_Pointer
FETCH NEXT FROM StaticCursor_Pointer INTO @Name
WHILE(@@FETCH_STATUS =0)
BEGIN
    waitfor delay '00:00:01'
    PRINT 'Name is ' + @Name
	FETCH NEXT FROM StaticCursor_Pointer INTO @Name
END
CLOSE StaticCursor_Pointer
DEALLOCATE StaticCursor_Pointer


/*DYNAMIC CURSORS-----results are calculated on the fly
if we make chnages to underlying table they get reflected in the cursor
by default DYNAMIC FORWARD-ONLY*/
DECLARE @Name varchar(67);
DECLARE StaticCursor_Pointer CURSOR DYNAMIC FOR 
SELECT Name FROM Customers;

OPEN StaticCursor_Pointer
FETCH RELATIVE 11 FROM StaticCursor_Pointer INTO @Name
WHILE(@@FETCH_STATUS =0)
BEGIN
    
    waitfor delay '00:00:02'
    PRINT 'Name is ' + @Name
	FETCH NEXT FROM StaticCursor_Pointer INTO @Name
END
CLOSE StaticCursor_Pointer
DEALLOCATE StaticCursor_Pointer

/*Forward-only dynamic*/
DECLARE @Name varchar(67);
DECLARE StaticCursor_Pointer CURSOR 
Forward_only dynamic 
FOR 
SELECT Name FROM Customers;

OPEN StaticCursor_Pointer
FETCH NEXT 11 FROM StaticCursor_Pointer INTO @Name
WHILE(@@FETCH_STATUS =0)
BEGIN
    
    waitfor delay '00:00:02'
    PRINT 'Name is ' + @Name
	FETCH NEXT FROM StaticCursor_Pointer INTO @Name
END
CLOSE StaticCursor_Pointer
DEALLOCATE StaticCursor_Pointer






/*DIFFERENCES BETWEEN STORED PROCEDURES AND FUNCTIONS*/
/*1.We cannot use DML Statements(UPDATE,INSERT,DELETE) in functions but we can use those in Stored procedure*/
CREATE FUNCTION Scalarfun1(@Gender varchar(30))
RETURNS INT
AS
BEGIN
   DECLARE @Res int;
   --INSERT INTO Customers VALUES(23,'sree',12000,'H');
   --UPDATE Customers SET Name='MARK MOWA' WHERE Name='MARKONI'
   --DELETE FROM Customers WHERE Name='MARKONI'
   
   SELECT  @Res=COUNT(*) FROM Customers WHERE Gender=@Gender
   RETURN @Res;
END

/*2.We can return only one value in function but in sp we can have many output types*/
/*3.in select /where /order by we can use functions but not SP*/
/*SP in functions not possible ,functions in SP possible*/
/*exception handling not possible in functions but in sp we can*/
ALTER FUNCTION Scalarfun1(@Gender varchar(30))
RETURNS INT
AS
BEGIN
   DECLARE @Res int;
   --EXEC sp_help Customers;
   SELECT  @Res=COUNT(*) FROM Customers WHERE Gender=@Gender
   RETURN @Res;
END

CREATE PROCEDURE ScalarProc1(@Gender varchar(30))
AS
BEGIN
   DECLARE @Res int;
   SELECT dbo.Scalarfun1('M');
   SELECT  @Res=COUNT(*) FROM Customers WHERE Gender=@Gender
   RETURN @Res;
END

EXEC ScalarProc1 'M'



/*0,-1,-2,-9 in cursors*/
DECLARE TestCursor CURSOR FOR
SELECT CustomerID FROM Customers;
OPEN TestCursor
DECLARE @ID int;
FETCH NEXT FROM TestCursor INTO @ID
WHILE(@@FETCH_STATUS=0)
BEGIN
   PRINT 'ID is '+ CAST(@ID AS Varchar(40)) + 'fetchstatus'+ CAST( @@FETCH_STATUS AS varchar(30))
   FETCH NEXT FROM TestCursor INTO @ID
END
PRINT 'AFTER loop fetch status is:' + CAST( @@FETCH_STATUS AS varchar(30))
CLOSE TestCursor 




INSERT INTO Customers VALUES(null,'sathvik',12334,'M')
DECLARE TestCursor1 CURSOR 
Dynamic
FOR
SELECT CustomerID FROM Customers;
OPEN TestCursor1
DECLARE @ID int;
PRINT @@FETCH_STATUS
FETCH LAST FROM TestCursor1 INTO @ID
FETCH NEXT FROM TestCursor1
PRINT @@FETCH_STATUS
WHILE(@@FETCH_STATUS=0)
BEGIN
   PRINT 'ID is '+ CAST(@ID AS Varchar(40)) + 'fetchstatus'+ CAST( @@FETCH_STATUS AS varchar(30))
   FETCH NEXT FROM TestCursor INTO @ID
END
PRINT 'AFTER loop fetch status is:' + CAST( @@FETCH_STATUS AS varchar(30))
CLOSE TestCursor1 




















use AdventureWorks2022
declare employee_data CURSOR
forward_only
FOR select * from HumanResources.Employee

SELECT LEN('Vice President of Engineeringaaaaaaaaaa');
 
 
Open employee_data
fetch next from employee_data
 
while @@FETCH_STATUS = 0
	begin
	  update HumanResources.Employee
	  set JobTitle = Jobtitle + 'a'
	  fetch next from employee_data
	  end

close employee_data






















/*DIFFERENCE BETWEEN STORED PROC AND FUNCTIONS is we can use functions in select ,where clause but stored proc's we cannot*/








































