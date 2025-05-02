Use Prac;

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

SELECT *FROM Customers;

/*--------------------------------------------------------------------CAST/CONVERT----------------------------------------------------------------------------------*/
/*DIFF btw cast and convert CAST is ANSI standard,CONVERT sql sever specific i.e; we can use cast in other dbs as well
  CONVERT also has an additional style parameter*/
SELECT CAST(GETDATE() AS nvarchar);
SELECT CONVERT(nvarchar,GETDATE());
SELECT CONVERT(nvarchar,GETDATE(),101);
SELECT CONVERT(nvarchar,GETDATE(),102);

/*if conversion not possible then try_cast/try_convert returns null whereas cast/convert returns error*/
SELECT TRY_CAST('abc' AS int);
SELECT CAST('abc' AS int);
SELECT TRY_CAST(23 AS decimal(1));
SELECT CAST(23 AS decimal(1));

SELECT TRY_CONVERT(int,'abc');
SELECT CONVERT(int,'abc');

/*Parse and try-parse---used to convert string to NUMERIS/DATATIME datatype*/
--possible conversion
SELECT PARSE('12' AS int );
SELECT TRY_PARSE('12' AS int);
--not possible cinversion
SELECT PARSE('12.6' AS int );
SELECT TRY_PARSE('12.8' AS int);
SELECT PARSE('xys' AS int );
SELECT PARSE('xya' AS int );
SELECT TRY_PARSE('1234' AS money using 'de-DE');
SELECT TRY_PARSE('123' AS money using 'ja-JP');
SELECT TRY_PARSE('1234' AS money using 'en-US');







/*---------------------------------------------------------------------DATE FORMATS----------------------------------------------------------------------------------*/
/*GETDATE() is SQL specific , Current_timestamp is in all dbms*/
SELECT GETDATE();
SELECT CURRENT_TIMESTAMP;

/*DATENAME return type=string
difference between dataepart and datename is month name for datename and number for datepart*/
SELECT DATENAME(month,GETDATE());
SELECT DATENAME(day,GETDATE());
SELECT DATENAME(year,GETDATE());

/*DATEPART return type=int*/
SELECT DATEPART(month,GETDATE());
SELECT DATEPART(day,GETDATE());
SELECT DATEPART(year,GETDATE());

/*These even internally uses datepart*/
SELECT DAY(GETDATE());
SELECT MONTH(GETDATE());
SELECT YEAR(GETDATE());


SELECT DATEDIFF(DAY,'2-2-2024','4-2-2024');
SELECT DATEDIFF(MONTH,'2-2-2024','4-2-2024');
SELECT DATEDIFF(YEAR,'2-2-2024','4-2-2024');

SELECT DATEADD(MONTH,8,GETDATE());
SELECT DATEADD(DAY,8,GETDATE());
SELECT DATEADD(YEAR,8,GETDATE());

SELECT EOMONTH('3-2-2024')


SELECT ISDATE('2-2-202225');
SELECT ISDATE('2-2-2025');
SELECT ISDATE('JASHDB');



/*---------------------------------------------------------------------over clause-----------------------------------------------------------------------------------*/
/*
using group by if we want to select columns then we can select those are in groupby clause or by applying aggregate
functions on those columns else we cannot...so to select the other columns we use over*/
USE Prac;
SELECT Gender,COUNT(*) AS TotalCount,AVG(Salary) AS AvgSalary, MIN(Salary) AS MinSal ,MAX(Salary) AS MaxSal
FROM Customers
GROUP BY Gender;

/*divides table into two parts as female and male as we have partitioned by gender*/
SELECT Name,Salary,Gender,
       COUNT(Gender) OVER (PARTITION BY Gender) AS TotalGen,
	   AVG(Salary) OVER (PARTITION BY Gender)   AS AvgSal,
	   MIN(Salary) OVER (PARTITION BY Gender) AS MinSal,
	   MAX(Salary) OVER (PARTITION BY Gender) AS MaxSal
FROM Customers;



/*--------------------------------------------------------------DIFF CASES----------------------------------------------------------------------------------------*/
/*if ntng is specified inside over then all rows treated as one window*/
SELECT Name,Salary,Gender,
       SUM(Salary) OVER() AS Total
FROM Customers;

/*partiontioning by gender
for each partiotion function(avg,sum...) are reset to 0
default order by is ASC we can see salary sum column is in ascending order*/
SELECT Name,Salary,Gender,
       SUM(Salary) OVER(PARTITION BY Gender ORDER BY Name) AS Total
FROM Customers;

/*After partitioning if we want to order each window or partition then we should use order by*/
SELECT Name,Salary,Gender,
       COUNT(*) OVER(PARTITION BY Gender ORDER BY Name) AS Total
FROM Customers;

/*range(logical)/rows(physical) requires order by;default is from start of partition to current row
--if there is no order by then functions are calculated for all the rows in a partition and not unbounded preceding to current_row
unbounded precedence
unbounded following
current row
n precedence               cannot be used for range
n following                cannot be used for range
*/

SELECT Name,Salary,SUM(Salary) OVER(ORDER BY Name) AS Total FROM Customers ;  --BY default unbounded preceding to current_row
SELECT Name,Salary,SUM(Salary) OVER(partition by Gender ORDER BY Name) AS Total FROM Customers ; 
SELECT Name,Salary,Gender,SUM(Salary) OVER(ORDER BY Name ROWS BETWEEN UNBOUNDED PRECEDING AND UNBOUNDED FOLLOWING) AS Total FROM Customers ;
SELECT Name,Salary,SUM(Salary) OVER(partition by Gender ORDER BY Name RANGE BETWEEN UNBOUNDED PRECEDING AND UNBOUNDED FOLLOWING) AS Total FROM Customers ;
SELECT Name,Salary,Gender,SUM(Salary) OVER(ORDER BY Name ROWS BETWEEN 3 PRECEDING AND 3 FOLLOWING ) AS Total FROM Customers ;

SELECT *FROM Manager;


/*WINDOW FUNCTIONS are 3 types
1.Aggregate functions        SUM AVG COUNT MIN MAX
2.Ranking functions          ROW_NUMBER RANK DENSE_RANK
3.Analytical functions       LEAD LAG FIRST_VALUE LAST_VALUE CUME_DIST PERCENT_RANK 
*/


/*----------------------------------------------------------------aggregate functions--------------------------------------------------------------------------------*/
/*nulls are ignored*/
/*avg(salary)=sum(salary)/count(saalry)    avg(distinct salary)=sum(distinct salary)/count(distinct salary)*/
SELECT Gender,SUM(Salary),AVG(Salary),COUNT(*)
FROM Customers
GROUP BY Gender;

/*only distinct values are considered */
INSERT INTO Customers VALUES(1,'xyz',4500,'M');
INSERT INTO Customers VALUES(1,'yz',4500,'M');
SELECT Gender,SUM(DISTINCT Salary), AVG( DISTINCT SALARY) AS Avg,COUNT(*) AS cou
FROM Customers
GROUP BY Gender;

SELECT AVG(DISTINCT Salary)as avd,AVG(salary) as avg from Customers GROUP BY Gender;
/*With over clause*/
SELECT Name,Salary,Gender,
       SUM(Salary) OVER(PARTITION BY Gender) AS Total
FROM Customers;

/*COUNT*/
/*difference btw count and count_big is return type count---int, count_big---bigint*/
SELECT *FROM Customers;
SELECT SALARY FROM Customers ORDER BY Salary;
/*nulls and duplicates are counted,simply gives the total no.of rows in a table*/
SELECT COUNT(*) FROM Customers;
SELECT COUNT(3) FROM Customers;
SELECT COUNT('HEY') FROM Customers;
SELECT COUNT('') FROM Customers;
SELECT COUNT(NULL) FROM Customers;


/*non nulls are only consisdered*/
SELECT COUNT(Salary) FROM Customers;
SELECT COUNT(DISTINCT Salary) FROM Customers;


/*---------------------------------------------------------------------------------RANKING FUNCTIONS-------------------------------------------------------------*/
/*gives unique number to each row in the partition*/
SELECT ROW_NUMBER() OVER (PARTITION BY Gender ORDER BY Name) AS Rank1,Name
FROM Customers;

/*if duplicates in orderby then skipped */
SELECT RANK() OVER (PARTITION BY Gender ORDER BY Name) AS Rank2,Name
FROM Customers;

/*though duplicates are present values are not skipped*/
SELECT DENSE_RANK() OVER (PARTITION BY Gender ORDER BY Name) AS Rank3,Name
FROM Customers;

/*each partition is again divided into equal parts called tiles*/
SELECT NTILE(2) OVER (PARTITION BY Gender ORDER BY Name) AS Rank4,Name
FROM Customers;


/*---------------------------------------------------------------analytical functions-------------------------------------------------------------------------------*/
/*cume_dist*/
SELECT *FROM Customers;
/*lead*/
/*lag*/
/*last_value----last value of (unbounded preceding to current row) for every row if rows/range not mentioned
             ---while orderby if salaries are equal then lastvalue of that same salary rows is the last value for every row in that common salary persons */
SELECT Name,Gender,Salary,
LAST_VALUE(Name) OVER(ORDER BY Salary) AS Last
FROM Customers;

SELECT Name,Gender,Salary,
LAST_VALUE(Name) OVER(Partition BY Gender ORDER BY Salary) AS Last
FROM Customers;

/*FIRST_VALUE==same as last_value but gives first_value of partition*/
SELECT Name,Gender,Salary,
FIRST_VALUE(Name) OVER(ORDER BY Salary) AS Last
FROM Customers;

/*returns previous 2nd value for every row, if no previous 2nd row present then default value(3rd parameter of lag func) if specified else NULL*/
SELECT Name,Gender,Salary,
LAG(Name,2,'default') OVER(ORDER BY Salary) AS Last
FROM Customers;

SELECT Name,Gender,Salary,
LEAD(Name,2,'default') OVER(ORDER BY Salary) AS Last
FROM Customers;

/*divide the partion into no.of equal partitions btw 0 1*/
SELECT Name,Gender,Salary,
PERCENT_RANK() OVER(PARTITION BY Gender ORDER BY Salary) AS Last
FROM Customers;


/*--------------------------------------------------------------------TOP-------------------------------------------------------------------------------------------*/
SELECT TOP 5 * FROM Customers order by name;                   --returns top 5 rows
SELECT TOP 50 PERCENT *FROM Customers;                         --returns top 50% of table
SELECT TOP 6 WITH TIES *FROM Customers                         --returns top 6 and also duplicates of 6th row
ORDER BY Salary;

/*DISTINCT Lopala sort jarugudhi i.e; why we get ascending ordered o/p*/
SELECT DISTINCT  * FROM Customers ;
SELECT DISTINCT TOP(2)   *FROM Customers;                   --gives top 2 distinct rows
SELECT *FROM Customers;






/*------------------------------------------------------------------CTE--------------------------------------------------------------------------------------------*/

with average_salary(avgsal) as
(
   SELECT AVG(Salary) FROM Customers
)
SELECT *FROM Customers,average_salary a WHERE Salary>a.avgsal;

select *from sales;


--SELECT y.Name,y.Totalsales
--FROM (SELECT Name,Sum(price) as Totalsales
--     FROM Sales
--     GROUP BY Name) y
--WHERE Totalsales >
--                     (SELECT AVG(Total_sales) AS Avg_sales
--					   FROM 
--					   (SELECT Name,Sum(price) as Total_sales
--					   FROM Sales
--					   GROUP BY Name) x
--					   )  ;

/*converted above subquery to short using CTE*/
WITH Total_Sales(Name,Totalsales) AS
         (
		   SELECT Name,Sum(price) as Totalsales
           FROM Sales
           GROUP BY Name
		 ),
	Avg_Sales(Avg_sales) AS
	(
	   SELECT AVG(Totalsales) AS Avg_sales
       FROM Total_Sales
	 )
SELECT x.Name,x.Totalsales
FROM Total_Sales x
WHERE x.Totalsales>(SELECT Avg_sales FROM Avg_Sales);
	 
/*can we update,insert,delete using cte?
if we have single table in cte then we can update,select,insert,delete
*/

with average_salary(CustomerID,Name,Salary,Gender) as
(
   SELECT * FROM Customers
)
--SELECT Name FROM average_salary;
--INSERT INTO average_salary Values(1,'CTE',2333,'M');
--UPDATE average_salary SET Gender='IV' 
--WHERE Name='CTE';
--DELETE FROM average_salary WHERE Name='CTE'



;with join_result(dDepartmentID,dDepartName) as
(
   SELECT d.DepartmentID,d.DepartName FROM Employees e
   LEFT JOIN Department d
   ON e.DepartmentID = d.DepartmentID
 )
--SELECT * FROM join_result;
/*insertion not possible if we are trying to insert into both the tables simultaneously
but if we return only one table columns then we can insert*/
--INSERT INTO join_result VALUES('E999','CTE',12345,'D1','M1','D1','HR');
--INSERT INTO join_result VALUES('E99','CTEFresh',12345,'D1','M1')
--INSERT INTO join_result VALUES('D12','HRMS')

/*as update can be done on a single table we can perform updates*/
--UPDATE join_result SET eEmp_Name='emp_name' 
--WHERE eDepartmentID='D3'
--UPDATE join_result SET dDepartName='emp_name' 
--WHERE eDepartmentID='D3'

/*not possible in any way*/
--DELETE FROM join_result WHERE eEmployeeID='ERob=='
--DELETE FROM join_result WHERE dDepartmentID='D1'
SELECT *FROM Employees;
SELECT *FROM Department



/*execution order in RECURSIVE CTE*/
DECLARE @rownum int =1;
with RecursiveCTE(rownum) AS
(
    SELECT cast('sree' as varchar(25)) as rownum
	UNION ALL
	SELECT  cast(rownum + '1' as varchar(25)) as rownum
	FROM RecursiveCTE
	WHERE len(rownum)<10

	UNION ALL

	SELECT cast(rownum + '2' as varchar(25)) as rownum
	FROM RecursiveCTE
	WHERE len(rownum)<10
)

SELECT *FROM RecursiveCTE;


/*HIERARCHIAL TRACKING USING RECURSIVE CTE*/
CREATE TABLE RecHierarchial
(
  EmployeeID int NOT NULL PRIMARY KEY,
  FirstName varchar(50) NOT NULL,
  LastName varchar(50) NOT NULL,
  ManagerID int NULL
)
 
INSERT INTO RecHierarchial VALUES (1, 'Ken', 'Thompson', NULL)
INSERT INTO RecHierarchial VALUES (2, 'Terri', 'Ryan', 1)
INSERT INTO RecHierarchial VALUES (3, 'Robert', 'Durello', 1)
INSERT INTO RecHierarchial VALUES (4, 'Rob', 'Bailey', 2)
INSERT INTO RecHierarchial VALUES (5, 'Kent', 'Erickson', 2)
INSERT INTO RecHierarchial VALUES (6, 'Bill', 'Goldberg', 3)
INSERT INTO RecHierarchial VALUES (7, 'Ryan', 'Miller', 3)
INSERT INTO RecHierarchial VALUES (8, 'Dane', 'Mark', 5)
INSERT INTO RecHierarchial VALUES (9, 'Charles', 'Matthew', 6)
INSERT INTO RecHierarchial VALUES (10, 'Michael', 'Jhonson', 6)
 
select * from RecHierarchial

with RecHierarchialCTE(FirstName,EmployeeID,ManagerID) AS
(
   SELECT FirstName,EmployeeID,ManagerID FROM RecHierarchial WHERE ManagerID IS NULL
   UNION ALL
   SELECT r.FirstName,r.EmployeeID,r.ManagerID 
   FROM RecHierarchial r
   JOIN RecHierarchialCTE cte
   ON cte.EmployeeID=r.ManagerID
)
SELECT *FROM RecHierarchialCTE;


/*--------------------------------------------------------------------UNION/UNION-ALL/INTERSECT/EXCEPT-----------------------------------------------------------*/
CREATE TABLE tblIndiaCustomers(ID int,Name varchar(30),Email varchar(78));
INSERT INTO tblIndiaCustomers Values(1,'Raj','Raj@gmail.com');
INSERT INTO tblIndiaCustomers Values(1,'Sam','Sam@gmail.com');
INSERT INTO tblIndiaCustomers Values(1,'Ben','Ben@gamil.com');
INSERT INTO tblIndiaCustomers Values(1,'Prudhvi','Prudhvi@gamil.com');
INSERT INTO tblIndiaCustomers Values(1,'Abc','Prudhvi@gamil.com');
SELECT *FROM tblIndiaCustomers;

CREATE TABLE tblUSACustomers(ID int,Name varchar(30),Email varchar(78));
INSERT INTO tblUSACustomers Values(1,'Raj','Raj@gmail.com');
INSERT INTO tblUSACustomers Values(1,'Sam','Sam@gmail.com');
INSERT INTO tblUSACustomers Values(1,'Nikhil','Nikhil@gmail.com');
INSERT INTO tblUSACustomers Values(1,'Vishnu','Vishnu@gamil.com');
INSERT INTO tblUSACustomers Values(1,'Prudhvi','Prudhvi@gamil.com');

SELECT *FROM tblUSACustomers;

/*for any set operators(union,union all,except,intersect) the tables must be compatabile i.e; equal no.of columns and order of columns must be same*/
/*UNION ALL --both tables get added and duplicates are also contained*/
SELECT *FROM tblIndiaCustomers
SELECT *FROM tblUSACustomers;
SELECT *FROM tblIndiaCustomers
UNION ALL
SELECT *FROM tblUSACustomers;

/*UNION---both are combined and duplicates are removed
          slower in performance compared to UNION ALL as it uses distinct sort(u can see in execution plan) that takes more time*/

SELECT *FROM tblIndiaCustomers
UNION 
SELECT *FROM tblUSACustomers;


/*Common rows between the two tables are retrieved*/
SELECT *FROM tblIndiaCustomers
INTERSECT
SELECT *FROM tblUSACustomers;

/*A-B opertion in maths for EXCEPT*/
SELECT *FROM tblIndiaCustomers
EXCEPT
SELECT *FROM tblUSACustomers;
















/*--------------------------------------------------------------------CASE-------------------------------------------------------------------------------------------*/
SELECT *FROM Customers;


/*We can directly use column during comparison or specify column_name immediately after case statement*/
SELECT Name,Salary,CASE
       WHEN Gender='M' then 'Male'
       WHEN Gender='F' then 'Female'
	   ELSE 'other'
	   END AS Gender
FROM Customers;

SELECT Name,Salary,CASE Gender
       WHEN 'M' then 'Male'
       WHEN 'F' then 'Female'
	   ELSE 'other'
	   END AS GenderNew
FROM Customers;

/*---------------------------------------------------------------------OPENENDED-------------------------------------------------------------------------------------*/
/* we can cast the case as below*/
SElECT Salary,CAST(CASE 
       WHEN Salary<30000 THEN 'less'
	   WHEN Salary>30000 THEN 'higher'
	   ELSE 'invalid'
	   END  AS char(60))
FROM Employees


/*IN with NULL--OR operation i.e;
NOT IN----AND operation*/
SELECT Name,Salary FROM Customers WHERE Salary IN (5000,6500,NULL); 
SELECT Name,Salary FROM Customers WHERE Salary NOT IN (5000,6500,NULL);
SELECT *FROM Customers order by salary


/*null is treated as a value so exsists return true and not exists return false*/
SELECT Name FROM Customers WHERE not EXISTS (SELECT NULL);


/*top nth highest salary using correlated subquery*/
SELECT DISTINCT(Salary) FROM Customers c1
WHERE (SELECT COUNT(DISTINCT Salary) FROM Customers c2 WHERE c2.salary > c1.salary   )=3; 

/*order is preserved in UNION ALL but in all remaining(UNION,INTERSECT,EXCEPT) we get ascending order as internally sort happens*/


/*physical joins
physical ga tables midha jarige operations 
EX:1. Nested loops(if table1 size is far less than table2 then this is applied...this is same as cartesian product(for each row all rows
of other table are iterated)i.e; cross join and hence O(n^2) 
2.Merge join : if the joining column is sorted then merge join is applied
3.Hash join: if unsorted joining column then hash join
4.Adaptive join*/
/*logical joins (whatever join we write are divided into the following 3 logical joins inner join(A^ B),left outer join(A),left anti semi join(B-A)
,can be seen in executionplan*/
/*view joins  (inner join,left join,right join,full join,cross join,self join*/