USE [SalesManagement]
GO
/****** Object:  StoredProcedure [dbo].[updateCategory]    Script Date: 7/24/2017 11:00:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[updateCategory]
(
	@catID int,
	@catName varchar(50),
	@catDescription varchar(MAX)
)
AS
BEGIN
	UPDATE ItemCategory SET CatName = @catName, CatDescription = @catDescription WHERE ItemCategoryID = @catID
END