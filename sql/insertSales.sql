USE [SalesManagement]
GO
/****** Object:  StoredProcedure [dbo].[insertSales]    Script Date: 7/24/2017 10:56:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[insertSales]
(
	@itemDetailsID int,
	@salesQuantity int,
	@amount decimal(18,2),
	@paymentID int
)
AS
BEGIN
	INSERT INTO Sales (ItemDetailsID, SalesQuantity, Amount, PaymentID) 
	VALUES(@itemDetailsID, @salesQuantity, @amount, @paymentID)
END