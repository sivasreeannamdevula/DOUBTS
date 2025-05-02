USE Prac;
CREATE TABLE ExecutionPlan(ExecutionPlanID int,Name varchar(80));
INSERT INTO ExecutionPlan VALUES(1,'a');
INSERT INTO ExecutionPlan VALUES(2,'a');
INSERT INTO ExecutionPlan VALUES(3,'a');
INSERT INTO ExecutionPlan VALUES(4,'a');
INSERT INTO ExecutionPlan VALUES(5,'a');
INSERT INTO ExecutionPlan VALUES(6,'a');
INSERT INTO ExecutionPlan VALUES(7,'a');
INSERT INTO ExecutionPlan VALUES(8,'a');
INSERT INTO ExecutionPlan VALUES(10,'a');
DECLARE @x int;
SET @x=50000;
WHILE(@x<60000)
   BEGIN
   INSERT INTO ExecutionPlan VALUES(@x,'a');
   SET @x=@x+1;
   END;

SELECT *FROM ExecutionPlan;

SET STATISTICS TIME ON;
SELECT *FROM ExecutionPlan WHERE ExecutionPlanID>8999;
SET STATISTICS TIME OFF;

EXEC sp_helpindex ExecutionPlan ;
CREATE INDEX index123 ON ExecutionPlan(ExecutionPlanID);
CREATE INDEX index1233 ON ExecutionPlan(ExecutionPlanID);

DROP INDEX index123 ON ExecutionPlan;