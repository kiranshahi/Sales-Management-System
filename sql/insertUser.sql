USE [SalesManagement]
GO
/****** Object:  StoredProcedure [dbo].[insertUser]    Script Date: 7/24/2017 10:56:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[insertUser]
(
	@firstName varchar(50),
	@lastName varchar(50),
	@gender varchar(50),
	@country varchar(50),
	@city varchar(50),
	@address varchar(50),
	@contactNo varchar(50),
	@email varchar(50),
	@password varchar(50)
)
AS
BEGIN
	INSERT INTO Users (FirstName, LastName, Gender, Country, City, Address, ContactNO, Email, Password) 
	VALUES(@firstName, @lastName, @gender, @country, @city, @address, @contactNo, @email, @password)
END