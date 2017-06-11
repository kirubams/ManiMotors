USE [ManiMotors]
GO

/****** Object:  Table [dbo].[CustomerEnquiryFollowUp]    Script Date: 06/10/2017 13:11:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SparePartsBookingAllotment](
	[SparePartsBookingAllotmentID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleBookingID] [int] NOT NULL,
	[SparePartsInventoryID] [int] NOT NULL,
	[Createdby] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SparePartsBookingAllotmentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[SparePartsBookingAllotment]  WITH CHECK ADD  CONSTRAINT [fk_SparePartsAllotmentBookingID] FOREIGN KEY([VehicleBookingID])
REFERENCES [dbo].[VehicleBooking] ([VehicleBookingID])
GO

ALTER TABLE [dbo].[SparePartsBookingAllotment] CHECK CONSTRAINT [fk_SparePartsAllotmentBookingID]
GO

ALTER TABLE [dbo].[SparePartsBookingAllotment]  WITH CHECK ADD  CONSTRAINT [fk_SparePartsAllomentInventoryID] FOREIGN KEY([SparePartsInventoryID])
REFERENCES [dbo].[SparePartsInventory] ([SparePartsInventoryID])
GO

ALTER TABLE [dbo].[SparePartsBookingAllotment] CHECK CONSTRAINT [fk_SparePartsAllomentInventoryID]
GO


