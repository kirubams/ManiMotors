USE [ManiMotors]
GO

/****** Object:  Table [dbo].[SparePartsInventoryStatus]    Script Date: 06/09/2017 21:43:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FinanceInfo](
	[FinanceInfoID] [int] IDENTITY(1,1) NOT NULL,
	[Name] varchar(255) NOT NULL,
	[Address1] varchar(255) NOT NULL,
	[Address2] varchar(255) NULL,
	[ContactNo] int NOT NULL,
	[CreatedDate] Datetime NOT NULL,
	[Createdby] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[FinanceInfoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

 

