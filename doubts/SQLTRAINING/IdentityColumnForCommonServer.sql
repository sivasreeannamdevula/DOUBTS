use May2024
CREATE TABLE RANDOM(id int Identity(2,3),full_name varchar(80),age int,CREATED_AT DATETIME DEFAULT GETDATE() );

insert into RANDOM(full_name,age) values('sivarsee',3360);
select *from RANDOM;
Drop Table RANDOM;

DECLARE @i INT = 1;
 
WHILE @i <= 50
BEGIN
    INSERT INTO RANDOM(full_name,age) VALUES ('sivasree',6987657);
    SET @i = @i + 1;
END