USE [SalesManagement]
GO
/****** Object:  StoredProcedure [dbo].[selectItemCategory]    Script Date: 7/24/2017 10:59:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[selectItemCategory] 
AS
BEGIN
SELECT * FROM ItemCategory where IsDeleted = '0'
END