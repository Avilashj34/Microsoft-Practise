create database DoctorDb

use DoctorDb

select name from sys.tables

create table patients(id int primary key identity(1,1),name varchar(255) NOT NULL,phone varchar(15) NOT NULL,gender varchar(15) NOT NULL,health_condition varchar(255) NOT NULL,doctor_id int NOT NULL,
nurse_id int NOT NULL,created_time datetime default GETDATE())

select * from patients

create table Register(id int identity(1,1) primary key,Name varchar(20),Phone varchar(20),Password varchar(20))
alter table Register add constraint phone_unique unique(Phone) 

create table Login(id int identity(1,1) primary key,Last_Login_Detail datetime default getdate())
alter table Login add Phone varchar(20) constraint phone_unique_reference references Register(Phone)



alter table Register add User_Verified int 
alter table Register add Created datetime default GETDATE()
alter table Register add Last_Login_Detail datetime



create table doctors(id int primary key identity(1,1),name varchar(105) NOT NULL,email varchar(105) NOT NULL,password varchar(105) NOT NULL,
phone varchar(105) NOT NULL ,gender varchar(15) NOT NULL,specialist varchar(105) NOT NULL,created datetime default GETDATE())

create table nurses(id int primary key identity(1,1),name varchar(15) NOT NULL,email varchar(15) NOT NULL,password varchar(15) NOT NULL,
phone varchar(15) NOT NULL ,gender varchar(15) NOT NULL,created datetime default GETDATE())

create table admins(id int primary key identity(1,1),name varchar(15) NOT NULL,email varchar(15) NOT NULL,password varchar(15) NOT NULL,
phone varchar(15) NOT NULL ,created datetime default GETDATE())

select * from Register
select * from doctors
select * from login
delete from Register where id=4

select * from Login

drop table doctors

update Register set Last_Login_Detail=GETDATE() where Phone='8097810653'


alter table Register drop column Last_Login_Detail

create table LogWork(ID int identity(1,1) primary key, InertLog varchar(1000))


drop trigger Delete_logindetail_trigger

insert into Login values(GETDATE(),'8097810653')

Merge into login l
using(select Phone from l where Phone =)
when not matched insert into Login 
when matched set()

create trigger Delete_loginDetail_trigger
on Login
instead of insert 
as 
begin
declare @data varchar(50)
set @data=(select Phone from Inserted)
	if ((select Phone from Login where Phone='@data') is null)
	begin
		insert into Login(Phone) values('@data')
		return
	end
	update Login set Last_Login_Detail=GETDATE() where Phone= @data
end

drop trigger Delete_loginDetail_trigger

insert into Login(Phone) values('858585')

insert into Login(Phone) values('8097810653')
delete from Login where Phone='8097810653'


select Max(Last_Login_Detail) from Login where Phone='8097810653'

select r.Phone,Name,User_Verified from Register as r join Login as l on r.Phone=l.Phone;

select Top 1 *  from Login where Phone='8097810653' order by Last_Login_Detail desc 


/* https://stackoverflow.com/questions/25300557/toast-notifications-in-asp-net-mvc-4 */