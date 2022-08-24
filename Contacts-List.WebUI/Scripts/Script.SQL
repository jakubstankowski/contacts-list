
CREATE TABLE Persons (
    PersonId int IDENTITY(1,1) PRIMARY KEY,
    LastName varchar(255),
    FirstName varchar(255),
	DateOfBirth date,
    Earnings integer
);


CREATE TABLE Mothers (
    MotherId int IDENTITY(1,1) PRIMARY KEY,
    LastName varchar(255),
    FirstName varchar(255),
	PersonId INT UNIQUE FOREIGN KEY REFERENCES Persons(PersonId)
);

CREATE TABLE Fathers (
    FatherId int IDENTITY(1,1) PRIMARY KEY,
    LastName varchar(255),
    FirstName varchar(255),
	PersonId INT UNIQUE FOREIGN KEY REFERENCES Persons(PersonId)
);

CREATE TABLE Husbands (
    HusbandId int IDENTITY(1,1) PRIMARY KEY,
    LastName varchar(255),
    FirstName varchar(255),
	PersonId INT UNIQUE FOREIGN KEY REFERENCES Persons(PersonId)
);

CREATE TABLE Wifes (
    WifeId int IDENTITY(1,1) PRIMARY KEY,
    LastName varchar(255),
    FirstName varchar(255),
	PersonId INT UNIQUE FOREIGN KEY REFERENCES Persons(PersonId)
);

CREATE TABLE CompanyBoss (
    CompanyBossId int IDENTITY(1,1) PRIMARY KEY,
    Name varchar(255),
	CompanyId INT UNIQUE FOREIGN KEY REFERENCES Company(CompanyId)
);


CREATE TABLE Company (
   CompanyId int IDENTITY(1,1) PRIMARY KEY,
   Name varchar(255),
PersonId INT  FOREIGN KEY REFERENCES Persons(PersonId)
);

CREATE TABLE ContractType (
    ContractTypeId int IDENTITY(1,1) PRIMARY KEY,
    Name varchar(255),
);


CREATE TABLE CompanyBoss (
   CompanyBossId int IDENTITY(1,1) PRIMARY KEY,
   Name varchar(255),
);



INSERT INTO Persons(FirstName, LastName, DateOfBirth, Earnings)
VALUES ('Jakub', 'Stankowski', '1996-09-27', 4000);

INSERT INTO Persons(FirstName, LastName, DateOfBirth, Earnings)
VALUES ('Natalia', 'Stankowska', '1996-09-27', 4000);

GO

INSERT INTO Mothers
VALUES ('Bożena', 'Stankowska', 1);

INSERT INTO Mothers
VALUES ('Wiolleta', 'Kujawiak', 2);


