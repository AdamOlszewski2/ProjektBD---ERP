USE [ProjektBD]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE or alter TRIGGER [TRG_SALEDOCPOS_UP_VAT]
ON [SALEDOCUMENTPOSITION]
INSTEAD OF UPDATE
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
  update [dbo].[SALEDOCUMENTPOSITION]
		set 
		[dbo].[SALEDOCUMENTPOSITION].SALEDOCUMENTPOSITIONID = inserted.SALEDOCUMENTPOSITIONID
		[dbo].[SALEDOCUMENTPOSITION].DOCUMENTID = inserted.DOCUMENTID
		[dbo].[SALEDOCUMENTPOSITION].PRODUCTID  = inserted.PRODUCTID
		[dbo].[SALEDOCUMENTPOSITION].VATRATEID  = inserted.VATRATEID
		[dbo].[SALEDOCUMENTPOSITION].UNITPRICE  = inserted.UNITPRICE
		[dbo].[SALEDOCUMENTPOSITION].NETSUM  = sum(inserted.NETSUM * inserted.QUANTITY)
		[dbo].[SALEDOCUMENTPOSITION].GROSSSUM  = sum((inserted.NETSUM * inserted.QUANTITY) * @vatamount)
		[dbo].[SALEDOCUMENTPOSITION].QUANTITY  = inserted.QUANTITY
	from inserted 
	inner join saledoument on inserted.documentid = saledoument.documentid 
	inner join saledoumentposition on saledoument.documentid = saledoumentposition.documentid
	inne join vatrate on saledoumentposition.vatrateid = vatrate.vatrateid
END
GO

ALTER TABLE [dbo].[SALEDOCUMENTPOSITION] ENABLE TRIGGER [TRG_SALEDOCPOS_UP_VAT]
GO