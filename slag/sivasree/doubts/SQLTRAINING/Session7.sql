/*--------------------------------------------------------------VIEWS-------------------------------------------------------------------------------*/
/*Virtual table--no data is stored in view
  Security
  No diff in performance btw VIEW n internal subquery as both does the same i.e; executing the query insisde.
  */
CREATE VIEW PracView2
AS
SELECT Name,Salary FROM Customers;

SELECT *FROM PracView2;

create login NewUser with password='StrongP@ssw0d!'
 
use database
 
create user newUser for login NewUser
 
grant select on Customers to newUser

drop user sreesiva;

/*--------------------------------------------------------------STORED PROCEDUE-----------------------------------------------------------------------*/

CREATE TABLE ProductsSP(Product_code varchar(30),Product_Name varchar(50),Price float,Quantity_left int,Quantity_Sold int);
INSERT INTO ProductsSP VALUES('P1','iphn 13',25000,5,195);
INSERT INTO ProductsSP VALUES('P2','airpods 13',250,10,90);
INSERT INTO ProductsSP VALUES('P3','Mac 13',5000,2,48);
INSERT INTO ProductsSP VALUES('P4','iPad 13',200,1,9);
SELECT *FROM ProductsSP;
CREATE TABLE SalesSP(Order_id int,order_date date,Product_code varchar(30),Quantity_ordered int,SoldPrice float);
INSERT INTO SalesSP VALUES(1,'2024-2-2','P1',100,120000);
INSERT INTO SalesSP VALUES(2,'2024-2-20','P1',50,60000);
INSERT INTO SalesSP VALUES(3,'2024-2-5','P1',45,54000);
SELECT *FROM SalesSP;

/*parameterless stored procedure creation*/
/*Create or alter means if already procedure present then replace else create*/
CREATE OR ALTER PROCEDURE FirstSP
AS
DECLARE @code varchar(80),@price int;
BEGIN
    SELECT @code=Product_Code,@price=Price FROM ProductsSP WHERE Product_Name='iphn 13'
    INSERT INTO SalesSP VALUES(4,'2024-12-14',@code,1,@price*1);
	UPDATE ProductsSP SET Quantity_left=Quantity_left-1, Quantity_Sold=Quantity_Sold+1	
	WHERE Product_Code=@code;
	PRINT('SOLD SUCCESSFULLY')
END

/*calling stored procedure*/
EXEC FirstSP;


/*Parameterised Stored Procedure*/
CREATE PROCEDURE SecondSP(@product_name varchar(40),@Quantity int)
AS
DECLARE @code varchar(30),@price int,@count int;
BEGIN
  SELECT @count=Count(*) FROM ProductsSP WHERE Product_Name=@product_name AND Quantity_left>=@Quantity
  PRINT(@count);
  if @count>0
  BEGIN
    SELECT @code=Product_Code,@price=Price FROM ProductsSP WHERE Product_Name=@product_name
    INSERT INTO SalesSP VALUES(4,'2024-12-14',@code,1,@price*@Quantity);
	UPDATE ProductsSP SET Quantity_left=Quantity_left-@Quantity, Quantity_Sold=Quantity_Sold+@Quantity	
	WHERE Product_Code=@code;
	PRINT('SOLD SUCCESSFULLY');
	END
  ELSE
    BEGIN
    PRINT('INSUFFICIENT QUNATIYT');
    END
END

EXEC SecondSP'iPad 13',1  ;

/*Dropping stored procedure*/
DROP PROCEDURE SecondSP;

/*altering stored procedure*/
ALTER PROCEDURE FirstSP
AS
DECLARE @code varchar(80),@price int;
BEGIN
   
	PRINT('ALTERED SUCCESSFULLY')
END


/*-----------------------------------------------------------OPTIONAL PARAMETERS---------------------------------------------------------------------*/
/*always optional parameters should be at the end then directly in function call we can omit passing values else we have to pass it explicitly with 
names (EXEC SecondSP2 @Product_code='P27',@Price=13.3,@Quantity_Sold=234;)*/
CREATE PROCEDURE SecondSP2(@Product_code varchar(30),
                          @Product_Name varchar(50),
						  @Price float,
						  @Quantity_left int,
						  @Quantity_Sold int)
AS
BEGIN
     INSERT INTO ProductsSP VALUES(@Product_code,@Product_Name,@Price,@Quantity_left,@Quantity_Sold);
END

/*GETDATE() or anyother functions cannot be passed as parameter to stored procedure*/
--EXEC SecondSP2 'P24','asdf',21,34,GETDATE();
EXEC SecondSP2 'P23','sivasree',13.3,1,234;
/*We can also pass as below if we dont want to maintain the order of parameters...*/
EXEC SecondSP2 @Product_code='P23',@Price=13.3,@Quantity_Sold=234,@Product_Name='sivasree',@Quantity_left=1;

ALTER PROCEDURE SecondSP2(@Product_code varchar(30),
                          @Product_Name varchar(50)='NOT GIVEN',
						  @Price float,
						  @Quantity_left int = 2000,
						  @Quantity_Sold int)
AS
BEGIN
     INSERT INTO ProductsSP VALUES(@Product_code,@Product_Name,@Price,@Quantity_left,@Quantity_Sold);
END

EXEC SecondSP2 @Product_code='P27',@Price=13.3,@Quantity_Sold=234;


/*---------------------------------------------------------------INPUT/OUTPUT parameters-------------------------------------------------------------*/
/*by default if we donot specify then it is input parameter
OUTPUT/OUT Both are same*/
CREATE PROCEDURE CustomerSP(@Gender varchar(78),@countByGender int OUTPUT)
AS
BEGIN
   SELECT @countByGender=COUNT(*) FROM Customers WHERE Gender=@Gender;
END
DECLARE @result int;
--EXEC CustomerSP 'M',@result OUTPUT
EXEC CustomerSP @countByGender=@result OUTPUT,@Gender='F'
EXEC CustomerSP 'M', @result OUTPUT
PRINT @result



CREATE PROCEDURE CustomerSP2(@Gender varchar(78),@countByGenderMale int OUTPUT,@countGenderFemale int OUTPUT)
AS
BEGIN
   SELECT @countByGenderMale=COUNT(*) FROM Customers WHERE Gender=@Gender;
   SET @countGenderFemale=900000
END
DECLARE @malecount int,@femalecount int;
EXEC CustomerSP2 'M',@malecount output,@femalecount output
print @malecount
print @femalecount



/*---------------------------------------------------------------SYSTEM STORED PROCEDURE------------------------------------------------------------*/
/*gives the info about stored procedure like paramters and its datatypes,return type etc*/
EXEC sp_help CustomerSP2
/*to know what is written in stored procedure*/
EXEC sp_helptext CustomerSP2
/*to know on what tables our stored proc is dependent on*/
EXEC sp_depends CustomerSP2;





/*----------------------------------------------------------ENCRYPTING STORED PROCEDURE----------------------------------------------------------------*/
/*just use WITH ENCRYPTION in create/alter stored proc*/
ALTER PROCEDURE CustomerSP2(@Gender varchar(78),@countByGenderMale int OUTPUT,@countGenderFemale int OUTPUT) WITH ENCRYPTION
AS
BEGIN
   SELECT @countByGenderMale=COUNT(*) FROM Customers WHERE Gender=@Gender;
   SET @countGenderFemale=900000
END

EXEC sp_helptextCustomerSP2;






/*-----------------------------------------------------------RETURN VALUES IN STORED PROCEDURES------------------------------------------------------*/
/* same as functions returning in any programming language*/
CREATE PROCEDURE CountPPl
AS
BEGIN
   return (SELECT COUNT(*) FROM Customers)
END

DECLARE @countppl int;
EXEC @countppl=CountPPl
PRINT @countppl;

/*we can return only int values using return but with output parameters we can get any datatype os output
   using return values we can return only one value but with output parameters we can return any number of values*/
CREATE PROCEDURE GiveName
AS
BEGIN
   return (SELECT Name FROM Customers WHERE Gender='f' AND Salary=7000)
END

DECLARE @Name nvarchar(40)
/*ERROR:Conversion failed when converting the varchar value 'Jodi' to data type int.*/
EXEC @Name=GiveName



/*ADVANTAGES OF STORED PROCEDURES
1.Execution plan reusablility (though both sql statements and stored proc reuse the execution plan but in case of sql statements if there is 
                                atleast a small change(maybe like space even) then again new execution plan gets created)
2.Reduces network traffic(as we no need to pass 1000's of lines of stored proc as that of sql statements)
3Code reusability(as stored proc is a fucntion we can reuse).
4.security---permission can be given to execute the store proc but not to see the underlysing tables
5.avoids sql injection*/
