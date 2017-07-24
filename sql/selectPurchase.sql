USE [SalesManagement]
GO
/****** Object:  StoredProcedure [dbo].[selectPurchase]    Script Date: 7/24/2017 11:00:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[selectPurchase]
AS
BEGIN
	SELECT Item.ItemName, ItemDetails.Color, ItemDetails.Size, Purchase.PurchasedFrom, Purchase.PurchasedQuantity, Purchase.CostPrice, Purchase.PurchasedOn FROM Purchase
	JOIN ItemDetails ON Purchase.ItemDetailsID = ItemDetails.ItemDetailsID
	JOIN Item ON Item.ItemID =ItemDetails.ItemID
END