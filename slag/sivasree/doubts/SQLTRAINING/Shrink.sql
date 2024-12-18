use master;
create database anirudh;
use anirudh;
create table anirudh(id int,name varchar(56));
insert into anirudh values(1,'full');
insert into anirudh values(2,'full');

DECLARE @i INT = 1;

WHILE @i <= 100000
BEGIN
    INSERT INTO anirudh VALUES (@i, 'full');
    SET @i = @i + 1;
END

backup database anirudh to disk='C:\SQLBackup\anirudhfull1.bak'
backup log anirudh to disk='C:\SQLBackup\anirudhlog1.trn'

/*if we keep on inserting the data into the table then log file size increases...then we do backup also .trn file increases 
but the disk space allocated to .log file doesn't change ..so then use shrink to decrease the allocated disk space */

DBCC shrinkfile ('anirudh_log', 0);

DBCC SQLPERF(LOGSPACE);              /*this command gives the space allocated and used percentages*/



/*logical name can be set using with name..to see logical name run headeronly command*/
BACKUP DATABASE anirudh TO DISK ='C:\SQLBackup\anirudhFUll.bak' with name = 'test1';  

/*if we would like to restore the outer available db to a location first we need to know the logical name for that we use filelistonly*/
restore FILELISTONLY from disk='C:\SQLBackup\anirudhFUll.bak'    

restore database adventure from disk='C:\SQLBackup\AdventureWorks2022.bak'
with move 'AdventureWorks2022' to 'C:\NewDb\adventure.mdf',
move 'AdventureWorks2022_log' to 'C:\NewDb\adevnture_log.ldf'

restore filelistonly from disk='C:\SQLBackup\AdventureWorks2022.bak'

backup database anirudh to disk='C:\SQLBackup\anirudhfull1.bak'
with name='anirudh' , description='hey my first's

restore headeronly from disk='C:\SQLBackup\anirudhfull1.bak'