USE [SalesManagement]
GO
/****** Object:  StoredProcedure [dbo].[insertItemDetails]    Script Date: 7/24/2017 10:54:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[insertItemDetails]
(
	@itemID int,
	@itemColor varchar(50),
	@itemSize varchar(50),
	@itemWeight varchar(50),
	@itemSellingPrice decimal(18,2),
	@imageFile varchar(50)
)
AS
BEGIN
	INSERT INTO ItemDetails (ItemID, Color, Size, ItmWeight, SellingPrice, Image) VALUES(@itemID, @itemColor, @itemSize, @itemWeight, @itemSellingPrice, @imageFile)
END