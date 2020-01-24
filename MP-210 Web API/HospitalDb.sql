use HospitalManagementDb
select name from sys.tables
select * from Appointment
select * from [dbo].[patient]
select * from Stay
select * from [dbo].[physician]

delete  from physician where PhysicianId=8
INSERT INTO [dbo].[physician] ([PhysicianName],[PhysicianPosition],[PhysicianSSN])VALUES('Name1','Neurologist',1001)
INSERT INTO [dbo].[physician] ([PhysicianName],[PhysicianPosition],[PhysicianSSN])VALUES('Name2','Therapist',1002)
INSERT INTO [dbo].[physician] ([PhysicianName],[PhysicianPosition],[PhysicianSSN])VALUES('Name3','Technician',1003)
INSERT INTO [dbo].[physician] ([PhysicianName],[PhysicianPosition],[PhysicianSSN])VALUES('Name4','Clerk',1004)
INSERT INTO [dbo].[physician] ([PhysicianName],[PhysicianPosition],[PhysicianSSN])VALUES('Name5','Radiation Therapist',1005)
INSERT INTO [dbo].[physician] ([PhysicianName],[PhysicianPosition],[PhysicianSSN])VALUES('Name6','Recreational Therapist',1006)
INSERT INTO [dbo].[physician] ([PhysicianName],[PhysicianPosition],[PhysicianSSN])VALUES('Name7','Assistant Administrator',1007)


/*2nd*/

use HospitalManagementSystemDb
select * from [dbo].[Undergoes]
select * from [dbo].[Room]
select * from Stay
select * from [dbo].[Medication]
select * from  [dbo].[nurse]
select * from [dbo].[prescribes]
select * from [dbo].[Appointment]
select * from [dbo].[Department]
select * from[dbo].[physician]
select * from patient
select * from Affilated_with

update  Nurse set  Registered = 'False' where NurseId=2

select DepartmentId,DepartmentName,PhysicianName from Department as d join physician as p on d.PhysicianId=p.PhysicianId 

select DepartmentName,COUNT(DepartmentName),PhysicianName from Department as d,physician as p where d.DepartmentId = p.PhysicianId group by DepartmentName,PhysicianName

select * from Department as d join Affilated_with as a on d.DepartmentId = a.DepartmentId join physician as p on p.PhysicianId = a.PhysicianId


delete from Physician where PhysicianSSN=1010
delete from Physician where PhysicianId=17

alter table patient drop column Stay_StayId 

drop index patient.IX_Stay_StayId

insert into Department values('D1',21)

select count(DepartmentName) as Count,DepartmentName from physician as p join Department as d on p.PhysicianId=d.DepartmentId group by DepartmentName

create table Account (id int primary key identity, Email varchar(50),Password varchar(50))


select * from Account

delete from Account where id=4