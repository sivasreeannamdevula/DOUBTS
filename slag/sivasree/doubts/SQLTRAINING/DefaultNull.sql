use Prac;

create table DefaultExample(id int,full_name varchar(60) default 'fullname',address varchar(90));
exec sp_help DefaultExample;
/*default > NULL */
insert into DefaultExample(id,address) values(1,'rajahmundry,east godavari');
insert into DefaultExample(id,address) values(1,'kakinada,east godavari');
insert into DefaultExample(id,address) values(1,'dowleshwaram,east godavari');
insert into DefaultExample(id,address) values(1,'kadiam, godavari');
insert into DefaultExample(id,address) values(1,'tadepalligudem,west godavari');
select *from DefaultExample;

/*if nullable column is added then null values get placed,later when we add a row we get that default value*/
alter table DefaultExample
add newCol varchar(55) default 'HYDERABAD';
insert into DefaultExample(id,address) values(1,'secunderabad, telangana');


/*if not null column then we get secundrebad*/
alter table DefaultExample
add newCol2 varchar(55) default 'SECUNDERABAD' NOT NULL;
