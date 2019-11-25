USE [ProjektBD]
GO

/****** Object:  Trigger [dbo].[TRG_USERS_HASHPASSWD]    Script Date: 25.11.2019 22:39:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[TRG_USERS_INS_HASHPASSWD]
ON [dbo].[USERS]
INSTEAD OF INSERT
AS
BEGIN
  SET NOCOUNT ON;
  INSERT [dbo].[USERS]
           ([LOGIN]
           ,[FIRSTNAME]
           ,[LASTNAME]
           ,[PASSWORD]
           ,[DEPARTAMENTID])
		SELECT
		   [LOGIN]
		  ,[FIRSTNAME]
		  ,[LASTNAME]
		  ,HASHBYTES('SHA2_256',[PASSWORD])
		  ,[DEPARTAMENTID]
		FROM inserted;
END
GO

ALTER TABLE [dbo].[USERS] ENABLE TRIGGER [TRG_USERS_HASHPASSWD]
GO

