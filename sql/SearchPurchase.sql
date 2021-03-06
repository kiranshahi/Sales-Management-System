USE [SalesManagement]
GO
/****** Object:  StoredProcedure [dbo].[SearchPurchase]    Script Date: 7/24/2017 10:58:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[SearchPurchase]
(
	@name varchar(50),
	@suppliers varchar(50),
	@date varchar(50)
)
AS
BEGIN
	SELECT Item.ItemName, ItemDetails.Color, ItemDetails.Size, Purchase.PurchasedFrom, Purchase.PurchasedQuantity, Purchase.CostPrice, Purchase.PurchasedOn FROM Purchase
	JOIN ItemDetails ON Purchase.ItemDetailsID = ItemDetails.ItemDetailsID
	JOIN Item ON Item.ItemID =ItemDetails.ItemID
	WHERE ItemName LIKE '%'+@name+'%' OR PurchasedFrom LIKE '%'+@suppliers+'%' OR PurchasedOn Like '%'+@date+'%'
END