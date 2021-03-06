USE [SalesManagement]
GO
/****** Object:  StoredProcedure [dbo].[selectItem]    Script Date: 7/24/2017 10:58:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[selectItem]
AS
BEGIN
	SELECT Item.ItemID, Item.ItemName, Item.ItemDescription , ItemSubCategory.SubCategoryName , ItemCategory.CatName FROM ITEM 
	JOIN ItemSubCategory ON Item.ItemSubCategoryID = ItemSubCategory.ItemSubCategoryID
	JOIN ItemCategory  ON ItemSubCategory.ItemCategoryID = ItemCategory.ItemCategoryID 
	WHERE Item.IsDeleted = 'False'
END