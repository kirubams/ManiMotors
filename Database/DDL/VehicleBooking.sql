USE [ManiMotors]
GO

/****** Object:  Table [dbo].[VehicleInventory]    Script Date: 06/08/2017 21:59:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VehicleBooking](
	[VehicleBookingID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleEnquiryID] int null,
	[CustomerID] int not null,
	[CommittedDays] int null,
	[CommittedDate] Datetime null,
	[ModelID] int not null,
	[Color1] varchar(55) null,
	[Color2] varchar(55) null,
	[Color3] varchar(55) null,
	[CustomerRemark] nvarchar(max) null,
	[Referenceby] varchar(255) null,
	[SalesExecutiveID] int not null,
	[isCash] bit not null,
	[AdvanceAmount] int null,
	[AdvanceAmountModeBit] bit null,
	[AdvanceChequeno] int null,
	[FinancierID] int null,
	[FinancierRemark] nvarchar(max) null,
	[ReadytoDelivery] bit null,
	[StatusID] int null,
	[ClosingRemark] nvarchar(max) null, 
	[Createdby] int not null,
	[CreatedDate] Datetime not null,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[VehicleBookingID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO




