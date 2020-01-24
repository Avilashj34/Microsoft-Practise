use Online_Shopping
select * from sys.tables
select * from Tbl_Product
create table customer (CustomerId int primary key identity(1,1),UserName varchar(50) constraint FK_Cust_UserName unique, Password varchar(50))
create table product (ProductId int primary key identity(1,1), ProductName varchar(50), ProductPrice int )
alter table product add DateRecord Datetime not null default GETDATE()
create table customer_product(Id int primary key identity(1,1), UserName varchar(50) foreign key references customer(UserName),ProductId int foreign key references product(ProductId))
alter table customer_product add Quantity int not null, DateRecord Datetime not null default GETDATE()
alter table customer_product add Ordered varchar(50) check (Ordered = 'True' or Ordered ='False')
alter table customer_product add Ordered varchar(50) check (Ordered = 'True' or Ordered ='False' or Ordered = 'true' or Ordered = 'false')
alter table customer_product drop constraint CK__customer___Order__2CBDA3B5
select * from customer
select * from product
select * from customer_product

update customer_product set Ordered= '1' where ProductId=3 and UserName='Avilash'

select Quantity,ProductName,c.UserName,ProductPrice,cp.DateRecord from customer as c join customer_product as cp on c.UserName=cp.UserName join product as p on p.ProductId=cp.ProductId 

select cp.Quantity,ProductName,c.UserName,ProductPrice,cp.DateRecord from customer as c join customer_product as cp on c.UserName=cp.UserName join product as p on p.ProductId=cp.ProductId 

 select Count(ProductId) as OrderCount, UserName from customer_product group by UserName

 select cp.Quantity,ProductName,ProductPrice,cp.DateRecord from customer as c join customer_product as cp on c.UserName=cp.UserName join product as p on p.ProductId=cp.ProductId where c.UserName = 'Avilash'

select Count(UserName) as OrderCount from customer_product where UserName='awRohit'

select distinct UserName from customer_product

drop proc sp_insertForeignKey

create procedure sp_updateOrderedValue @username varchar(50),@productid int
as
begin
update customer_product set Ordered= '1' where ProductId=@productid and UserName=@username
end


create proc sp_updateAllOrderedValue @username varchar(50)
as
begin
update customer_product set Ordered='1' where UserName=@username
end

create procedure sp_insertForeignKey @customerusername varchar(50), @productid int, @quantity int,@Ordered varchar(50)
as
begin
insert into customer_product(UserName,ProductId,Quantity,Ordered) values(@customerusername,@productid,@quantity,@Ordered) 
end

drop proc sp_showCustomerOrderProductDetail

drop proc sp_insertForeignKey

create procedure sp_showCustomerOrderDetail 
as
begin
select Count(ProductId) as OrderCount, UserName from customer_product group by UserName
end

create procedure sp_showCustomerOrderProductDetail @UserName varchar(50)
as 
begin
select cp.Quantity,ProductName,ProductPrice,cp.DateRecord,cp.Ordered from customer as c join customer_product as cp on c.UserName=cp.UserName join product as p on p.ProductId=cp.ProductId where c.UserName = @UserName
end

exec sp_showCustomerOrderProductDetail 'Avilash'

exec sp_showCustomerOrderProductDetail 'awRohit'

execute sp_insertForeignKey 'awRohit',3,3,false

execute sp_Registration 'awRohit','ry'

create procedure sp_Registration @username varchar(50),@password varchar(50)
as 
begin
insert into customer values(@username,@password)
end

create procedure sp_Login @username varchar(50),@password varchar(50)
as 
begin
select CustomerId from customer where UserName=@username and Password=@password 
end


execute sp_Registration 'Avilash','av'

create procedure sp_ProductInsert @name varchar(50), @price varchar(50)
as
begin
insert into product(ProductName,ProductPrice) values(@name,@price) 
end


create proc sp_ShowProduct 
as
begin 
select * from product
end



execute sp_ProductInsert 'p2',34
execute sp_ShowProduct

select ProductId from product where ProductName='p2'