USE [SalesManagement]
GO
/****** Object:  StoredProcedure [dbo].[insertItemSubCat]    Script Date: 7/24/2017 10:55:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[insertItemSubCat]
(
	@itmSubCategoryName varchar(50),
	@itmCategoryID int,
	@SubCatDescription varchar(MAX)
)
AS
BEGIN
	INSERT INTO ItemSubCategory(SubCategoryName, ItemCategoryID, SubCatDescription) VALUES(@itmSubCategoryName, @itmCategoryID, @SubCatDescription)
END