/*------------------------------------------------------------SESSION6----------------------------------------------------------------------------*/

USE Prac;
CREATE TABLE Employees(EmployeeID varchar(20) PRIMARY KEY,Emp_Name varchar(50),Salary int,DepartmentID varchar(20)  FOREIGN KEY REFERENCES Department(DepartmentID),
                        ManagerID varchar(20)  FOREIGN KEY REFERENCES Manager(ManagerID));
						DROP TABLE Employees;
ALTER TABLE Employees
drop constraint FK__Employees__Depar__6166761E;
CREATE TABLE Department(DepartmentID varchar(20) PRIMARY KEY,DepartName varchar(30));
CREATE TABLE Manager(ManagerID varchar(20) PRIMARY KEY,ManagerName varchar(40),DepartmentID varchar(20) FOREIGN KEY REFERENCES Department(DepartmentID));
EXEC sp_help Employees;
INSERT INTO Employees VALUES('E1','Rahul',15000,'D1','M1');
INSERT INTO Employees VALUES('E2','Manoj',15000,'D1','M1');
INSERT INTO Employees VALUES('E3','James',55000,'D2','M2');
INSERT INTO Employees VALUES('E4','Michael',25000,'D2','M2');
INSERT INTO Employees VALUES('E5','Ali',20000,'D3','M3');
INSERT INTO Employees VALUES('E6','Robin',35000,'D4','M4');
INSERT INTO Employees VALUES('E7','Robin',35000,'D7','M4');
INSERT INTO Employees VALUES('E8','Rob',35000,'D11','M3');
DELETE FROM Employees where EmployeeID='E8';
SELECT *FROM Employees;
INSERT INTO Department VALUES('D1','IT');
INSERT INTO Department VALUES('D2','HR');
INSERT INTO Department VALUES('D3','Finance');
INSERT INTO Department VALUES('D4','Admin');
INSERT INTO Department VALUES('D5','Admin');
SELECT *FROM Department;
INSERT INTO Manager VALUES('M1','Prem','D3');
INSERT INTO Manager VALUES('M2','Shripadh','D4');
INSERT INTO Manager VALUES('M3','Nick','D1');
INSERT INTO Manager VALUES('M4','Cory','D1');
SELECT *FROM Manager;

/*to retrieve data from various tables we use joins*/
/*INNER JOIN/JOIN----returns those that are in both tables
here d1,d2,d3,d4 are in department but ot d7,d10 so we got only 6 rows*/
SELECT Emp_Name,DepartName
FROM Employees e
INNER JOIN
Department d
ON e.DepartmentID=d.DepartmentID;

SELECT Emp_Name,Salary,DepartName
FROM Employees e
JOIN
Department d
ON e.DepartmentID=d.DepartmentID;



/*LEFT JOIN/LEFT OUTER JOIN ----returns ALL the rows in the left table(inner join + Leftover left table records*/
SELECT Emp_Name,DepartName 
FROM Employees e
LEFT JOIN
Department d
ON e.DepartmentID=d.DepartmentID;


/*RIGHT JOIN/RIGHT OUTER JOIN*/
/*returns ALL rows from the right table(inner join + leftover rowsfrom right table)*/
SELECT Emp_Name,DepartName 
FROM Employees e
RIGHT JOIN
Department d
ON e.DepartmentID=d.DepartmentID;



/*FULL JOIN/FULL OUTER JOIN*/
/*gives the records from both the tables (inner join + leftover rows in left table + leftover rows in right table*/
SELECT Emp_Name,DepartName
FROM Employees e
FULL OUTER JOIN Department d
ON e.DepartmentID=d.DepartmentID;

SELECT Emp_Name,DepartName
FROM Employees e
FULL JOIN Department d
ON e.DepartmentID=d.DepartmentID;



/*CROSS JOIN (no.of records in left table * no.of rows in right table)
no need to use on clause
matches every row of left table to every row in right table
usecase--if no common columns in both tables then we can go for cross join*/
SELECT Emp_name,DepartName
FROM Employees e
CROSS JOIN Department d;



/*SELF JOIN---If we want to get data and map it to same table then we can go for self join*/
USE Prac;
CREATE TABLE Family(MemeberID varchar(20),Name varchar(40),ParentID varchar(20));
INSERT INTO Family VALUES('F1','David','F5');
INSERT INTO Family VALUES('F2','Carol','F5');
INSERT INTO Family VALUES('F3','Michael','F5');
INSERT INTO Family VALUES('F4','Johnson','');
INSERT INTO Family VALUES('F5','Maryam','F6');
INSERT INTO Family VALUES('F6','Stewart','');
INSERT INTO Family VALUES('F7','Rohan','F4');
INSERT INTO Family VALUES('F8','Asha','F4');
SELECT *FROM Family;
SELECT child.Name,parent.Name
FROM  Family parent
JOIN  Family child
ON parent.MemeberID=child.ParentID;


/*NATURAL JOIN
sql decides on which column join should happen---by looking at the names of columns it will decide
if same names are present in both the tables then it is same as INNER JOIN
if common column is not present then it is same as CROSS JOIN
if matches multiple columns then on all those columns inner join is performed*/


/*CROSS APPLY==INNER JOIN, only diff is here we use function that returns table*/
CREATE FUNCTION GetDepartmenForEmployee(@EmployeeDeptID varchar(20))
returns table
AS
RETURN
(
    SELECT * FROM Department WHERE DepartmentID=@EmployeeDeptID
)

SELECT *FROM GetDepartmenForEmployee('D2');

SELECT EMP_NAME,Salary,DepartName
FROM Employees e
CROSS APPLY  GetDepartmenForEmployee(e.DepartmentID)


/*OUTER APPLY==LEFT JOIN*/
SELECT EMP_NAME,Salary,DepartName
FROM Employees e
OUTER APPLY  GetDepartmenForEmployee(e.DepartmentID)
SELECT *FROM Employees;
SELECT * FROM Department


--Fetch details of all emp their manager,their department

SELECT e.EmployeeID,e.Emp_Name,m.ManagerName,d.DepartName
FROM Employees e 
LEFT JOIN Department d 
ON e.DepartmentID=d.DepartmentID 
LEFT JOIN Manager m 
ON e.ManagerID=m.ManagerID;





/*------------------------------------------------------------------------SUBQUERIES-------------------------------------------------------------------------------*/
/*first subquery gets executed*/
SELECT *FROM Employees WHERE Salary>                    --outer/main query
(Select AVG(Salary) FROM Employees);                    --inner/subquery


/*types of subqueries*/
/*SCALAR SUBQUERY   -- one record + one column*/
SELECT *FROM Employees WHERE Salary>                    
(Select AVG(Salary) FROM Employees);  

SELECT *
FROM Employees e
JOIN (Select AVG(Salary) sal FROM Employees) AS Avg_sal
ON Salary>sal



/*MULTIPLE ROW SUBQUERY*/
/*multiple rows and multiple columns*/
SELECT MAX(Salary),DepartmentID
FROM Employees
GROUP BY DepartmentID

SELECT e.Emp_Name,e.Salary,d.Max_Sal,d.DepartmentID
FROM Employees e
JOIN
(SELECT DepartmentID,MAX(Salary) Max_Sal
                FROM Employees
                GROUP BY DepartmentID) AS d
ON e.DepartmentID=d.DepartmentID AND e.Salary=d.Max_Sal;


/*multiple rows and single column*/
/*department who dont have employee*/
SELECT *
FROM Department d
WHERE DepartmentID NOT IN (SELECT DISTINCT(DepartmentID) FROM Employees); 


/*CORRELATED SUBQUERY
Subquery related to outer query
for every row in outer query,correlated subquery executes once
so if there are millions of records then subquery executes millions of times hence performance issue*/

/*Find employees in each dept who earn more than avg salary in that dept*/
SELECT *
FROM Employees e1
WHERE Salary>
(SELECT AVG(Salary)
FROM Employees e2
where e1.DepartmentID =e2.DepartmentID);

/*Find depatrment that doesn't have employees*/
SELECT *
FROM Department d
WHERE 0=
(SELECT COUNT(*) FROM Employees e WHERE e.DepartmentID = d.DepartmentID);


/*not exists=true if subquery result doesn't have any records else false*/
SELECT *
FROM Department d
WHERE NOT exists
(SELECT DepartmentID FROM Employees e WHERE e.DepartmentID = d.DepartmentID);


/*NESTED SUBQUERY*/
USE Prac;
CREATE TABLE Sales(SalesID int,Name varchar(30),price int);
INSERT INTO Sales Values(1,'Apple',1000);
INSERT INTO Sales Values(1,'Apple',6000);
INSERT INTO Sales Values(1,'Apple',500);
INSERT INTO Sales Values(1,'Apple2',2000);
INSERT INTO Sales Values(1,'Apple3',750);
INSERT INTO Sales Values(1,'Apple3',2000);
INSERT INTO Sales Values(1,'Apple3',4400);
INSERT INTO Sales Values(1,'Apple3',1800);
INSERT INTO Sales Values(1,'Apple3',750);
INSERT INTO Sales Values(1,'Apple4',3500);
INSERT INTO Sales Values(1,'Apple4',1500);
Delete from Sales where name='Apple' and price=1000;
SELECT *FROM Sales;
/*find stores whose sales are better than the average sales across all stores*/

SELECT ABC.Name,ABC.Sumss
FROM
     (SELECT Name,SUM(Price) AS Sumss 
      FROM Sales 
      GROUP BY Name) ABC
WHERE ABC.Sumss > 
     (
	   SELECT AVG(Sums) as avg_sales
       FROM
      (SELECT Name,SUM(Price) AS Sums FROM Sales 
       GROUP BY Name) xys
	 );
 

 


 /*---------------------------------------------CLAUSES WHERE WE CAN USE SUBQUERY------------------------------------------------------------------------------------*/
 /*SELECT,WHERE,HAVING,FROM*/
 /*Subquery in Where*/
 SELECT *FROM Employees WHERE Salary>                    
 (Select AVG(Salary) FROM Employees);




/*-------------------------------------------------------ANY(SOME)/ALL/EXISTS---------------------------------------------------------------------------------------*/
/*used along with subquery in where,having clause*/
SELECT EMP_NAME
FROM Employees
WHERE Salary >= ALL(SELECT DISTINCT(Salary) FROM Employees WHERE DepartmentID='D2');


SELECT EMP_NAME
FROM Employees
WHERE Salary > ANY(SELECT DISTINCT(Salary) FROM Employees WHERE DepartmentID='D2');

SELECT EMP_NAME
FROM Employees
WHERE Salary > SOME(SELECT DISTINCT(Salary) FROM Employees WHERE DepartmentID='D2');

/*not exists=true if subquery result doesn't have any records else false*/
SELECT *
FROM Department d
WHERE NOT exists
(SELECT DepartmentID FROM Employees e WHERE e.DepartmentID = d.DepartmentID);









/*-------------------------------------------------------------------------open ended--------------------------------------------------------------------------------*/
/*can we use cross apply on concrete tables?*/
SELECT Emp_Name,DepartName 
FROM Employees e
OUTER APPLY
Department d
ON e.DepartmentID=d.DepartmentID;