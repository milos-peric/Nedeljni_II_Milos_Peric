CREATE DATABASE MedicalInstitutionDatabase;

GO

use MedicalInstitutionDatabase;

GO

DROP TABLE IF EXISTS tblUser;
DROP TABLE IF EXISTS tblClinicMaintenace;
DROP TABLE IF EXISTS tblClinicManager;
DROP TABLE IF EXISTS tblClinicDoctor;
DROP TABLE IF EXISTS tblClinicPatient;
DROP TABLE IF EXISTS tblClinicAdmin;
DROP TABLE IF EXISTS tblClinicInstitution;
 
 CREATE TABLE tblUser (
    UserID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    FullName varchar(50),
	IDCardNumber varchar(50),
	Gender varchar(50),
	DateOfBirth date,
    Nationality varchar(50),
	Username varchar(50),
	Password varchar(70)
);
 
 CREATE TABLE tblClinicManager (
    ManagerID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    MaxNumberOfDoctors int,
	MinNumberOdRooms int,
	NumberOfOmissions int,
    ManagerFloor varchar(50),
 	UserID int FOREIGN KEY REFERENCES tblUser(UserID)  
);

 CREATE TABLE tblClinicDoctor (
    DoctorID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    UniqueNumber varchar(50),
	AccountNumber varchar(50),
	Sector varchar(50),
	DoctorShift varchar(50),
	RecievesPatients bit,
	ManagerID int FOREIGN KEY REFERENCES tblClinicManager(ManagerID),  
 	UserID int FOREIGN KEY REFERENCES tblUser(UserID)  
);
  
 CREATE TABLE tblClinicPatient (
    PatientID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    HealthCardNumber varchar(50),
	HealthAssuranceExpiryDate date,
	DoctorUniqueNumber varchar(50), 
	DoctorId int FOREIGN KEY REFERENCES tblClinicDoctor(DoctorId),
 	UserID int FOREIGN KEY REFERENCES tblUser(UserID)  
);
  
 CREATE TABLE tblClinicMaintenace (
    ClinicMaintenaceID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    CanChooseInvalidAccess bit,
	CanChooseClinicExpansionPermission bit,
 	UserID int FOREIGN KEY REFERENCES tblUser(UserID)  
);

 CREATE TABLE tblClinicAdmin (
    AdminID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    HasCreatedClinic bit,
	UserID int FOREIGN KEY REFERENCES tblUser(UserID)  
);

 CREATE TABLE tblClinicInstitution (
    InstitutionID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	InstitutionName varchar(50),
	CreationDate varchar(50),
	InstitutionOwner varchar(50),
    InstitutionAddress varchar(50),
	NumberOdFloors int,
	NumberOfRoomsPerFloor int,
	HasTerrace bit,
	HasYard bit,
	NumberOfAccessPointsForAmbulance int,
	NumberOfAccessPointsForInvalids int
);

GO
CREATE VIEW vwClinicManager AS
	SELECT	tblUser.*, 
			tblClinicManager.ManagerID, tblClinicManager.MaxNumberOfDoctors, tblClinicManager.MinNumberOdRooms, tblClinicManager.NumberOfOmissions, 
			tblClinicManager.ManagerFloor
	FROM	tblUser, tblClinicManager
	WHERE	tblUser.UserID = tblClinicManager.UserID
	
GO	
CREATE VIEW vwClinicPatient AS
	SELECT	tblUser.*, 
			tblClinicPatient.PatientID, tblClinicPatient.HealthCardNumber, tblClinicPatient.HealthAssuranceExpiryDate, 
			tblClinicPatient.DoctorUniqueNumber, tblClinicPatient.DoctorId
	FROM	tblUser, tblClinicPatient
	WHERE	tblUser.UserID = tblClinicPatient.UserID

GO
CREATE VIEW vwClinicDoctor AS
	SELECT	tblUser.*, 
			tblClinicDoctor.DoctorID, tblClinicDoctor.UniqueNumber, tblClinicDoctor.AccountNumber, tblClinicDoctor.Sector, 
			tblClinicDoctor.DoctorShift, tblClinicDoctor.RecievesPatients, tblClinicDoctor.ManagerID
	FROM	tblUser, tblClinicDoctor
	WHERE	tblUser.UserID = tblClinicDoctor.UserID
	
GO
CREATE VIEW vwClinicAdmin AS
	SELECT	tblUser.*, 
			tblClinicAdmin.AdminID, tblClinicAdmin.HasCreatedClinic
	FROM	tblUser, tblClinicAdmin
	WHERE	tblUser.UserID = tblClinicAdmin.UserID	

GO	
CREATE VIEW vwClinicMaintenance AS
	SELECT	tblUser.*, 
			tblClinicMaintenace.ClinicMaintenaceID, tblClinicMaintenace.CanChooseInvalidAccess, tblClinicMaintenace.CanChooseClinicExpansionPermission
	FROM	tblUser, tblClinicMaintenace
	WHERE	tblUser.UserID = tblClinicMaintenace.UserID

