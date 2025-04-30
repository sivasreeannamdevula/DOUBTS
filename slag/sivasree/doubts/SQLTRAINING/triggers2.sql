/*---------------------------------------------------------DDL TRIGGERS-------------------------------------------------------------------------------*/
/*When we CREATE ,ALTER,DROP database objects then CREATE_TABLE events gets raised and the corresponding trigger gets called if there are any
*/

/*DATABASE SCOPED DDL TRIGGER*/
CREATE TRIGGER DDL_Create
ON Database                                   --database scope
FOR CREATE_TABLE,ALTER_TABLE,DROP_TABLE
AS
BEGIN 
    PRINT 'new table created AND ALSO AlTERED,DROPEED'
END

CREATE TABLE Test2(ID int)
DROP TABLE Test2;

/*Disableing the trigger*/
DISABLE TRIGGER DDL_Create ON DATABASE
/*enabling the trigger*/
ENABLE TRIGGER DDL_Create ON DATABASE
/*dropping the trigger*/
DROP TRIGGER DDL_CREATE ON DATABASE

/*we can also use triggers for some stored proc like rename*/
CREATE TRIGGER tr_rename
ON Database
FOR RENAME
AS
BEGIN
    Print 'you are trying to rename'
END

EXEC sp_rename 'Test1' ,'TestNew2'



/*SERVER SCOPED DDL TRIGGER*/
ALTER TRIGGER trigger_server2
ON ALL SERVER
FOR CREATE_TABLE
AS
BEGIN
    
	Print 'cannot create'
END

CREATE TABLE ServerTest(ID int);
DROP TABLE ServerTest

DISABLE TRIGGER trigger_server ON ALL SERVER
ENABLE TRIGGER trigger_server2 ON ALL SERVER
DISABLE TRIGGER ALL ON ALL SERVER                      --To disable all the server triggers at once
DROP TRIGGER trigger_server ON ALL SERVER



/*----EXECUTION ORDER OF TRIGGERS----*/
/*SERVER SCOPED trigers runs FIRST only then Database scoped triggers run and we cannot change this order but within the all available serverscoped
or databasescoped triggers we can change the order using sp_settriggerorder 
by default the order of execution within a serverscoped/databasescoped is the order in which the triggers got executed*/
CREATE TRIGGER tr_ScopedForOrder
ON ALL SERVER
FOR CREATE_TABLE
AS 
BEGIN
    PRINT 'Server called first'
END

CREATE TRIGGER tr_DatabaseForOrder
ON Database
FOR CREATE_TABLE
AS
BEGIN
    PRINT 'Database called later'
END

Create table TestingOrder(ID int);


/*SETTING THE ORDER*/
CREATE TRIGGER tr_DBfirst
ON ALL SERVER
FOR CREATE_TABLE
AS
BEGIN
   PRINT 'First server trigger'
END

CREATE TRIGGER tr_DBsecond
ON ALL SERVER
FOR CREATE_TABLE
AS
BEGIN
   PRINT 'second server trigger'
END

CREATE TRIGGER tr_DBthird
ON ALL SERVER
FOR CREATE_TABLE
AS
BEGIN
   PRINT 'third server trigger'
END

CREATE TRIGGER tr_DBfirstDB
ON DATABASE
FOR CREATE_TABLE
AS
BEGIN
   PRINT 'First db trigger'
END
CREATE TRIGGER tr_DBsecondDB
ON DATABASE
FOR CREATE_TABLE
AS
BEGIN
   PRINT 'second db trigger'
END
CREATE TRIGGER tr_DBthirdDB
ON DATABASE
FOR CREATE_TABLE
AS
BEGIN
   PRINT 'third db trigger'
END

CREATE TABLE OrderTest(ID int)            --here we get the order in which we executed
DROP TABLE OrderTest;
/*setting the order*/
EXEC sp_settriggerorder
@triggername='tr_DBfirst',
@order='last',
@stmttype='CREATE_TABLE',
@namespace='Server'

EXEC sp_settriggerorder
@triggername='tr_DBthird',
@order='first',
@stmttype='CREATE_TABLE',
@namespace='Server'





/*--------------------------------------------------------------------LOGON TRIGGERS-------------------------------------------------------------------*/
/*in this below code we get the no.of connections to the current user and if they exceed 3 then we are rolling back...hence we are restricting the
no.of logins*/
SELECT is_user_process,original_login_name
FROM sys.dm_exec_sessions 
ORDER BY login_time DESC

ALTER TRIGGER tr_Logon
ON ALL SERVER
FOR LOGON
AS
BEGIN
      DECLARE @LoginName nvarchar(30)
	  SET @LoginName=ORIGINAL_LOGIN()
	
      IF(SELECT COUNT(*) FROM sys.dm_exec_sessions 
	     WHERE is_user_process=1 AND 
	     original_login_name=@LoginName ) > 4
	  BEGIN 
	      ROLLBACK;
	  END

END