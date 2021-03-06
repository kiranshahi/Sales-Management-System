USE [SalesManagement]
GO
/****** Object:  StoredProcedure [dbo].[selectItemSubCatByID]    Script Date: 7/24/2017 11:00:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[selectItemSubCatByID]
(
	@itemSubCatID int
)
AS
BEGIN
SELECT ItemSubCategory.ItemCategoryID, ItemSubCategory.ItemSubCategoryID, ItemSubCategory.SubCategoryName , ItemSubCategory.SubCatDescription, ItemCategory.CatName FROM ItemSubCategory
JOIN ItemCategory ON ItemSubCategory.ItemCategoryID = ItemCategory.ItemCategoryID
WHERE ItemSubCategoryID = @itemSubCatID
END