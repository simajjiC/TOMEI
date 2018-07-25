USE [TOMEI]
GO
/****** Object:  StoredProcedure [dbo].[s_GetDailyCertInfo]    Script Date: 11/04/2010 16:40:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[s_GetDailyCertInfo]

as
SELECT 
T_Certificate.ProductNo + '|' +
T_ProductSeries.SeriesDescription + '|' +
UPPER(REPLACE(REPLACE(REPLACE(CONVERT(VARCHAR(19), GETDATE(), 120),' ',''),'-',''),':','')) + '|' +
cast(Case when (T_Certificate.status = '1') then 'N' else 'C' end as varchar(10)) + '|' +
cast(T_Certificate.CertificateNo as varchar(50)) + '|' +
T_STONE.StoneID + '|' +
Cast(T_Stone.Weight as Varchar(10)) + '|' +
T_Clarity.value + '|' +
T_Colour.value + '|' +
Cast(T_Stone.Depth as Varchar(10)) + '|' +
Cast(T_Stone.Size as Varchar(10)) + '|' +
T_Fluorescence.value + '|' +
(Cast(T_Stone.Measurement_1 as Varchar(10)) + '-' + cast(T_Stone.Measurement_2 as varchar(10)) +'x'+ Cast(T_Stone.Measurement_3 as varchar(10))) + '|' +
T_Girdle.value + '|' +
T_Polish.value + '|' +
T_Symmetry.value                        
FROM         T_Certificate INNER JOIN
                      T_Stone ON T_Certificate.CertificateNo = T_Stone.CertificateNo INNER JOIN
                      T_ProductSeries ON T_Certificate.ProductSeries = T_ProductSeries.id INNER JOIN
                      T_Clarity ON T_Stone.Clarity = T_Clarity.id INNER JOIN
                      T_Colour ON T_Stone.Colour = T_Colour.id INNER JOIN
                      T_Fluorescence ON T_Stone.Fluorescence = T_Fluorescence.id INNER JOIN
                      T_Girdle ON T_Stone.Girdle = T_Girdle.id INNER JOIN
                      T_Polish ON T_Stone.Polish = T_Polish.id INNER JOIN
                      T_Symmetry ON T_Stone.Symmetry = T_Symmetry.id
                      where day(T_Certificate.CreatedDate) = day(GETDATE()) and 
                      month(T_Certificate.CreatedDate) = month(GETDATE()) and
                      year(T_Certificate.CreatedDate) = year(GETDATE())
				order by T_Certificate.CreatedDate desc