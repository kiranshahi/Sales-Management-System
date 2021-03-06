USE [SalesManagement]
GO
/****** Object:  StoredProcedure [dbo].[SearchItem]    Script Date: 7/24/2017 10:57:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[SearchItem]
(
	@name varchar(50)
)
AS
BEGIN
	SELECT Item.ItemID, Item.ItemName, Item.ItemDescription , ItemSubCategory.SubCategoryName , ItemCategory.CatName FROM ITEM 
	JOIN ItemSubCategory ON Item.ItemSubCategoryID = ItemSubCategory.ItemSubCategoryID
	JOIN ItemCategory  ON ItemSubCategory.ItemCategoryID = ItemCategory.ItemCategoryID 
	WHERE ItemName LIKE '%'+@name+'%'
END