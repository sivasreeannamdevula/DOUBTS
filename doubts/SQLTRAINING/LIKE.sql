USE adventure;
SELECT *FROM HumanResources.Employee;

/*alias names for table*/
SELECT * FROM HumanResources.Employee AS hrEmp;

/*alias names for columns*/
SELECT NationalIDNumber,LoginID AS ID,JobTitle AS Title FROM HumanResources.Employee;

/*Calculations on columns*/
SELECT SickLeaveHours + VacationHours AS Summed FROM HumanResources.Employee ;





/*-------------------------------------------------------------------------------WHERE CLAUSE--------------------------------------------------------------------------------------*/
SELECT *FROM HumanResources.Employee WHERE JobTitle = 'Research and Development Manager';
SELECT *FROM HumanResources.Employee WHERE BusinessEntityID=4;






/*------------------------------------------------------------------BETWEEN---AND (boundary values are inclusive)----------------------------------------------------*/
/*for varchar datatype*/
SELECT *FROM HumanResources.Employee WHERE JobTitle BETWEEN 'Accountant' AND 'Application Specialist';
/*for int datatype*/
/*1,4 are inclusive*/
SELECT *FROM HumanResources.Employee WHERE BusinessEntityID BETWEEN 1 AND 4;
/*if no proper order maintained then we get empty result*/
SELECT *FROM HumanResources.Employee WHERE BusinessEntityID BETWEEN 8 AND 4;   
/*for date datatype*/
SELECT HireDate FROM HumanResources.Employee WHERE HireDate BETWEEN '2008-01-31' AND '2009-01-14';
SELECT HireDate FROM HumanResources.Employee WHERE HireDate BETWEEN '2009-01-14' AND '2008-01-31';
/*to exclude the boundary values we can use >,< symbols*/
SELECT *FROM HumanResources.Employee WHERE BusinessEntityID>1 AND BusinessEntityID<4;
/*between--and can be used to handle null values I.E; they are not included in the results*/
DECLARE @min int=2;
DECLARE @max int=10;
SELECT *FROM HumanResources.Employee WHERE BusinessEntityID BETWEEN @min AND @max;






/*---------------------------------------------------------------------------IN---------------------------------------------------------------------------------------------------*/
/*INT*/
SELECT *FROM HumanResources.Employee WHERE BusinessEntityID IN (2,3);
/*VARCHAR*/
SELECT *FROM HumanResources.Employee WHERE JobTitle IN ('Accountant','Chief Executive Officer','Design Engineer');
/*DATE*/
SELECT *FROM HumanResources.Employee WHERE HireDate IN ('2009-01-14','2008-01-31');
/*NESTED QUERY*/
SELECT *FROM HumanResources.Employee WHERE BusinessEntityID IN (SELECT BusinessEntityID FROM HumanResources.Employee  WHERE JobTitle='Accountant');
SELECT *FROM HumanResources.Employee WHERE JobTitle NOT IN ('Accountant','Chief Executive Officer','Design Engineer');
/*NULLS are not included as we cannot aompare with NULL*/
USE StudentDB;
SELECT *FROM StudentTable WHERE Name IN ('roja','harsha',NULL);





/*------------------------------------------------------------------------LIKE/NOT LIKE---------------------------------------------------------------------------------------------------*/
/* % _ [] [^]
return type=bool
ASCII MATCHING     trailing spaces are NOT significant
UNICODE MATCHING   trailing spaces are significant
ESCAPE Character
*/
CREATE TABLE t1 (col1 CHAR(30));
INSERT INTO t1
VALUES ('Samantha');
SELECT * FROM t1
WHERE RTRIM(col1) LIKE '%tha';

CREATE TABLE t2 (col1 NCHAR(30));
INSERT INTO t2
VALUES ('Samantha');
SELECT * FROM t2
WHERE (col1) LIKE '%tha';
SELECT * FROM t2
WHERE RTRIM(col1) LIKE '%tha';

USE adventure;
SELECT *FROM HumanResources.Employee WHERE JobTitle LIKE 'Res%'
SELECT *FROM HumanResources.Employee WHERE JobTitle NOT LIKE 'Res%'
SELECT MaritalStatus FROM HumanResources.Employee WHERE MaritalStatus LIKE '[M]';
SELECT MaritalStatus FROM HumanResources.Employee WHERE MaritalStatus NOT LIKE '[M]';
SELECT MaritalStatus FROM HumanResources.Employee WHERE MaritalStatus LIKE '[^M]';
SELECT BusinessEntityID FROM HumanResources.Employee WHERE BusinessEntityID LIKE '1__';

CREATE TABLE t3 (discount CHAR(30));
INSERT INTO t3
VALUES ('7.9%');
SELECT *FROM t3;
SELECT *FROM t3 WHERE discount LIKE '%.8!%%' ESCAPE '!';





/*------------------------------------------------------------------------------IS NULL--------------------------------------------------------------------------------------------
Return type=bool
*/
SELECT *FROM HumanResources.Employee WHERE OrganizationNode IS NULL;
SELECT *FROM HumanResources.Employee WHERE OrganizationNode IS NOT NULL;



/*-------------------------------------------------------------------------------DISTINCT---------------------------------------------------------------------------------------- */
SELECT DISTINCT(JobTitle) FROM HumanResources.Employee;




/*-------------------------------------------------------------------------------ORDER-BY-----------------------------------------------------------------------------------------*/
SELECT JobTitle,HireDate FROM HumanResources.Employee ORDER BY HireDate;
SELECT JobTitle,HireDate FROM HumanResources.Employee ORDER BY HireDate DESC;


SELECT JobTitle,(HireDate) FROM HumanResources.Employee GROUP BY JobTitle ORDER BY HireDate;
SELECT JobTitle,MIN(HireDate) FROM HumanResources.Employee GROUP BY JobTitle;


CREATE TABLE NVarcharTable(
	ID int NOT NULL IDENTITY(1,1),
	VarColumn NVARCHAR(30)
)


ALTER TABLE NVarcharTable ALTER COLUMN VarColumn NVARCHAR(30)

INSERT INTO NVarcharTable
VALUES ('1111111111111111');

DELETE FROM NVarcharTable WHERE VarColumn = '111111111111111111111111111111'

SELECT * FROM NVarcharTable where (VarColumn) like '%11111 '

TRUNCATE TABLE NVarcharTable

 