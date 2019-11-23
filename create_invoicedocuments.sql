USE [ProjektBD]
GO

/****** Object:  Table [dbo].[SALESDOCUMENTS]    Script Date: 18.11.2019 17:25:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[INVOICEDOCUMENTS](
	[DOCID] [int] IDENTITY(1,1) NOT NULL,
	[DOCNUMBER] [nvarchar](50) NOT NULL,
	[SECTIONID] [int] NOT NULL,
	[CONTRACTORID] [int] NOT NULL,
	[USERID] [int] NOT NULL,
	[MODDATE] [datetime] NOT NULL,
	[CREATEDATE] [datetime] NOT NULL,
	[INVOICEDATE] [datetime] NULL,
	[GROSSSUM] [money] NOT NULL,
	[NETSUM] [money] NOT NULL
) ON [PRIMARY]
GO

