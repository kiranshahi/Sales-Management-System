USE [SalesManagement]
GO
/****** Object:  StoredProcedure [dbo].[selectItemById]    Script Date: 7/24/2017 10:59:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[selectItemById]
(
	@itemId int
)
AS
BEGIN
	SELECT Item.ItemID, Item.ItemName, Item.ItemDescription, Item.ItemSubCategoryID, ItemSubCategory.SubCategoryName, ItemCategory.CatName FROM ITEM 
		JOIN ItemSubCategory ON Item.ItemSubCategoryID = ItemSubCategory.ItemSubCategoryID
		JOIN ItemCategory  ON ItemSubCategory.ItemCategoryID = ItemCategory.ItemCategoryID WHERE Item.ItemID = @itemId
END