USE [SalesManagement]
GO
/****** Object:  StoredProcedure [dbo].[selectItemSubCat]    Script Date: 7/24/2017 10:59:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[selectItemSubCat]
AS
BEGIN
SELECT ItemSubCategory.ItemCategoryID, ItemSubCategory.ItemSubCategoryID, ItemSubCategory.SubCategoryName , ItemSubCategory.SubCatDescription, ItemCategory.CatName FROM ItemSubCategory
JOIN ItemCategory ON ItemSubCategory.ItemCategoryID = ItemCategory.ItemCategoryID WHERE ItemSubCategory.IsDeleted = 0
END