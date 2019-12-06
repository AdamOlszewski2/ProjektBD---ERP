Use ProjektBD
Go

insert into DEPARTAMENT values ('aa','aa');
insert into VATRATE values (0.23);
insert into users values ('aa','aa','aa', cast('aaa' as VARBINARY(MAX)), 1);
insert into contractor values ('adam1', 'poznan', 'aa@aa.pl', 1110523716, 1234);
insert into product values (1234,'aaa'	,1	,2.54	,1);
insert into saledocument values(NEXT VALUE FOR SALEDOCNUBMERSEQ,1,GETDATE(),GETDATE(),GETDATE(), 100,150);
insert into invoicedocument values(1,1,1,GETDATE(),GETDATE(),GETDATE(), 10,15);

INSERT INTO [dbo].[SALEDOCUMENT]
           ([DOCUMENTNUMBER]
           ,[CONTRACTORID]
           ,[USERID]
           ,[MODDATE]
           ,[CREATEDATE]
           ,[INVOICEDATE]
           ,[GROSSSUM]
           ,[NETSUM])
     values(NEXT VALUE FOR SALEDOCNUBMERSEQ,1,1,GETDATE(),GETDATE(),GETDATE(), 100,150);

INSERT INTO [dbo].INVOICEDOCUMENTPOSITION
           ([DOCUMENTID]
           ,[PRODUCTID]
           ,[VATRATEID]
           ,[UNITPRICE]
           ,[NETSUM]
           ,[GROSSSUM]
           ,[QUANTITY])
     VALUES
           (1
           ,100000
           ,1
           ,2.67
           ,5
           ,5
           ,6);

update [SALEDOCUMENTPOSITION] set quantity = 1 where [SALEDOCUMENTPOSITIONID] = 2;

delete from [SALEDOCUMENTPOSITION];

<<<<<<< HEAD
ALTER TABLE DBO.CONTRACTOR
ADD CONSTRAINT UQ_NIP UNIQUE (NIP); 
=======
EXEC ALL_USERS_DOCUMENTS @FirstName = 'aa', @LastName = 'aa', @DocType = 4;

alter table INVOICEDOCUMENTPOSITION add constraint FK__INVOICEDO__DOCUM__6C190EBB FOREIGN KEY(DocumentID) references INVOICEDOCUMENT(DocumentID);
>>>>>>> c08833199a94e9c4a315234c35ec70b06c3feea4
