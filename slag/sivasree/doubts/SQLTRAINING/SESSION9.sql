/*--------------------------------------------------------TRANSACTIONS---------------------------------------------------------------------------------*/
/*group of SQL statements are called transactions(if any one statement fails in execution then all queries are rolled back)
and trasactions ensure ACID properties*/
/*VIOLATIONS we generally get r DIRTY READ,NON-REPEATABLE READ , PHANTOM */
/*Isolation levels are READ UNCOMMITTED(more concurrent transactions are running here), READ COMMITTED(default isolaion level), REPEATABLE READ, 
                       SERIALIZABLE(less concurrent transactions)*/
/*DIRTY READ                if the transaction is not committed and we have performed read
  NON-REPEATABLE READ       if we read the data in a transaction1 and then tranasaction2 updates some data then again when T1 reads it gets diff value
  PHANTOM                   if inserts,updates,deletes are performed by other transaction then the result of current transaction varies*/


  
  
  
  DBCC USEROPTIONS;            --to know the isolation level we can use this commmand
/*DIRTY READ*/
SELECT *FROM Employees
BEGIN TRANSACTION
UPDATE 

  


