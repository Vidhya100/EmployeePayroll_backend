create database EmployeeDBMVC
use EmployeeDBMVC

CREATE TABLE EmpDetails
(
	EmpID INT IDENTITY NOT NULL,
	EmpName varchar(256) NOT NULL,
	ProfileImg varchar(256) NOT NULL,
	Gender varchar(20) NOT NULL,
	Department varchar(256) NOT NULL,
	Salary double,
	StartDate DATETIME ,
	Notes varchar(256) 

)