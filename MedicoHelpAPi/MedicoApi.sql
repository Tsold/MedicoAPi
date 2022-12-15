Create database Medico

CREATE TABLE Roles
(
    IDRole uniqueidentifier PRIMARY KEY NOT NULL,
    RoleName NVARCHAR(255) NOT NULL
) 
Go

CREATE TABLE Users
(
    IDUser uniqueidentifier PRIMARY KEY NOT NULL,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    DateOfBirth DATE NOT NULL,
    RoleID uniqueidentifier NOT NULL REFERENCES Roles(IDRole)
)
 Go

CREATE TABLE Clinic
(
    IDClinic uniqueidentifier PRIMARY KEY NOT NULL,
    UserID uniqueidentifier NOT NULL REFERENCES Users(IDUser),
    ClinicName NVARCHAR(255) NOT NULL,
    ShortDes NVARCHAR(200) NOT NULL,
    [Address] NVARCHAR(255) NOT NULL,
    Phone NVARCHAR(255) NOT NULL,
    Email NVARCHAR(200) NOT NULL
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
    IDService uniqueidentifier PRIMARY KEY,
    IDClinic uniqueidentifier NOT NULL REFERENCES Clinic(IDClinic),
    SubcategoryID uniqueidentifier NOT NULL REFERENCES Subcategory(IDSubcategory),
    ServiceName NVARCHAR(125) NOT NULL,
    ShortDes NVARCHAR(255) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    Preparation NVARCHAR(255)
) 
Go
