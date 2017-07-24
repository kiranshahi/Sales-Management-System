USE [SalesManagement]
GO
/****** Object:  StoredProcedure [dbo].[insertPayment]    Script Date: 7/24/2017 10:55:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[insertPayment]
(
	@userId int,
	@paymentType varchar(50),
	@paymentToken varchar(50),
	@discountedAmount decimal(18, 2),
	@taxAmount decimal(18, 2),
	@totalAmount decimal(18, 2)
)
AS
BEGIN
	INSERT INTO Payment (UserID, PayemntType, PaymentToken, DiscountedAmount, TaxAmount, TotalAmount) VALUES(@userId, @paymentType, @paymentToken, @discountedAmount, @taxAmount, @totalAmount)
END