USE [Northwind]
GO

/****** Object:  StoredProcedure [dbo].[SupplierPagedList]    Script Date: 19/2/2020 17:46:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[SupplierPagedList]  
@page int,  
@rows int 
AS 
BEGIN  

 
 SELECT [Id], [CompanyName], [ContactName], [ContactTitle], [City], [Country], [Phone], [Fax],
 COUNT(*) OVER() TotalRecords
 FROM [Supplier]
 order by [Id]
 OFFSET @page - 1 ROWS                  
 FETCH NEXT @rows ROWS ONLY
 
END
GO


