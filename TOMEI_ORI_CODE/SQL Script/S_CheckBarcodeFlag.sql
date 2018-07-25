USE [Tomei]
GO
/****** Object:  StoredProcedure [dbo].[S_CheckBarcodeFlag]    Script Date: 06/28/2010 17:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[S_CheckBarcodeFlag]
(
	@id int
)
AS
BEGIN
	SELECT  
		[BarcodeFlag]
	FROM
		[T_ProductSeries] 	
	WHERE
		[id] = @id
END