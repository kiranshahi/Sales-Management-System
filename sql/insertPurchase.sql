USE [SalesManagement]
GO
/****** Object:  StoredProcedure [dbo].[insertPurchase]    Script Date: 7/24/2017 10:55:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[insertPurchase]
(
	@itemDetailsID int,
	@purchasedFrom varchar(50),
	@purchasedQuantity int,
	@costPrice decimal(18, 2),
	@purchasedOn date
)
AS
BEGIN
	INSERT INTO Purchase (ItemDetailsID, PurchasedFrom, PurchasedQuantity, CostPrice, PurchasedOn) 
	VALUES(@itemDetailsID, @purchasedFrom, @purchasedQuantity, @costPrice, @purchasedOn)
END