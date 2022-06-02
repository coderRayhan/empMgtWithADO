use master

create database EmpManagementSystem;

go

use EmpManagementSystem;

go

create table Division(DivID int primary key identity,
						DivName varchar(50))

go

insert into Division(DivName)values('Dhaka');
insert into Division(DivName)values('Chattagram');
insert into Division(DivName)values('Barishal');
insert into Division(DivName)values('Khulna');
insert into Division(DivName)values('Sylhet');
insert into Division(DivName)values('Rangpur');
insert into Division(DivName)values('Mymensingh');
insert into Division(DivName)values('Rajshahi');

go

create table District(DivID int,
					foreign key (DivID) references Division(DivID),
					DistrictName varchar(50))

go

insert into District(DivID, DistrictName)values(1, 'Dhaka');
insert into District(DivID, DistrictName)values(1, 'Narayanganj');
insert into District(DivID, DistrictName)values(1, 'Gazipur');
insert into District(DivID, DistrictName)values(1, 'Kishoreganj');
insert into District(DivID, DistrictName)values(1, 'Manikganj');
insert into District(DivID, DistrictName)values(1, 'Tangail');
insert into District(DivID, DistrictName)values(2, 'Noakhali');
insert into District(DivID, DistrictName)values(2, 'Chattagram');
insert into District(DivID, DistrictName)values(2, 'Comilla');
insert into District(DivID, DistrictName)values(2, 'Bandarban');
insert into District(DivID, DistrictName)values(2, 'Khagrachori');
insert into District(DivID, DistrictName)values(2, 'Rangamati');
insert into District(DivID, DistrictName)values(2, 'Mirshorai');
insert into District(DivID, DistrictName)values(3, 'Barishal');
insert into District(DivID, DistrictName)values(3, 'Bola');
insert into District(DivID, DistrictName)values(3, 'Patuakhali');
insert into District(DivID, DistrictName)values(3, 'Jhalkathi');
insert into District(DivID, DistrictName)values(3, 'Barguna');
insert into District(DivID, DistrictName)values(3, 'Firojpur');
insert into District(DivID, DistrictName)values(4, 'Joshore');
insert into District(DivID, DistrictName)values(4, 'Satkhira');
insert into District(DivID, DistrictName)values(4, 'Natore');
insert into District(DivID, DistrictName)values(4, 'Narail');
insert into District(DivID, DistrictName)values(4, 'Magura');
insert into District(DivID, DistrictName)values(4, 'Meherpur');
insert into District(DivID, DistrictName)values(5, 'Sunamganj');
insert into District(DivID, DistrictName)values(5, 'Sylhet');
insert into District(DivID, DistrictName)values(5, 'Habiganj');
insert into District(DivID, DistrictName)values(5, 'Moulavibazar');
insert into District(DivID, DistrictName)values(6, 'Dinajpur');
insert into District(DivID, DistrictName)values(6, 'Kurigram');
insert into District(DivID, DistrictName)values(6, 'Gaibandha');
insert into District(DivID, DistrictName)values(6, 'Lalmonirhat');
insert into District(DivID, DistrictName)values(6, 'Nilphamari');
insert into District(DivID, DistrictName)values(6, 'Panchagarh');
insert into District(DivID, DistrictName)values(7, 'Mymensingh');
insert into District(DivID, DistrictName)values(7, 'Netrokona');
insert into District(DivID, DistrictName)values(7, 'Jamalpur');
insert into District(DivID, DistrictName)values(7, 'Sherpur');
insert into District(DivID, DistrictName)values(8, 'Joypurhat');
insert into District(DivID, DistrictName)values(8, 'Naogaon');
insert into District(DivID, DistrictName)values(8, 'Nawabganj');
insert into District(DivID, DistrictName)values(8, 'Natore');


go

create table Department (DepartmentID int identity,
						Department varchar(50)  primary key)

go

insert into Department(Department)values('Administration');
insert into Department(Department)values('Accounting');
insert into Department(Department)values('IT');
insert into Department(Department)values('Customer Service');
insert into Department(Department)values('Logistics');
insert into Department(Department)values('Marketing');

go

create table personalInfo (empID int primary key identity,
						Name varchar(255),
						Phone varchar(50),
						Email varchar(50),
						DOB date,
						Gender varchar(50),
						Religion varchar(50),
						Address varchar(255),
						Division varchar(50),
						District varchar(50),
						Imagepath varchar(500));

go

create proc spInsertPersonalInfo @Name varchar(255),
								@Phone varchar(50),
								@Email varchar(50),
								@DOB date,
								@Gender varchar(50),
								@Religion varchar(50),
								@Address varchar(255),
								@Division varchar(50),
								@District varchar(50),
								@ImagePath varchar(500)
as
begin
insert into personalInfo(Name, Phone, Email, DOB, Gender, Religion, Address, Division, District, Imagepath) 
					values (@Name, @Phone, @Email, @DOB, @Gender, @Religion, @Address, @Division, @District, @ImagePath);
end

go


create proc spUpdatePersonalInfo @empID int,
								@Name varchar(255),
								@Phone varchar(50),
								@Email varchar(50),
								@DOB date,
								@Gender varchar(50),
								@Religion varchar(50),
								@Address varchar(255),
								@Division varchar(50),
								@District varchar(50),
								@ImagePath varchar(500)
as
begin
update personalInfo set Name = @Name,
						Phone = @Phone, 
						Email = @Email, 
						DOB = @DOB, 
						Gender = @Gender, 
						Religion = @Religion, 
						Address = @Address, 
						Division = @Division,
						District = @District,
						Imagepath = @ImagePath where empID = @empID
end

go

create proc spDeletePersonalInfo @empID int
as
begin
delete from personalInfo where empID = @empID
end

go


create table empInfo (empID int,
						foreign key (empID) references personalInfo(empID),
						Name varchar(255),
						Department varchar(50),
						foreign key (Department) references Department(Department),
						Designation varchar(50),
						Salary money)

go

create proc spInsertEmpInfo @empID int,
							@Name varchar(255),
							@Department varchar(50),
							@Designation varchar(50),
							@Salary money
as
begin
insert into empInfo (empID, Name, Department, Designation, Salary)
			values(@empID, @Name, @Department, @Designation, @Salary)
end


go

create proc spUpdateEmpInfo @empID int,
							@Name varchar(255),
							@Department varchar(50),
							@Designation varchar(50),
							@Salary money
as
begin
update empInfo set Name = @Name,
					Department = @Department,
					Designation = @Designation,
					Salary = @Salary
					where empID = @empID
end


go

create proc spDeleteEmpInfo @empID int
as
begin
	delete empInfo where empID = @empID
end

go

create table reference(refId int Identity Primary Key ,
						empID int ,
						CONSTRAINT FK1 FOREIGN KEY (empID)
						REFERENCES personalInfo (empID),
						ReferenceName varchar(255),
						ReferenceContact varchar(50))

go

create proc spInsertRefInfo @empID int,
							@ReferenceName varchar(255),
							@ReferenceContact varchar(50)
as
begin
insert into reference (empID, ReferenceName, ReferenceContact)
			values (@empID, @ReferenceName, @ReferenceContact)
end

go

create proc spUpadteRefInfo @empID int,
							@ReferenceName varchar(255),
							@ReferenceContact varchar(50)
as 
begin
	update reference set ReferenceName = @ReferenceName,
							ReferenceContact = @ReferenceContact
					where empID = @empID
end

go

create proc spDeleteRefInfo @empID int 
as
begin
	delete reference where empID = @empID
end




