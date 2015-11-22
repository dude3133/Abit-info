USE [AbitInfoDb]
GO

SET IDENTITY_INSERT [Universities] ON
DECLARE @cnt INT = 30;

WHILE @cnt < 57
BEGIN

 INSERT INTO [Universities]([Id], [Name]) 
 select @cnt-27,[Name] from [Universities] where [Id]=@cnt  
DELETE FROM [Universities] WHERE [Id]=@cnt

   SET @cnt = @cnt + 1;
END;
go
SET IDENTITY_INSERT [Universities] Off