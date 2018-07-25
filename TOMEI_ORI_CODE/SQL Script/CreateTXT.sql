USE [Tomei]
GO
/****** Object:  StoredProcedure [dbo].[S_CreateTXT]    Script Date: 11/04/2010 13:04:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[S_CreateTXT]
as
BEGIN
declare @sql varchar(8000)
select @sql = 'bcp "exec Tomei.dbo.s_GetDailyCertInfo" queryout F:\Project\Tomei_S\Export\LL' + UPPER(REPLACE(CONVERT(VARCHAR(11), GETDATE(), 106), ' ', '')) + '.txt -U sa -P p@ssword -S disonpc\sql8  -c -t "|"'
exec master..xp_cmdshell @sql
END
