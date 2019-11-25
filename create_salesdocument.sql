USE [ProjektBD]
GO

/****** Object:  Table [dbo].[SALESDOCUMENTS]    Script Date: 18.11.2019 17:25:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SALESDOCUMENTS](
	[DOCID] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[DOCNUMBER] [nvarchar](50) NOT NULL,
	[SECTIONID] [int] NOT NULL,
	[CONTRACTORID] [int] NOT NULL,
	[USERID] [int] NOT NULL,
	[MODDATE] [datetime] NOT NULL,
	[CREATEDATE] [datetime] NOT NULL,
	[INVOICEDATE] [datetime] NULL,
	[GROSSSUM] [money] NOT NULL,
	[NETSUM] [money] NOT NULL,
	FOREIGN KEY(USERID) REFERENCES USERS(USERID),
	CONSTRAINT NETSUM CHECK ( NETSUM >0),
	CONSTRAINT EMAIL CHECK ( dbo.IsValidEmail('EMAIL') = 1),
	CONSTRAINT NIP CHECK ( dbo.IsValidNip('NIP') = 1)
) ON [PRIMARY]
GO

