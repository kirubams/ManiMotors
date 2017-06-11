USE [ManiMotors]
GO

/****** Object:  Table [dbo].[VehicleInventory]    Script Date: 06/08/2017 21:59:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CustomerEnquiry](
	[CustomerEnquiryID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[ReferenceBy] varchar(255) null,
	[CashORFinance] varchar(55) Not null,
	[SalesExecutive] int not null,
	[Model1] [int] Not NULL,
	[Model2] [int] NULL,
	[Model3] [int] NULL,
	[Color] varchar(55) null,
	[TestDrive] bit not null,
	[FollowupDate] Datetime not null,
	[ExchangeVehicle] bit not null,
	[CompetitiveModel] varchar(55) null,
	[VehicleStatusID] int not null,
	[Createdby] int not null,
	[CreatedDate] Datetime not null,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerEnquiryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[CustomerEnquiry]  WITH CHECK ADD  CONSTRAINT [fk_CustomerID] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO

ALTER TABLE [dbo].[CustomerEnquiry] CHECK CONSTRAINT [fk_CustomerID]
GO



