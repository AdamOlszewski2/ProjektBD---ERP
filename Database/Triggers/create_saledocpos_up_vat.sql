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
DECLARE @vatamount real;
DECLARE @net money;
DECLARE @gross money;
BEGIN
  SET NOCOUNT ON;
  --SET IDENTITY_INSERT [dbo].[SALEDOCUMENTPOSITION] ON;
  select @vatamount = vatrateamount from VATRATE inner join inserted on VATRATE.VATRATEID = inserted.VATRATEID where VATRATE.VATRATEID = inserted.vatrateid;
  set @vatamount = @vatamount + 1;
  select @net = sum(inserted.UNITPRICE * inserted.QUANTITY) from inserted;
  select @gross = sum((inserted.UNITPRICE * inserted.QUANTITY) * @vatamount) from inserted;
  update [dbo].[SALEDOCUMENTPOSITION]
		set 
		[dbo].[SALEDOCUMENTPOSITION].DOCUMENTID = inserted.DOCUMENTID,
		[dbo].[SALEDOCUMENTPOSITION].PRODUCTID  = inserted.PRODUCTID,
		[dbo].[SALEDOCUMENTPOSITION].VATRATEID  = inserted.VATRATEID,
		[dbo].[SALEDOCUMENTPOSITION].UNITPRICE  = inserted.UNITPRICE,
		[dbo].[SALEDOCUMENTPOSITION].NETSUM  = @net,
		[dbo].[SALEDOCUMENTPOSITION].GROSSSUM  = @gross,
		[dbo].[SALEDOCUMENTPOSITION].QUANTITY  = inserted.QUANTITY
	from inserted;
	--group by inserted.SALEDOCUMENTPOSITIONID, inserted.DOCUMENTID, inserted.PRODUCTID, inserted.VATRATEID, inserted.UNITPRICE, inserted.QUANTITY;
	--inner join [SALEDOCUMENTPOSITION] on inserted.DOCUMENTID = [SALEDOCUMENTPOSITION].DOCUMENTID
END
GO

ALTER TABLE [dbo].[SALEDOCUMENTPOSITION] ENABLE TRIGGER [TRG_SALEDOCPOS_UP_VAT]
GO