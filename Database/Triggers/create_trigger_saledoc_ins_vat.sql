USE [ProjektBD]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE or alter TRIGGER [dbo].[TRG_SALEDOC_INS_VAT]
ON [dbo].[SALEDOCUMENT]
INSTEAD OF INSERT
AS
	DECLARE @netsum money;
	DECLARE	@grosssum money;
	select @netsum =  sum(saledoumentposition.NETSUM * saledoumentposition.QUANTITY) from saledoumentposition where saledoumentposition.documentid = inserted.documentid
	select @grosssum =  sum(saledoumentposition.NETSUM - (saledoumentposition.NETSUM * vatrate.vatrateamount) * saledoumentposition.QUANTITY) 
	from saledoumentposition inner join vatrate on saledoumentposition.vatrateid = vatrate.vatrateid 
	where saledoumentposition.documentid = inserted.documentid
BEGIN
  SET NOCOUNT ON;
  /*update [dbo].[SALEDOCUMENT]
		set 
		[dbo].[SALEDOCUMENT].[DOCUMENTID] = inserted.DOCUMENTID
		[dbo].[SALEDOCUMENT].[DOCUMENTNUMBER] = inserted.DOCUMENTNUMBER
		[dbo].[SALEDOCUMENT].[CONTRACTORID] = inserted.CONTRACTORID
		[dbo].[SALEDOCUMENT].[USERID]  = inserted.USERID
		[dbo].[SALEDOCUMENT].[MODDATE]  = inserted.MODDATE
		[dbo].[SALEDOCUMENT].[CREATEDATE]  = inserted.CREATEDATE
		[dbo].[SALEDOCUMENT].[INVOICEDATE] = inserted.INVOICEDATE
		[dbo].[SALEDOCUMENT].[GROSSSUM]  = @grosssum
		[dbo].[SALEDOCUMENT].[NETSUM]  = @netsum
	from inserted 
	inner join saledoument on inserted.documentid = saledoument.documentid 
	inner join saledoumentposition on saledoument.documentid = saledoumentposition.documentid*/
	insert into [dbo].[SALEDOCUMENT] (
	[dbo].[SALEDOCUMENT].[DOCUMENTID],
	[dbo].[SALEDOCUMENT].[DOCUMENTNUMBER],
	[dbo].[SALEDOCUMENT].[CONTRACTORID],
	[dbo].[SALEDOCUMENT].[USERID],
	[dbo].[SALEDOCUMENT].[MODDATE],
	[dbo].[SALEDOCUMENT].[CREATEDATE],
	[dbo].[SALEDOCUMENT].[INVOICEDATE],
	[dbo].[SALEDOCUMENT].[GROSSSUM],
	[dbo].[SALEDOCUMENT].[NETSUM]
	)
	select 
	inserted.[DOCUMENTID],
	inserted.[DOCUMENTNUMBER],
	inserted.[CONTRACTORID],
	inserted.[USERID],
	inserted.[MODDATE],
	inserted.[CREATEDATE],
	inserted.[INVOICEDATE],
	@netsum,
	@grosssum
	from inserted inner join saledoumentposition 
	on inserted.documentid = saledoumentposition.documentid
END
GO

ALTER TABLE [dbo].[SALEDOCUMENT] ENABLE TRIGGER [TRG_SALEDOC_INS_VAT]
GO