USE [SalesManagement]
GO
/****** Object:  StoredProcedure [dbo].[updateSubCat]    Script Date: 7/24/2017 12:46:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[updateSubCat]
(
	@subCatId int,
	@subCatName varchar(50),
	@itemCatId int,
	@subCatDescription varchar(MAX)
)
AS
BEGIN
	UPDATE ItemSubCategory SET SubCategoryName = @subCatName, ItemCategoryID = @itemCatId, SubCatDescription =@subCatDescription WHERE ItemSubCategoryID = @subCatId
END