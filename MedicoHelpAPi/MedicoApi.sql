Create database Medico
go

use Medico
GO

CREATE TABLE Roles
(
    IDRole uniqueidentifier PRIMARY KEY NOT NULL,
    RoleName NVARCHAR(255) NOT NULL
) 
Go

CREATE TABLE Users
(
    IDUser NVARCHAR(128) PRIMARY KEY NOT NULL,
    RoleID uniqueidentifier NOT NULL REFERENCES Roles(IDRole)
)
Go

CREATE TABLE Client(
    IDClient UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    UserID NVARCHAR(128) NOT NULL REFERENCES Users(IDUser),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    DateOfBirth DATE NOT NULL
) 

CREATE TABLE Clinic
(
    IDClinic uniqueidentifier PRIMARY KEY NOT NULL,
    UserID NVARCHAR(128) NOT NULL REFERENCES Users(IDUser),
    ClinicName NVARCHAR(255) NOT NULL,
    ShortDes NVARCHAR(200) NOT NULL,
    [Address] NVARCHAR(255) NOT NULL,
    Phone NVARCHAR(255) NOT NULL,
    Email NVARCHAR(200) NOT NULL,
    Latitude DECIMAL(9,6) NOT NULL,
    Longitude DECIMAL(9,6) NOT NULL
) 
Go

CREATE TABLE Category
(
    IDCategory uniqueidentifier PRIMARY KEY,
    CategoryName NVARCHAR(255) NOT NULL
) 
Go

CREATE TABLE Subcategory
(
    IDSubcategory uniqueidentifier PRIMARY KEY,
    SubcategoryName NVARCHAR(255) NOT NULL,
    CategoryID uniqueidentifier NOT NULL REFERENCES Category(IDCategory)
)
Go


CREATE TABLE MedicalService
(
    IDMedicalService uniqueidentifier PRIMARY KEY,
    SubcategoryID uniqueidentifier NOT NULL REFERENCES Subcategory(IDSubcategory),
    ServiceName NVARCHAR(125) NOT NULL,
) 
Go

CREATE TABLE ClinicalService
(
    IDService uniqueidentifier PRIMARY KEY,
    IDClinic uniqueidentifier NOT NULL REFERENCES Clinic(IDClinic),
    MedicalServiceID uniqueidentifier NOT NULL REFERENCES MedicalService(IDMedicalService),
    ServiceName NVARCHAR(125) NOT NULL,
    ShortDes NVARCHAR(255) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    Preparation NVARCHAR(255)
) 
Go

CREATE TABLE Meeting (
  IDMeeting uniqueidentifier PRIMARY KEY NOT NULL,
  ServiceID uniqueidentifier NOT NULL REFERENCES ClinicalService(IDService),
  UserID NVARCHAR(128) REFERENCES Users(IDUser),
  Datefrom DATETIME NOT NULL,
  Dateto DATETIME NOT NULL,
  EventName VARCHAR(255) NOT NULL
)
GO

drop table Meeting

CREATE TABLE WeekDays(
IDWeekDays uniqueidentifier PRIMARY KEY NOT NULL,
DayName VARCHAR(3) NOT NULL
)
GO

CREATE TABLE WorkingHours(
IDAvailableTimeFrame  uniqueidentifier PRIMARY KEY NOT NULL,
WeekDayID uniqueidentifier NOT NULL REFERENCES WeekDays(IDWeekDays),
IDClinic uniqueidentifier NOT NULL REFERENCES Clinic(IDClinic),
Datefrom DATETIME NOT NULL,
Dateto DATETIME NOT NULL
)
GO



CREATE TABLE AvailableTimeFrame(
IDAvailableTimeFrame  uniqueidentifier PRIMARY KEY NOT NULL,
Datefrom DATETIME NOT NULL,
Dateto DATETIME NOT NULL,
BreakFrom DATETIME,
BreakTo DATETIME,
ServiceID uniqueidentifier NOT NULL REFERENCES ClinicalService(IDService),
)
GO

