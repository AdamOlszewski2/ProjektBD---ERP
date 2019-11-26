USE [ProjektBD]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE or alter TRIGGER [TRG_SALEDOCPOS_INS_VAT]
ON [SALEDOCUMENTPOSITION]
INSTEAD OF INSERT
AS
/*DECLARE @netsum money;
DECLARE	@grosssum money;
	select @netsum = sum(saledoumentposition.NETSUM * saledoumentposition.QUANTITY) from saledoumentposition where saledoumentposition.documentid = inserted.documentid;
	select @grosssum = sum(saledoumentposition.NETSUM - (saledoumentposition.NETSUM * vatrate.vatrateamount) * saledoumentposition.QUANTITY) 
	from saledoumentposition inner join vatrate on saledoumentposition.vatrateid = vatrate.vatrateid 
	where saledoumentposition.documentid = inserted.documentid;*/
DECLARE @vatamount int;
select @vatamount = 1 + (vatrateamount from vatrate where vatrateid = inserted.vatrate)
BEGIN
  SET NOCOUNT ON;
  insert into [dbo].[SALEDOCUMENTPOSITION]
	(	  
		[dbo].[SALEDOCUMENTPOSITION].SALEDOCUME,
		[dbo].[SALEDOCUMENTPOSITION].DOCUMENTID,
		[dbo].[SALEDOCUMENTPOSITION].PRODUCTID ,
		[dbo].[SALEDOCUMENTPOSITION].VATRATEID ,
		[dbo].[SALEDOCUMENTPOSITION].UNITPRICE ,
		[dbo].[SALEDOCUMENTPOSITION].NETSUM ,
		[dbo].[SALEDOCUMENTPOSITION].GROSSSUM,  
		[dbo].[SALEDOCUMENTPOSITION].QUANTITY , 
	)
		select 
		inserted.SALEDOCUMENTPOSITIONID,
		inserted.DOCUMENTID,
		inserted.PRODUCTID,
		inserted.VATRATEID,
		inserted.UNITPRICE,
		sum(inserted.NETSUM * inserted.QUANTITY),
		sum((inserted.NETSUM * inserted.QUANTITY) * @vatamount),
		inserted.QUANTITY
	from inserted 
	inner join saledoument on inserted.documentid = saledoument.documentid 
	inner join saledoumentposition on saledoument.documentid = saledoumentposition.documentid
	inne join vatrate on saledoumentposition.vatrateid = vatrate.vatrateid
	
	/* 	insert into [dbo].[SALEDOCUMENT] (
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
	on inserted.documentid = saledoumentposition.documentid */
END
GO

ALTER TABLE [dbo].[SALEDOCUMENTPOSITION] ENABLE TRIGGER [TRG_SALEDOCPOS_INS_VAT]
GO