USE [Northwind]
GO

/****** Object:  StoredProcedure [dbo].[ValidateUser]    Script Date: 19/2/2020 17:46:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ValidateUser]  
@email varchar(100),  
@password varchar(20) 
AS 
BEGIN  
SELECT [Id],[Email],[FirstName],[LastName] ,[Roles]  
FROM [dbo].[User]  
WHERE [Email]=@email AND [Password]=@password 
END

GO


