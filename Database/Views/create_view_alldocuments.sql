Use ProjektBD
Go
CREATE VIEW ALL_DOCUMENTS AS 
SELECT * FROM SALEDOCUMENT 
UNION ALL
SELECT * FROM INVOICEDOCUMENT