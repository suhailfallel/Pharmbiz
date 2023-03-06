create database PharmBizz

use PharmBizz

create table MedicalOutlet
(
Id int,
Outlet_Name varchar(200),
Outlet_LicensiName varchar(200),
Outlet_LicenseNum varchar(200),
Outlet_Address varchar(200),
Outlet_Place varchar(200),
Outlet_District varchar(200),
Outlet_State varchar(200),
Outlet_Contact varchar(200),
Outlet_Email varchar(200),
Username varchar(200),
Password varchar(200),
Status varchar(20))

create table Users
(
Id int,
Name varchar(200),
Address varchar(200),
LandMark varchar(200),
District varchar(200),
State varchar(200),
Email varchar(200),
Contact varchar(200),
Username varchar(200),
Password varchar(200),
Status varchar(200))

create table LoginCredentials
(
Id int,
Reg_Id int,
Email varchar(200),
Username varchar(200),
Password varchar(200),
Status varchar(20))



create table OrderHistory
(
Id int,
Usr_Id int,
Usr_Name varchar(200),
Usr_Address varchar(200),
Medicine_Name varchar(200),
Batch_No int,
Quantity int,
Price int,
Outlet_Id int,
Outlet_Name varchar(200),
Outlet_Place varchar(200),
OrderStatus varchar(200),
foreign key (Usr_Id) references Users(Id),
foreign key (Outlet_Id) references MedicalOutlet(Id))

alter trigger adduser on Users for insert
as
begin
	declare @regid as int, @email as varchar(200), @username as varchar(200), @password as varchar(200), @status as varchar(20), @ct as float
	select @regid=(select Id from inserted)
	select @email=(select Email from inserted)
	select @username=(select Username from inserted)
	select @password=(select Password from inserted)
	select @status=(select Status from inserted)
	set @ct=(select count(*) from LoginCredentials where Reg_Id=@regid and Email=@email)
	if(@ct > 0)
		begin
			update LoginCredentials set Username=@username, Password=@password where Email=@email
		end
	else
		begin
			insert into LoginCredentials(Reg_Id, Email, Username, Password, Role, Status)
			values(@regid, @email, @username, @password, 'User', @status)
		end
end

create trigger addoutlet on MedicalOutlet for insert
as
begin
	declare @regid as int, @email as varchar(200), @username as varchar(200), @password as varchar(200), @status as varchar(20), @ct as float
	select @regid=(select Id from inserted)
	select @email=(select Outlet_Email from inserted)
	select @username=(select Username from inserted)
	select @password=(select Password from inserted)
	select @status=(select Status from inserted)
	set @ct = (select count(*) from LoginCredentials where Reg_Id=@regid and Email=@email)
	if(@ct > 0)
		begin
			update LoginCredentials set Username=@username, Password=@password where Email=@email
		end
	else
		begin
			insert into LoginCredentials(Reg_Id, Email, Username, Password, Role, Status)
			values(@regid, @email, @username, @password, 'Outlet', @status)
		end
end

select * from LoginCredentials
select * from Users

create table Companies
(
Id int,
Company_Name varchar(200),
Company_RegNo varchar(200),
Company_Address varchar(200),
Company_District varchar(200),
Company_State varchar(200),
Company_Contact varchar(200),
Company_Email varchar(200),
Username varchar(200),
Password varchar(200),
Status varchar(20))

create table Medicine  
(
Id int,
Batch_No int,
Medicine_Name varchar(200),
Dosage varchar(200),
Company_Id int,
Company_Name varchar(200),
Date_of_Mfg datetime,
Date_of_Exp datetime,
Price int,
Quantity int,
Stock_Status varchar(200),
foreign key(Company_Id)references Companies(Id))

select * from Medicine
select * from UserOrders

create table OutletOrders
(
Id int,
Outlet_Id int,
Outlet_Name varchar(200),
Outlet_Address varchar(200),
Medicine_Id int,
Medicine_Name varchar(200),
Medicine_Dosage varchar(200),
Batch_No varchar(200),
Mfg_Date DateTime,
Exp_Date DateTime,
Quantity int,
Price int,
Company_Id int,
Company_Name varchar(200),
Order_Status varchar(20),
foreign key(Outlet_Id) references MedicalOutlet(Id),
foreign key(Medicine_Id) references Medicine(Id),
foreign key(Company_Id) references Companies(Id))

select * from OutletOrders

create table OutletStocks
(
Id int,
Outlet_Id int,
Outlet_Name varchar(200),
Medicine_Id int,
Batch_No varchar(200),
Medicine_Name varchar(200),
Medicine_Dosage varchar(200),
Mfg_Date datetime,
Exp_Date datetime,
Quantity int,
Price int,
Company_Id int,
Company_Name varchar(200),
Stock_Status varchar(50),
foreign key(Outlet_Id) references MedicalOutlet(Id),
foreign key(Medicine_Id) references Medicine(Id),
foreign key(Company_Id) references Companies(Id))

select * from OutletStocks

create table UserOrder
(
Id int,
Outlet_Id int,
Outlet_Name varchar(200),
User_Id int,
Name varchar(200),
Address varchar(200),
District varchar(200),
State varchar(200),
Contact varchar(200),
Medicine_Id int,
Medicine_Name varchar(200),
Company_Name varchar(200),
BatchNo int,
Quantity int,
Price int,
TotalPrice int,
OrderStatus varchar(200),
foreign key(User_Id) references Users(Id))

select * from UserOrder

drop table UserOrders

select * from LoginCredentials

alter trigger addcompany on Companies for insert
as
begin
	declare @regid as int, @email as varchar(200), @username as varchar(200), @password as varchar(200), @status as varchar(20), @ct as int
	select @regid=(select Id from inserted)
	select @email=(select Company_Email from inserted)
	select @username=(select Username from inserted)
	select @password=(select Password from inserted)
	select @status=(select Status from inserted)
	set @ct=(select count(*) from LoginCredentials where Reg_Id=@regid and Email=@email)
	if(@ct>0)
		begin
			Update LoginCredentials set Username=@username, Password=@password where Email=@email
		end
	else
		begin
			insert into LoginCredentials(Reg_Id, Email, Username, Password, Role, Status)
			values(@regid, @email, @username, @password, 'Company', @status)
		end
end

alter trigger userupdate on Users after update
as
begin
	declare @regid as int, @email as varchar(200), @username as varchar(200), @password as varchar(200), @status as varchar(20), @ct as int
	select @regid=(select Id from inserted)
	select @email=(select Email from inserted)
	select @username=(select Username from inserted);
	select @password=(select Password from inserted);
	select @status=(select Status from inserted);
	set @ct=(select count(*) from LoginCredentials where Reg_Id=@regid and Email=@email)
	if(@ct>0)
		begin	
			update LoginCredentials set Username=@username, Password=@password, Status=@status where Email=@email
		end
end

create trigger outletupdate on MedicalOutlet after update
as
begin
	declare @regid as int, @email as varchar(200), @username as varchar(200), @password as varchar(200), @status as varchar(20), @ct as int
	select @regid=(select Id from inserted)
	select @email=(select Outlet_Email from inserted)
	select @username=(select Username from inserted)
	select @password=(select Password from inserted)
	select @status=(select Status from inserted)
	set @ct=(select count(*) from LoginCredentials where Reg_Id=@regid and Email=@email)
	if(@ct>0)
		begin
			update LoginCredentials set Username=@username, Password=@password, Status=@status where Email=@email
		end
end

create trigger companyupdate on Companies after update
as
begin
	declare @regid as int, @email as varchar(200), @username as varchar(200), @password as varchar(200), @status as varchar(20), @ct as int
	select @regid=(select Id from inserted)
	select @email=(select Company_Email from inserted)
	select @username=(select Username from inserted)
	select @password=(select Password from inserted)
	select @status=(select Status from inserted)
	set @ct=(select count(*) from LoginCredentials where Reg_Id=@regid and Email=@email)
	if(@ct>0)
		begin
			update LoginCredentials set Username=@username, Password=@password, Status=@status where Email=@email
		end
end

select * from Companies

select * from LoginCredentials

select * from MedicalOutlet

select * from Medicine

select * from OutletOrders

select * from OutletStocks

select * from UserOrder

select * from Users