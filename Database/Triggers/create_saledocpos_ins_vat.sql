USE [ProjektBD]
GO
/****** Object:  Trigger [dbo].[TRG_SALEDOCPOS_INS_VAT]    Script Date: 26.11.2019 14:32:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER TRIGGER [dbo].[TRG_SALEDOCPOS_INS_VAT]
ON [dbo].[SALEDOCUMENTPOSITION]
INSTEAD OF INSERT
AS
DECLARE @vatamount real;
BEGIN
  SET NOCOUNT ON;
  --SET IDENTITY_INSERT [dbo].[SALEDOCUMENTPOSITION] ON;
  select @vatamount = vatrateamount from VATRATE inner join inserted on VATRATE.VATRATEID = inserted.VATRATEID where VATRATE.VATRATEID = inserted.vatrateid;
  set @vatamount = @vatamount + 1;
  insert [dbo].[SALEDOCUMENTPOSITION]
	(
		[dbo].[SALEDOCUMENTPOSITION].DOCUMENTID,
		[dbo].[SALEDOCUMENTPOSITION].PRODUCTID ,
		[dbo].[SALEDOCUMENTPOSITION].VATRATEID ,
		[dbo].[SALEDOCUMENTPOSITION].UNITPRICE ,
		[dbo].[SALEDOCUMENTPOSITION].NETSUM ,
		[dbo].[SALEDOCUMENTPOSITION].GROSSSUM,  
		[dbo].[SALEDOCUMENTPOSITION].QUANTITY 
	)
		select 
		inserted.DOCUMENTID,
		inserted.PRODUCTID,
		inserted.VATRATEID,
		inserted.UNITPRICE,
		sum(inserted.UNITPRICE * inserted.QUANTITY),
		sum((inserted.UNITPRICE * inserted.QUANTITY) * @vatamount),
		inserted.QUANTITY
	from inserted
	group by inserted.SALEDOCUMENTPOSITIONID, inserted.DOCUMENTID, inserted.PRODUCTID, inserted.VATRATEID, inserted.UNITPRICE, inserted.QUANTITY;
END