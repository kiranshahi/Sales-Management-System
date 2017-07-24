USE [SalesManagement]
GO
/****** Object:  UserDefinedFunction [dbo].[addQuantityToStcok]    Script Date: 7/24/2017 10:51:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[addQuantityToStcok]
(
	@itemdetailsId int,
	@quantity int
)
RETURNS INT
AS
BEGIN
	DECLARE @stockQuantity int
	SET @stockQuantity = (SELECT Quantity FROM ItemDetails WHERE ItemDetailsID = @itemdetailsId)
	SET @stockQuantity = @quantity + @stockQuantity
	RETURN @stockQuantity
END