USE [SalesManagement]
GO
/****** Object:  StoredProcedure [dbo].[insertITem]    Script Date: 7/24/2017 10:53:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[insertITem]
(
	@itemName varchar(50),
	@itemDescription varchar(MAX),
	@itemSubCatID int
)
AS
BEGIN
	INSERT INTO Item (ItemName, ItemDescription, ItemSubCategoryID) VALUES(@itemName, @itemDescription, @itemSubCatID)
END