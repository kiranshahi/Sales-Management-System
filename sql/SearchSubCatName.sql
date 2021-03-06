USE [SalesManagement]
GO
/****** Object:  StoredProcedure [dbo].[SearchSubCatName]    Script Date: 7/24/2017 10:58:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[SearchSubCatName]
(
	@name varchar(50)
)
AS
BEGIN
	SELECT ItemSubCategory.ItemCategoryID, ItemSubCategory.ItemSubCategoryID, ItemSubCategory.SubCategoryName , ItemSubCategory.SubCatDescription, ItemCategory.CatName FROM ItemSubCategory
	JOIN ItemCategory ON ItemSubCategory.ItemCategoryID = ItemCategory.ItemCategoryID 
	WHERE SubCategoryName LIKE '%'+@name+'%'
END