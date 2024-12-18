/*ORDER OF PROCCESSING
  from
  where
  group by
  having
  select
  distinct
  order by
  limit/top,offset
*/

/*after group by it is treated as single row that is why we cannot select or orderby other rows if we want to select/orderby we have to use aggregate fun on those columns*/
/*NationalIDNumber should be aggregated to return as the compiler gets confused abt what value has to be returned among the same available jobtitles*/
SELECT NationalIDNumber,JobTitle FROM HumanResources.Employee WHERE Gender='M' GROUP BY JobTitle HAVING COUNT(*) =1;
/*we can directly use the columns specified in group by else we should use aggregate columns in order by same as select*/
SELECT JobTitle FROM HumanResources.Employee WHERE Gender='M' GROUP BY JobTitle HAVING COUNT(*) =1 ORDER BY JobTitle;
SELECT JobTitle FROM HumanResources.Employee WHERE Gender='M' GROUP BY JobTitle HAVING COUNT(*) =1 ORDER BY SUM(VacationHours);


/*Distinct= Group by + no aggregate function*/
SELECT Jobtitle FROM HumanResources.Employee GROUP BY JobTitle;
/*distinct lo ye column pedthe aa column midhane order by apply cheyyali bcus other column ayyithey appudu okate value lo multiple values unttay appudu yedhi 
theeskovali ann acinfusion unttadhi*/
SELECT DISTINCT(JobTitle) FROM HumanResources.Employee ORDER BY JobTitle;
/*for below weget error bcus jobtitle column lo multiple rows for same jobtitle unttay andhulo businessid sort antte ye row theeskovalo ardham kadhu*/
SELECT DISTINCT(JobTitle) FROM HumanResources.Employee ORDER BY BusinessEntityID;


/*GROUP BY tarvtha where vadalemu as in order of execution where is already performed bfr grouping so we have to surely use having */
/*alias names cannot be used for group by as select is executed after having as a result group by wont know abt the alias name*/
--SELECT SUM(PPRICE) AS P FROM HumanResources.Employee
--WHERE BusinessEntityID>123
--GROUP BY P
--WHERE....
--ORDER BY .P.


USE adventure;
SELECT *FROM HumanResources.Employee;

/*alias names for table*/
SELECT * FROM HumanResources.Employee AS hrEmp;

/*alias names for columns*/
SELECT NationalIDNumber,LoginID AS ID,JobTitle AS Title FROM HumanResources.Employee;

/*Calculations on columns*/
SELECT SickLeaveHours + VacationHours AS Summed FROM HumanResources.Employee ;





/*--------------------------------------------------------------------WHERECLAUSE------------------------------------------------------------*/
SELECT *FROM HumanResources.Employee WHERE JobTitle = 'Research and Development Manager';
SELECT *FROM HumanResources.Employee WHERE BusinessEntityID=4;






/*------------------------------------------------------------------BETWEEN---AND (boundary values are inclusive)-----------------------------------------------*/
/*return type=Bool*/
/*If any input to the BETWEEN or NOT BETWEEN predicate is NULL, the result is UNKNOWN(neither true nor false) as we cannot compare with NULLs*/
SELECT *FROM HumanResources.Employee WHERE JobTitle BETWEEN NULL AND NULL;
SELECT *FROM HumanResources.Employee WHERE JobTitle BETWEEN 'Accountant' AND NULL;
SELECT *FROM HumanResources.Employee WHERE JobTitle BETWEEN NULL AND 'Accountant'  ;
/*between--and can be used to handle null values I.E; they are not included in the results*/
/*for varchar datatype*/
SELECT *FROM HumanResources.Employee WHERE JobTitle BETWEEN 'Accountant' AND 'Application Specialist';
/*for int datatype*/
/*1,4 are inclusive*/
SELECT *FROM HumanResources.Employee WHERE BusinessEntityID NOT BETWEEN 1 AND 4;
/*if no proper order maintained then we get empty result*/
SELECT *FROM HumanResources.Employee WHERE BusinessEntityID BETWEEN 8 AND 4;   
/*for date datatype*/
SELECT HireDate FROM HumanResources.Employee WHERE HireDate BETWEEN '2008-01-31' AND '2009-01-14';
/*to exclude the boundary values we can use >,< symbols*/
SELECT *FROM HumanResources.Employee WHERE BusinessEntityID>1 AND BusinessEntityID<4;

DECLARE @min int=2;
DECLARE @max int=10;
SELECT *FROM HumanResources.Employee WHERE BusinessEntityID BETWEEN @min AND @max;






/*---------------------------------------------------------------------------IN-------------------------------------------------------------------------------*/
/*returntype=bool*/
/*if there are thousands of values in IN then we may get performance issues ERROR:8623/8632
so to avoid the error store those values in a temp table and use subquery with IN*/
/*OR and IN are same*/
/*INT*/
SELECT *FROM HumanResources.Employee WHERE BusinessEntityID IN (2,3);
/*VARCHAR*/
SELECT *FROM HumanResources.Employee WHERE JobTitle IN ('Accountant','Chief Executive Officer','Design Engineer');
/*DATE*/
SELECT *FROM HumanResources.Employee WHERE HireDate IN ('2009-01-14','2008-01-31');
/*NESTED QUERY*/
SELECT *FROM HumanResources.Employee WHERE BusinessEntityID IN (SELECT BusinessEntityID FROM HumanResources.Employee  WHERE JobTitle='Accountant');
SELECT *FROM HumanResources.Employee WHERE JobTitle NOT IN ('Accountant','Chief Executive Officer','Design Engineer');
/*NULLS are not included as we cannot compare with NULL*/
USE StudentDB;
SELECT *FROM StudentTable WHERE Name IN ('roja','harsha',NULL);





/*------------------------------------------------------------------------LIKE/NOT LIKE--------------------------------------------------------------------------*/
/* % _ [] [^] -
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
SELECT MaritalStatus FROM HumanResources.Employee WHERE MaritalStatus LIKE '[MS]';
SELECT MaritalStatus FROM HumanResources.Employee WHERE MaritalStatus NOT LIKE '[M]';
SELECT MaritalStatus FROM HumanResources.Employee WHERE MaritalStatus LIKE '[^M]';
SELECT BusinessEntityID FROM HumanResources.Employee WHERE BusinessEntityID LIKE '1__';

CREATE TABLE t3 (discount CHAR(30));
INSERT INTO t3
VALUES ('6.8');
USE adventure;
SELECT *FROM t3;
SELECT *FROM t3 WHERE discount LIKE '%.8!%%' ESCAPE '!';
SELECT *FROM t3 WHERE discount LIKE '%.8\%%' ESCAPE '\';
/*if no character after ! then false is returned and hence no result*/
SELECT *FROM t3 WHERE discount LIKE '%.8!' ESCAPE '!';
/* If the character after an escape character isn't a wildcard character, the escape character is discarded
and the following character is treated as a regular character in the pattern. */
SELECT *FROM t3 WHERE discount LIKE '%.8!1' ESCAPE '!';





/*------------------------------------------------------------------------------IS NULL----------------------------------------------------------------------------*/
Return type=bool
*/
SELECT *FROM HumanResources.Employee WHERE OrganizationNode IS NULL;
SELECT *FROM HumanResources.Employee WHERE OrganizationNode IS NOT NULL;




/*-------------------------------------------------------------------------------DISTINCT---------------------------------------------------------------------- */
SELECT DISTINCT(JobTitle) FROM HumanResources.Employee ORDER BY LoginID;




/*-------------------------------------------------------------------------------ORDER-BY----------------------------------------------------------------------------*/
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



/*------------------------------------------------------------------SCALAR FUNCTIONS--------------------------------------------------------------------------*/
USE adventure;
SELECT DISTINCT(UPPER(JobTitle)) FROM HumanResources.Employee ;
SELECT DISTINCT(LOWER(JobTitle)) FROM HumanResources.Employee ;
/*NULL are not effected*/
SELECT UPPER(OrganizationLevel) from HumanResources.Employee;
SELECT *FROM HumanResources.Employee;
/*int datatype*/
SELECT DISTINCT(LOWER([BusinessEntityID])) FROM HumanResources.Employee ;
/*date datatype*/
SELECT DISTINCT(LOWER([BirthDate])) FROM HumanResources.Employee ;
/*smallint datatype*/
SELECT DISTINCT(UPPER([VacationHours])) FROM HumanResources.Employee ;

/*we get error for those datatypes that are not implicitly convertable to varhcar/nvarchar and then resolve it using CAST */

CREATE TABLE SampleTable (
    ID INT PRIMARY KEY,
    TextColumn TEXT
);
INSERT INTO SampleTable (ID, TextColumn)
VALUES (1, 'This is a sample text value.');

SELECT *FROM SampleTable;
SELECT UPPER(TextColumn) from SampleTable;
USE SampleTable;
SELECT UPPER(CAST(TextColumn AS varchar(89))) AS up FROM SampleTable;


/*-----------------------------------------------------------------------------LEN-----------------------------------------------------------------------------*/
/*doesn't count trailing spaces*/
/*123 is int by default if it exceeds int range then treated as decimal
point values are by default decimals*/
SELECT LEN('HEY       ') AS length;
SELECT LEN(14);
SELECT SQL_VARIANT_PROPERTY(56728345678006,'basetype');
SELECT LEN(56728345678006) AS lenh;
SELECT LEN(837.8569) AS leng;
SELECT LEN(NationalIDNumber) FROM HumanResources.Employee;
SELECT SQL_VARIANT_PROPERTY('09-08-2024','BASETYPE')
SELECT LEN('09-08-2024   ') AS dataintlen;
SELECT LEN(NULL) AS dataintlen;
/*to know the datatype of any value*/
SELECT SQL_VARIANT_PROPERTY(123, 'BaseType') AS DataType;


/*--------------------------------------------------------------------------DATALENGTH---------------------------------------------------------------------------*/
/*counts trailing spaces*/
SELECT DATALENGTH('Hello      ') as datalength;
SELECT SQL_VARIANT_PROPERTY(5673423456765434565,'basetype');
SELECT DATALENGTH(5673423456765434565) AS dt;
SELECT SQL_VARIANT_PROPERTY(837.523,'basetype');
SELECT DATALENGTH(837.523) AS leng;
SELECT DATALENGTH(NationalIDNumber) FROM HumanResources.Employee;
DECLARE @x int= 12-04-2023;
SELECT CAST(13-04-2023 AS int);
SELECT @x;
SELECT SQL_VARIANT_PROPERTY(12.45,'BASETYPE')
SELECT DATALENGTH('  09-08-2024  ') AS dataintlen;
SELECT DATALENGTH(NULL)AS dataintlen;

/*---------------------------------------------------------------DIFFERENCE BTW LEN AND DATALENGTH-------------------------------------------------------------------*/
DECLARE @v1 VARCHAR(40),  
    @v2 NVARCHAR(40);  
SELECT   
@v1 = 'Test of 22 characters ',   
@v2 = 'Test of 22 characters ';  
SELECT LEN(@v1) AS [VARCHAR LEN] , DATALENGTH(@v1) AS [VARCHAR DATALENGTH];  
SELECT LEN(@v2) AS [NVARCHAR LEN], DATALENGTH(@v2) AS [NVARCHAR DATALENGTH];




/*----------------------------------------------------------GETDATE()-----------------------------------------------------------------------------------------------*/
SELECT SYSDATETIME(),SYSDATETIMEOFFSET(),SYSUTCDATETIME(),
	   CURRENT_TIMESTAMP,
	   GETDATE(),GETUTCDATE();

SELECT CONVERT(date,SYSDATETIME()),
       CONVERT(date,CURRENT_TIMESTAMP),
	   CONVERT(date,GETDATE()),CONVERT(date,GETUTCDATE());

SELECT CONVERT(time,SYSDATETIME()),
       CONVERT(time,CURRENT_TIMESTAMP),
	   CONVERT(time,GETDATE()),CONVERT(time,GETUTCDATE());





/*-----------------------------------------------------------MATH FUNCTIONS----------------------------------------------------------------------------------*/
/*
float,real                  float
decimal                     decimal
int,smallint,tinyint        int
bit                         float
bigint                      bigint
money,smallmoney            money
*/

/*ABS  returns positive value*/
SELECT ABS(23);
SELECT ABS(0);
SELECT ABS(-24563);
SELECT ABS(-23.839);
DECLARE @x BIT=NULL;
SELECT ABS(@x);
/*overflow error as int range is (-2147483648 to 2147483647) */
SELECT ABS(-2147483648);


/*FLOOR   largest integer less than or equal to given num 
ceil      smallest integer greater than or equal to given num*/
SELECT FLOOR(23.5);
SELECT FLOOR(0);
SELECT FLOOR(-28.2);
SELECT FLOOR($-28.2989);
SELECT FLOOR(NULL);
DECLARE @p float = -21474836489.9;
DECLARE @q int;
SELECT @q= FLOOR(@p);


/*isnumeric   returns valid numeric expression or not*/
/*valid numerics are bit,smallint,tinyint,int,bigint,float,real,money,smallmoney,
decimal,numeric*/
SELECT ISNUMERIC('SREE');
SELECT ISNUMERIC(NULL);
SELECT ISNUMERIC(8);
SELECT ISNUMERIC('+');
SELECT ISNUMERIC('-');
SELECT ISNUMERIC('$');


/*round*/
SELECT ROUND(123.345,2);
SELECT ROUND(123.345,-2); 
/*if the third parameter is 0 then round off else truncate */
SELECT ROUND(123456.345,-2,9);
SELECT ROUND(123456.345,-2,0);


 
 
 
 
 
 
 
 /*----------------------------------------------------------------------char functions------------------------------------------------------------------------------*/
 /*ASCII            7bit
 EXTENDED_ASCII     8bit*/

 SELECT ASCII('a');
 /*leftmost value ASCII is returned*/
 SELECT ASCII('cdeubk');
 SELECT ASCII(1);
 /*ж we get ascii as 63 bcus only the first 7bits are considered out of 8bits
 of extended ascii  to get the exact value use unicode fun*/
 SELECT ASCII('∑');
 SELECT char(63);
 SELECT UNICODE('∑');
 SELECT NCHAR(63);
   
 SELECT ASCII('€');
 SELECT char(63);
 SELECT UNICODE('€');
 SELECT NCHAR(8364);
 
 
 /*LTRIM,RTRIM*/
 SELECT LTRIM('   hey you');
 SELECT LTRIM('hey you','hey');
 SELECT LTRIM('345.89',34);
 SELECT LTRIM(00001234,0);
 SELECT LTRIM(' 00001234','0');
 SELECT LTRIM('311223345','012345');
 SELECT LTRIM(00001234,01);


 
 /*CHARINDEX  1-based indexing*/
 DECLARE @texts varchar(89)='HEY YOU!!'
 SELECT CHARINDEX('H',@texts);
 /*0,-ve treated as search from the beginning*/
 SELECT CHARINDEX('H',@texts,0);
 SELECT CHARINDEX('H',@texts,-8);
 /*search from specific pos*/
 SELECT CHARINDEX('!',@texts,3);
 /*if doesn't exists then 0*/
 SELECT CHARINDEX('z',@texts,0);
 /*performing case sensitive CS=casesensitive AS=accentsensistive*/
 SELECT CHARINDEX('HELLO','HI ,HeLLO' COLLATE Latin1_General_CS_AS); 
 SELECT CHARINDEX('HELLO','HI ,HELLO' COLLATE Latin1_General_CS_AS); 
 SELECT CHARINDEX('HELLO','HI ,HelLO' COLLATE Latin1_General_CI_AS); 
 /*by default case insenstive*/
 SELECT CHARINDEX('HELLO','HI ,HeLLO'); 
 
 


 /*CONCAT MIN=2  MAX=254 paramaters*/
 /*NULLs are converted into empty strings */
 SELECT CONCAT('Hi','FRNDS','Bye','frnds');
 SELECT CONCAT('Hi',NULL,'FRNDS',NULL,'Bye');
 SELECT CONCAT(NULL,NULL);
 SELECT CONCAT_WS(',','Siva','sree','Annamdevula','alias SS');
 SELECT CONCAT_WS('Siva',null,NULL,'alias SS','hi');
 SELECT CONCAT_WS(8,null,NULL,'alias SS','hi');
 

 /*FORMAT*/
 SELECT FORMAT(GETDATE(),'D');
 SELECT FORMAT(GETDATE(),'d');
 SELECT FORMAT(GETDATE(),'yyyy-MM-dd');
 SELECT FORMAT(GETDATE(),'MM-dd-yyyy');
 SELECT FORMAT(GETDATE(),'yyyy-MM-dd');
 /*with culture*/
 SELECT FORMAT(GETDATE(),'D','fr-FR');
 SELECT FORMAT(GETDATE(),'D','de-DE');
 /*number formatting*/
 SELECT FORMAT(12345678,'N');  
 /*currency formatting*/
 SELECT FORMAT(12345678,'C');
 SELECT FORMAT(12345678,'C','fr-FR');
 /*percentage formatting*/
 SELECT FORMAT(12345678,'P');
 /*scientific notation*/
 SELECT FORMAT(12345678,'E');
 
 
 
 /*LEFT*/
 SELECT LEFT('abcdef',3);
 SELECT LEFT('abcdef',-3);
 SELECT RIGHT('abcdef',3);


 
 /*PATINDEX*/
 SELECT PATINDEX('%tech%','Pal emplTECHoyee');
 USE adventure;
 SELECT PATINDEX('_cc%',JobTitle) FROM HumanResources.Employee ;
 /*Latin1_General_BIN --casesensitive+accentsensitive*/
 SELECT PATINDEX('%as%','aliAs As' COLLATE Latin1_General_BIN); 
 SELECT PATINDEX('%as%','alias As' COLLATE Latin1_General_CS_AS); 
 SELECT PATINDEX('%as%','aSliAs As' COLLATE Latin1_General_CI_AS); 
 
 
 /*REPLACE    replaces all occurences with the target */
 SELECT REPLACE('Tech Mahindra Mahi','Mahi','kohli');
 SELECT REPLACE('Slip Test' COLLATE Latin1_General_BIN,'test','RestY');
 --DECLARE @str varchar(78)='Tech Mahindra opposite Paltech',@len1 int,@len2 int;
 --SET @len1=LEN(@str);
 --SET @str=REPLACE(@str,' ' ,'');
 --SET @len2=LEN(@str);
 --SELECT @len1-@len2;
 SELECT REPLACE('HEY','e','o');


 /*REPLICATE*/
 SELECT REPLICATE('sree',3);
 SELECT REPLICATE('sree',-3);
 SELECT REPLICATE('HEY',2);

/*REVERSE*/
SELECT REVERSE('Siva');
SELECT REVERSE('Siva sree');
 
 
 /*stuff('string',startposition,howmanycharstodelete,replacewith)*/
 SELECT STUFF('abcdefghijkl',3,5,'123');
 SELECT STUFF('abcdefghijkl',3,18,'123');
 SELECT STUFF('abcdefghijkl',3,-9,'123');
 SELECT STUFF('abcdefghijkl',-3,9,'123');
 SELECT STUFF('abcdefghijkl',73,9,'123');
 SELECT STUFF('abcdefghijkl',0,-9,'123');
 

 /*substring(string,start,length)*/
 SELECT SUBSTRING('HEY SIRI,HOW ARE YOU',3,6);
 SELECT SUBSTRING('ALL THE BEST',2,3);
 
 
 /*by default ansi_nulls is on i.e; why we cannot comapre and we dont get any result*/
 SET ANSI_NULLS ON;
 USE adventure;
 SELECT *FROM HumanResources.Employee WHERE OrganizationLevel=NULL;
 SET ANSI_NULLS OFF;

 DECLARE @ps datetime=NULL;
 DECLARE @qs int=NULL;
 DECLARE @rs varchar(78)=NULL;
 /*highest priority datatype is choosen for coalesce and 4th parameter is converted to that type*/
 SELECT COALESCE(@ps,@qs,@rs,0);
 /*here we get error as we cannot convert string to datetime*/
 SELECT COALESCE(@ps,@qs,@rs,'hey');


 SELECT ISNULL(NULL,6);
 SELECT ISNULL(NULL,'TEJES');
 
 

 

