USE [SalesManagement]
GO
/****** Object:  StoredProcedure [dbo].[selectItemDetailsById]    Script Date: 7/24/2017 10:59:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[selectItemDetailsById]
(
	@itemDetailsId int
)
AS
BEGIN
	SELECT ItemDetails.ItemDetailsID, ItemDetails.Image, ItemDetails.Quantity, ItemDetails.Color, ItemDetails.Size, ItemDetails.ItmWeight, ItemDetails.SellingPrice, Item.ItemName, Item.ItemDescription, ItemSubCategory.SubCategoryName, ItemCategory.CatName FROM ItemDetails
	JOIN Item ON ItemDetails.ItemID = Item.ItemID
	JOIN ItemSubCategory ON Item.ItemSubCategoryID = ItemSubCategory.ItemSubCategoryID
	JOIN ItemCategory  ON ItemSubCategory.ItemCategoryID = ItemCategory.ItemCategoryID WHERE ItemDetailsID = @itemDetailsId
END