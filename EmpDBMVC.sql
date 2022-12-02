/*Database creation*/
create database EmployeeDBMVC
use EmployeeDBMVC

/* Table creation */
CREATE TABLE EmpDetails
(
	EmpID INT IDENTITY NOT NULL,
	EmpName varchar(255) NOT NULL,
	ProfileImg varchar(255) NOT NULL,
	Gender varchar(20) NOT NULL,
	Department varchar(255) NOT NULL,
	Salary float,
	StartDate DATETIME ,
	Notes varchar(255) 

)
/* To add employees */
Create procedure spAddEmp(
	@EmpName varchar(255) ,
	@ProfileImg varchar(255),
	@Gender varchar(20),
	@Department varchar(255),
	@Salary float,
	@StartDate DATETIME ,
	@Notes varchar(255) 
)
AS 
Begin 
	Insert into EmpDetails (EmpName,ProfileImg,Gender,Department,Salary,StartDate,Notes)         
    Values (@EmpName,@ProfileImg,@Gender, @Department,@Salary,@StartDate,@Notes)         
End

/*for get all employees*/ 
Create procedure spGetAllEmployees      
as      
Begin      
    select *      
    from EmpDetails      
End

/*for update employee Details*/ 
Create procedure spUpdateEmployee          
(    
	@EmpID int,     
   @EmpName varchar(255) ,
	@ProfileImg varchar(255),
	@Gender varchar(20),
	@Department varchar(255),
	@Salary float,
	@StartDate DATETIME ,
	@Notes varchar(255)        
)          
as          
begin          
   Update EmpDetails           
   set 
   EmpName=@EmpName,          
   ProfileImg=@ProfileImg,
   Gender=@Gender,
   Department=@Department,
   Salary=@Salary,
   StartDate=@StartDate,
   Notes=@Notes
   where EmpID=@EmpID      
End 

/*for delete employee Details*/ 
Create procedure spDeleteEmployee         
(          
   @EmpID int          
)          
as           
begin          
   Delete from EmpDetails where EmpID=@EmpID          
End     