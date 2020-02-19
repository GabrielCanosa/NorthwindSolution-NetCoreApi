USE [Northwind]
GO

/****** Object:  StoredProcedure [dbo].[CustomerPagedList]    Script Date: 19/2/2020 17:46:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CustomerPagedList]  
@page int,  
@rows int 
AS 
BEGIN  

 
 SELECT [Id]  ,[FirstName] ,[LastName] ,[City],[Country],[Phone],
 COUNT(*) OVER() TotalRecords
 FROM [Customer]
 order by [Id]
 OFFSET (@page - 1) * @rows ROWS                  
 FETCH NEXT @rows ROWS ONLY
 
END
GO


