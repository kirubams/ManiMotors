USE [ManiMotors]
GO

/****** Object:  Table [dbo].[VehicleInventory]    Script Date: 06/08/2017 21:59:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CustomerExchangeVehicle](
	[CustomerExchangeVehicleID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerEnquiryID] int not null,
	[Model] varchar(55) null,
	[Color] varchar(55) null,
	[mfgdate] DateTime null,
	[EngineCondition] varchar(255) null,
	[OutlookCondition] varchar(255) null,
	[CustomerRate] int not null,
	[BrokerName1] varchar(255) null,
	[Mobileno1] int null,
	[Rate1] int null,
	[DifferenceAmount1] int null,
	[BrokerName2] varchar(255) null,
	[Mobileno2] int null,
	[Rate2] int null,
	[DifferenceAmount2] int null,
	[ExchangeRemark] nvarchar(max) null,
	[FinalAmount] int null,
	[Createdby] int not null,
	[CreatedDate] Datetime not null,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerExchangeVehicleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


ALTER TABLE [dbo].[CustomerExchangeVehicle]  WITH CHECK ADD  CONSTRAINT [fk_CustomerExchangeEnquiryID] FOREIGN KEY([CustomerEnquiryID])
REFERENCES [dbo].[CustomerEnquiry] ([CustomerEnquiryID])
GO

ALTER TABLE [dbo].[CustomerExchangeVehicle] CHECK CONSTRAINT [fk_CustomerExchangeEnquiryID]
GO




