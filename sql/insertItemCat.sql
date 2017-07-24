USE [SalesManagement]
GO
/****** Object:  StoredProcedure [dbo].[insertItemCat]    Script Date: 7/24/2017 10:54:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[insertItemCat]
(
	@catName varchar(50),
	@catDescription varchar(MAX)
)
AS
BEGIN
	INSERT INTO ItemCategory (CatName, CatDescription) VALUES(@catName, @catDescription)
END