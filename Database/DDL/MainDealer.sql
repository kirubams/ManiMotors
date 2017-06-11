USE [ManiMotors]
GO

/****** Object:  Table [dbo].[GamePrice]    Script Date: 06/07/2017 22:53:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MainDealer](
	[MainDealerID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] varchar(255) not null,
	[Contact FirstName] varchar(255) not null,
	[Contact LastName] varchar(255) not null,
	[Address1] varchar(255) null,
	[Address2] varchar(255) null,
	[ContactNo] int not null,
	[CreatedDate] [datetime] NULL,
	[Createdby] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MainDealerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO




