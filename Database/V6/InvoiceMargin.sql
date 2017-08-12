USE [ManiMotors]
GO

/****** Object:  Table [dbo].[Customer]    Script Date: 08/03/2017 23:14:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[InvoiceMargin](
	[InvoiceMarginID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceID] [int] NOt NULL,
	[InvoiceType] varchar(55) NOT NULL,
	[VehicleBookingID] [int] NOT NULL,
	[MarginTypeID] [int] NOT NULL,
	[MarginAmount] [int] NULL,
	[ActualAmount] [int] NULL,
	[ManualAmount] [int] NULL,
	[MarginID] [int] NULL,
	[Remarks] varchar(1000) NULL,
	[IsReceived] [bit] NOT NULL,
	[ReceivedDate] [datetime] NULL,
	[IsCash] [bit] NOT NULL,
	[ChequeOrBankTranNo] varchar(55) NULL,
	[CreatedDate] [datetime] NULL,
	[Createdby] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[InvoiceMarginID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


