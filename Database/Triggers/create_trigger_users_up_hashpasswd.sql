USE [ProjektBD]
GO

/****** Object:  Trigger [dbo].[TRG_USERS_HASHPASSWD]    Script Date: 25.11.2019 22:39:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE or alter TRIGGER [dbo].[TRG_USERS_UP_HASHPASSWD]
ON [dbo].[USERS]
INSTEAD OF UPDATE
AS
BEGIN
  SET NOCOUNT ON;
  update [dbo].[USERS] 
  set 
           [LOGIN] = inserted.[LOGIN]
           ,[FIRSTNAME] = inserted.[FIRSTNAME]
           ,[LASTNAME] = inserted.[LASTNAME]
           ,[PASSWORD] = HASHBYTES('SHA2_256',inserted.[PASSWORD])
           ,[DEPARTAMENTID] = inserted.[DEPARTAMENTID]
		   from inserted inner join users on inserted.USERID = users.userid
END
GO

ALTER TABLE [dbo].[USERS] ENABLE TRIGGER [TRG_USERS_UP_HASHPASSWD]
GO


