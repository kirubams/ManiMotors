USE [ManiMotors]
GO

/****** Object:  Table [dbo].[CustomerEnquiryFollowUp]    Script Date: 06/10/2017 13:11:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VehicleBookingAllotment](
	[VehicleBookingAllotmentID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleBookingID] [int] NOT NULL,
	[VehicleInventoryID] [int] NOT NULL,
	[Createdby] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[VehicleBookingAllotmentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[VehicleBookingAllotment]  WITH CHECK ADD  CONSTRAINT [fk_VehicleAllotmentBookingID] FOREIGN KEY([VehicleBookingID])
REFERENCES [dbo].[VehicleBooking] ([VehicleBookingID])
GO

ALTER TABLE [dbo].[VehicleBookingAllotment] CHECK CONSTRAINT [fk_VehicleAllotmentBookingID]
GO

ALTER TABLE [dbo].[VehicleBookingAllotment]  WITH CHECK ADD  CONSTRAINT [fk_VehicleAllotmentInventoryID] FOREIGN KEY([VehicleInventoryID])
REFERENCES [dbo].[VehicleInventory] ([VehicleInventoryID])
GO

ALTER TABLE [dbo].[VehicleBookingAllotment] CHECK CONSTRAINT [fk_VehicleAllotmentInventoryID]
GO


