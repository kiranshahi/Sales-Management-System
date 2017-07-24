USE [SalesManagement]
GO
/****** Object:  StoredProcedure [dbo].[SearchCatName]    Script Date: 7/24/2017 10:57:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[SearchCatName]
(
	@name varchar(50)
)
AS
BEGIN
	SELECT * FROM ItemCategory WHERE CatName LIKE '%'+@name+'%'
END