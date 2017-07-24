USE [SalesManagement]
GO
/****** Object:  StoredProcedure [dbo].[updateQuantity]    Script Date: 7/24/2017 12:46:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[updateQuantity]
(
	@itemDetailsId int,
	@quantity int
)
AS
BEGIN
	UPDATE ItemDetails SET Quantity = dbo.addQuantityToStcok(@itemDetailsId, @quantity) WHERE ItemDetailsID = @itemDetailsId
END