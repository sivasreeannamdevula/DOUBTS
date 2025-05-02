use Prac;
create table ScopeIdentityTable(id int Identity(2,3),name varchar(70),age int);
insert into ScopeIdentityTable values('sivasree',21);
insert into ScopeIdentityTable values('jahnavi',21);
insert into ScopeIdentityTable values('roja',21);
insert into ScopeIdentityTable values('chaitu',21);
insert into ScopeIdentityTable values('sai',21);
insert into ScopeIdentityTable values('siva',21);
select *from ScopeIdentityTable;
insert into ScopeIdentityTable values('check',21);

create table ScopeIdentityTable2(id int Identity(20,9),name varchar(70),age int);
insert into ScopeIdentityTable2 values('sivasree',21);
insert into ScopeIdentityTable2 values('jahnavi',21);
insert into ScopeIdentityTable2 values('roja',21);
insert into ScopeIdentityTable2 values('chaitu',21);
insert into ScopeIdentityTable2 values('sai',21);
insert into ScopeIdentityTable2 values('saro',21);
select *from ScopeIdentityTable2;
insert into ScopeIdentityTable2 values('sare',21);


CREATE TRIGGER first_trigger
on ScopeIdentityTable
after insert
as 
begin
    insert into ScopeIdentityTable2 values('tej',21);
end;

/*scopeidentity gives the last identity value in the current session for the current scope*/
select SCOPE_IDENTITY();

/*ident_current* returns the last identity value of the table*/
select IDENT_CURRENT('ScopeIdentityTable');
select IDENT_CURRENT('ScopeIdentityTable2');

/* @Identity returns the last value in the current session*/
select @@IDENTITY;