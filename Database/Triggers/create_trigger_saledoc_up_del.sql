USE [ProjektBD]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE or alter TRIGGER [TRG_SALEDOC_UP_DEL_VAT]
ON [SALEDOCUMENT]
INSTEAD OF UPDATE, DELETE
AS
/*DECLARE @netsum money;
DECLARE	@grosssum money;
	select @netsum = sum(saledoumentposition.NETSUM * saledoumentposition.QUANTITY) from saledoumentposition where saledoumentposition.documentid = inserted.documentid;
	select @grosssum = sum(saledoumentposition.NETSUM - (saledoumentposition.NETSUM * vatrate.vatrateamount) * saledoumentposition.QUANTITY) 
	from saledoumentposition inner join vatrate on saledoumentposition.vatrateid = vatrate.vatrateid 
	where saledoumentposition.documentid = inserted.documentid;*/
BEGIN
  SET NOCOUNT ON;
  RAISERROR(2,-1,-1,'Can not modify or delete documents');
  /*update [dbo].[SALEDOCUMENT]
		set 
		[dbo].[SALEDOCUMENT].[DOCUMENTID] = inserted.DOCUMENTID,
		[dbo].[SALEDOCUMENT].[DOCUMENTNUMBER] = inserted.DOCUMENTNUMBER,
		[dbo].[SALEDOCUMENT].[CONTRACTORID] = inserted.CONTRACTORID,
		[dbo].[SALEDOCUMENT].[USERID]  = inserted.USERID,
		[dbo].[SALEDOCUMENT].[MODDATE]  = inserted.MODDATE,
		[dbo].[SALEDOCUMENT].[CREATEDATE]  = inserted.CREATEDATE,
		[dbo].[SALEDOCUMENT].[INVOICEDATE] = inserted.INVOICEDATE,
		[dbo].[SALEDOCUMENT].[GROSSSUM]  = @grosssum,
		[dbo].[SALEDOCUMENT].[NETSUM]  = @netsum
	from inserted 
	inner join saledoument on inserted.documentid = saledoument.documentid 
	inner join saledoumentposition on saledoument.documentid = saledoumentposition.documentid*/
END
GO

ALTER TABLE [dbo].[SALEDOCUMENT] ENABLE TRIGGER [TRG_SALEDOC_UP_DEL_VAT]
GO