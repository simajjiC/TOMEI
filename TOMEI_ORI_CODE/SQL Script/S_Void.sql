USE [Tomei]
GO
/****** Object:  StoredProcedure [dbo].[S_VoidCertificate]    Script Date: 11/04/2010 13:03:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[S_VoidCertificate]
(
	@CertificateNo varchar(255),
	@VoidBy varchar(50)
)
AS
BEGIN
	DECLARE @StoneID varchar(255);
	DECLARE @StrStoneID varchar(1000);
	SET @StrStoneID = '';
	DECLARE db_cursor CURSOR FOR 
	SELECT [StoneID] FROM [T_Stone]
	WHERE [CertificateNo] = @CertificateNo

	OPEN db_cursor  
	FETCH NEXT FROM db_cursor INTO @StoneID

	WHILE @@FETCH_STATUS = 0  
	BEGIN
		IF @StrStoneID = ''
		BEGIN  
			SET @StrStoneID = @StoneID;
		END
		ELSE
		BEGIN
			SET @StrStoneID = @StrStoneID + ', ' + @StoneID;
		END
		FETCH NEXT FROM db_cursor INTO @StoneID
	END  

	CLOSE db_cursor  
	DEALLOCATE db_cursor

	INSERT INTO
	[T_Action]
	(
		category,
		userid,
		[action]
	)
	VALUES
	(
		'Certificate',
		@VoidBy,
		'Void Certificate: ' + @CertificateNo + ' with Stone ID : ' + @StrStoneID	
	)

	UPDATE
		[T_Stone]
	SET
		[CertificateNo] = 0,
		[Status] = 0,
		[UpdatedBy] = @VoidBy,
		[UpdatedDate] = getdate()
	WHERE
		[CertificateNo] = @CertificateNo;

	Update  
		[T_Certificate] set [Status] = 0
	WHERE
		[CertificateNo] = @CertificateNo
END