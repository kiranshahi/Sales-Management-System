USE [SalesManagement]
GO
/****** Object:  StoredProcedure [dbo].[deleteSubCat]    Script Date: 7/24/2017 10:52:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[deleteSubCat]
(
	@subCatId int
)
AS
BEGIN
	UPDATE ItemSubCategory SET IsDeleted = 1 WHERE ItemSubCategoryID = @subCatId
END