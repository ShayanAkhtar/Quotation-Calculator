-- Create the Users table
CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    EmailAddress NVARCHAR(100) NOT NULL UNIQUE,
    Pass NVARCHAR(100) NOT NULL
);

-- Create the Save_User stored procedure
CREATE PROCEDURE Signup_User
    @FullName NVARCHAR(100),
    @EmailAddress NVARCHAR(100),
    @Pass NVARCHAR(100)
AS
BEGIN
    INSERT INTO Users (FullName, EmailAddress, Pass)
    VALUES (@FullName, @EmailAddress, @Pass);
END;

-- Create the Login_User stored procedure
CREATE PROCEDURE Login_User
    @EmailAddress NVARCHAR(100),
    @Pass NVARCHAR(100)
AS
BEGIN
    SELECT FullName, EmailAddress
    FROM Users
    WHERE EmailAddress = @EmailAddress AND Pass = @Pass;
END;

-- Create GlassDetails Table
CREATE TABLE GlassDetails (
    GId INT IDENTITY(1,1) PRIMARY KEY,
    GColor NVARCHAR(100),
    Rate FLOAT NOT NULL,
    Thickness FLOAT NOT NULL
);

--Create WindowDetails Table
CREATE TABLE WindowDetails (
    WindowsId INT IDENTITY(1,1) PRIMARY KEY,
    Type NVARCHAR(50) NOT NULL,
    Rate FLOAT NOT NULL
);

-- Create CustomerDetails Table
CREATE TABLE CustomerDetails (
    CustomerName NVARCHAR(100) NOT NULL,
    Address NVARCHAR(200),
    MobileNumber int PRIMARY KEY
);

-- Create QuotationDetails Table
CREATE TABLE QuotationDetails (
    QuotationId NVARCHAR(36) PRIMARY KEY,
    CustomerMobile int NOT NULL,
    Date DATE NOT NULL,
    Remarks NVARCHAR(500),
    TotalAmount FLOAT NOT NULL,
    FOREIGN KEY (CustomerMobile) REFERENCES CustomerDetails(MobileNumber)
);

-- Create ItemDetails Table
CREATE TABLE ItemDetails (
    ItemId INT IDENTITY(1,1) PRIMARY KEY,
	GlassId INT NOT NULL,
	QuotationId NVARCHAR(36) NOT NULL,
    Type NVARCHAR(100) NOT NULL,
    Width FLOAT NOT NULL,
    Height FLOAT NOT NULL,
    WindowsAmount FLOAT NOT NULL,
    GlassAmount FLOAT NOT NULL,
    FOREIGN KEY (GlassId) REFERENCES GlassDetails(GId),
    FOREIGN KEY (QuotationId) REFERENCES QuotationDetails(QuotationId)
);


-- Procedure to Save GlassDetails 
CREATE PROCEDURE AddGlassDetails
    @GColor NVARCHAR(50),
    @Rate FLOAT,
    @Thickness FLOAT
AS
BEGIN
    INSERT INTO GlassDetails (GColor, Rate, Thickness)
    VALUES (@GColor, @Rate, @Thickness);
END

-- Procedure to DeleteGlassDetails
CREATE PROCEDURE DeleteGlassDetails
    @GId INT
AS
BEGIN
    DELETE FROM GlassDetails
    WHERE GId = @GId;
END


--Procedure to GetAllGlassDetails
CREATE PROCEDURE GetAllGlassDetails
AS
BEGIN
    SELECT *
    FROM GlassDetails;
END

--Procedure to Add WindowDetails
CREATE PROCEDURE AddWindowDetails
    @Type NVARCHAR(50),
    @Rate FLOAT
AS
BEGIN
    INSERT INTO WindowDetails (Type, Rate)
    VALUES (@Type, @Rate);
END

--Procedure to GetAllWindowDetails
CREATE PROCEDURE GetAllWindowDetails
AS
BEGIN
    SELECT *
    FROM WindowDetails;
END


select * from WindowDetails


