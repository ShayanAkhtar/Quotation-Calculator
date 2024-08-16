-- Create the Users table
CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    EmailAddress NVARCHAR(100) NOT NULL UNIQUE,
    Pass NVARCHAR(100) NOT NULL,
	Role NVARCHAR(30) NOT NULL
);

--Add Admin 
INSERT INTO Users (FullName, EmailAddress, Pass, Role)
VALUES ('Admin', 'admin@gmail.com', 'admin', 'Admin');

-- Create the Save_User stored procedure
CREATE PROCEDURE Signup_User
    @FullName NVARCHAR(100),
    @EmailAddress NVARCHAR(100),
    @Pass NVARCHAR(100),
	@Role NVARCHAR(30)
AS
BEGIN
    INSERT INTO Users (FullName, EmailAddress, Pass,Role)
    VALUES (@FullName, @EmailAddress, @Pass,@Role);
END;

-- Create the Login_User stored procedure
CREATE PROCEDURE Login_User
    @EmailAddress NVARCHAR(100),
    @Pass NVARCHAR(100)
AS
BEGIN
    SELECT FullName, EmailAddress,Role
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
    MobileNumber BIGINT PRIMARY KEY
);

-- Create QuotationDetails Table
CREATE TABLE QuotationDetails (
    QuotationId NVARCHAR(8) PRIMARY KEY,
    CustomerMobile bigint NOT NULL,
    Date DATE NOT NULL,
    Remarks NVARCHAR(500),
    FOREIGN KEY (CustomerMobile) REFERENCES CustomerDetails(MobileNumber)
);

-- Create ItemDetails Table
CREATE TABLE ItemDetails (
    ItemId INT IDENTITY(1,1) PRIMARY KEY,
	GId INT NOT NULL,
	QuotationId NVARCHAR(8) NOT NULL,
	WindowsId INT NOT NULL,
    Width FLOAT NOT NULL,
    Height FLOAT NOT NULL,
    WindowsRate FLOAT NOT NULL,
    GlassRate FLOAT NOT NULL,
	FOREIGN KEY (WindowsId) REFERENCES WindowDetails(WindowsId),
    FOREIGN KEY (GId) REFERENCES GlassDetails(GId),
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

-- Procedure to DeleteWindowDetails
CREATE PROCEDURE DeleteWindowDetails
    @WindowsId INT
AS
BEGIN
    DELETE FROM WindowDetails
    WHERE WindowsId = @WindowsId;
END

-- Procedure to AddCutomerDetails
CREATE PROCEDURE AddCustomerDetails
    @CustomerName NVARCHAR(100),
    @Address NVARCHAR(200),
    @MobileNumber BIGINT
AS
BEGIN
    INSERT INTO CustomerDetails (CustomerName, Address, MobileNumber)
    VALUES (@CustomerName, @Address, @MobileNumber);
END

-- Procedure to  GetAllCustomerDetails
CREATE PROCEDURE GetAllCustomerDetails
AS
BEGIN
    SELECT CustomerName, Address, MobileNumber
    FROM CustomerDetails;
END

-- Procedure to  AddQuotationDetails
CREATE PROCEDURE AddQuotationDetails
    @QuotationId NVARCHAR(8),
    @CustomerMobile BIGINT,
    @Date DATE,
    @Remarks NVARCHAR(500)
AS
BEGIN
    INSERT INTO QuotationDetails (QuotationId, CustomerMobile, Date, Remarks)
    VALUES (@QuotationId, @CustomerMobile, @Date, @Remarks);
END

-- Procedure to  AddItemDetails
CREATE PROCEDURE AddItemDetails
    @GId INT,
    @QuotationId NVARCHAR(8),
    @WindowsId INT,
    @Width FLOAT,
    @Height FLOAT,
    @WindowsRate FLOAT,
    @GlassRate FLOAT
AS
BEGIN
    INSERT INTO ItemDetails (GId, QuotationId, WindowsId, Width, Height, WindowsRate, GlassRate)
    VALUES (@GId, @QuotationId, @WindowsId, @Width, @Height, @WindowsRate, @GlassRate);
END

-- Procedure to  GetAllQuotationDetails
CREATE PROCEDURE GetAllQuotations
AS
BEGIN
    SELECT QuotationId, CustomerMobile, Date, Remarks
    FROM QuotationDetails;
END


CREATE PROCEDURE GetQuotationById
    @QuotationId NVARCHAR(8)
AS
BEGIN
    SELECT QuotationId, CustomerMobile, Date, Remarks
    FROM QuotationDetails
    WHERE QuotationId = @QuotationId;
END

----------------------------Companies-------------------------------
--Create Companies table
CREATE TABLE Companies (
    CompanyId INT IDENTITY(1,1) PRIMARY KEY,
    CompanyName NVARCHAR(100) NOT NULL
);

--Insert SkypenDetails & TurkProfilDetails in Companies
INSERT INTO Companies (CompanyName)
VALUES ('SkyPenDetails'),('TurkProfilDetails');

--Create GetAllCompanies Procedure
CREATE PROCEDURE GetAllCompanies
AS
BEGIN
    SELECT * FROM Companies;
END;


----------------------------TurkProfil-------------------------------

--Create Turkprofil Table
CREATE TABLE TurkProfilDetails (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ProfileCode FLOAT,
    ProfileFunction NVARCHAR(100),
    WhiteWithoutGasket FLOAT,
    WhiteWithGasket FLOAT,
    BlackSolidColor FLOAT
);

--Create AddTurkProfilDetails Proedure
CREATE PROCEDURE AddTurkProfilDetails
    @ProfileCode FLOAT,
    @ProfileFunction NVARCHAR(100),
    @WhiteWithoutGasket FLOAT,
    @WhiteWithGasket FLOAT,
    @BlackSolidColor FLOAT
AS
BEGIN
    INSERT INTO TurkProfilDetails (ProfileCode, ProfileFunction, WhiteWithoutGasket, WhiteWithGasket, BlackSolidColor)
    VALUES (@ProfileCode, @ProfileFunction, @WhiteWithoutGasket, @WhiteWithGasket, @BlackSolidColor);
END

--Create DeleteTurkProfilDetails Proedure
CREATE PROCEDURE DeleteTurkProfilDetails
    @Id INT
AS
BEGIN
    DELETE FROM TurkProfilDetails
    WHERE Id = @Id;
END

--Create GetAllTurkProfil Procedure
CREATE PROCEDURE GetAllTurkProfilDetails
AS
BEGIN
    SELECT * FROM TurkProfilDetails;
END
-------------------------------------------------


----------------------------SkyPen-------------------------------

--Create SkyPen Table
CREATE TABLE SkyPen (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ProfileCode FLOAT,
    ProfileFunction NVARCHAR(100),
    WhiteWithoutGasket FLOAT,
    WhiteWithCoexGasket FLOAT,
	WhiteWithTPVGasket FLOAT,
    TBAndTDOWithTPVGasket FLOAT
);

--Create AddSkyPenDetails Procedure
CREATE PROCEDURE AddSkyPenDetails
    @ProfileCode FLOAT,
    @ProfileFunction NVARCHAR(100),
    @WhiteWithoutGasket FLOAT,
    @WhiteWithCoexGasket FLOAT,
    @WhiteWithTPVGasket FLOAT,
    @TBAndTDOWithTPVGasket FLOAT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM SkyPen WHERE ProfileCode = @ProfileCode)
    BEGIN
        -- Record already exists, no need to proceed
        RETURN;
    END

    INSERT INTO SkyPen (ProfileCode, ProfileFunction, WhiteWithoutGasket, WhiteWithCoexGasket, WhiteWithTPVGasket, TBAndTDOWithTPVGasket)
    VALUES (@ProfileCode, @ProfileFunction, @WhiteWithoutGasket, @WhiteWithCoexGasket, @WhiteWithTPVGasket, @TBAndTDOWithTPVGasket);
END

--Create DeleteSkyPenDetails Procedure
CREATE PROCEDURE DeleteSkyPenDetails
    @Id INT
AS
BEGIN
    DELETE FROM SkyPen
    WHERE Id = @Id;
END

--Create GetAllSkyPenDetails Procedure
CREATE PROCEDURE GetAllSkyPenDetails
AS
BEGIN
    SELECT * FROM SkyPen;
END
-------------------------------------------------



select * from QuotationDetails
select * from CustomerDetails
select * from ItemDetails
select * from WindowDetails
select * from GlassDetails

