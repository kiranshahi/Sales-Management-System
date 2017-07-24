USE [SalesManagement]
GO
/****** Object:  StoredProcedure [dbo].[updatePassword]    Script Date: 7/24/2017 11:01:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[updatePassword]
(
	@password varchar(50),
	@email varchar(50)
)
AS
BEGIN
	UPDATE Users SET Password = @password WHERE Email = @email
END