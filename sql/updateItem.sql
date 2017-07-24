USE [SalesManagement]
GO
/****** Object:  StoredProcedure [dbo].[updateItem]    Script Date: 7/24/2017 11:00:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[updateItem]
(
	@itemID int,
	@itemName varchar(50),
	@itemDescription varchar(MAX),
	@itemSubCategoryID int
)
AS
BEGIN
	UPDATE Item SET ItemName = @itemName, ItemDescription = @itemDescription, ItemSubCategoryID =@itemSubCategoryID WHERE ItemID = @itemID
END