Use ProjektBD
Go

insert into DEPARTAMENT values ('aa','aa');
insert into VATRATE values (0.23);
insert into users values ('aa','aa','aa', cast('aaa' as VARBINARY(MAX)), 1);
insert into contractor values ('adam1', 'poznan', 'aa@aa.pl', 1110523716, 1234);
insert into product values (1234,'aaa'	,1	,2.54	,1);
insert into saledocument values(1,1,1,GETDATE(),GETDATE(),GETDATE(), 100,150);

INSERT INTO [dbo].[SALEDOCUMENTPOSITION]
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

ALTER TABLE DBO.CONTRACTOR
ADD CONSTRAINT UQ_NIP UNIQUE (NIP); 