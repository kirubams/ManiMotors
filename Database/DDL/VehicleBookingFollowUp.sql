USE [ManiMotors]
GO

/****** Object:  Table [dbo].[CustomerEnquiryFollowUp]    Script Date: 06/10/2017 13:11:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VehicleBookingFollowUp](
	[VehicleBookingFollowUpID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleBookingID] [int] NOT NULL,
	[CustomerID] [int] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[FollowupDate] [DateTime] not null,
	[isActive] bit not null,
	[Createdby] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[VehicleBookingFollowUpID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[VehicleBookingFollowUp]  WITH CHECK ADD  CONSTRAINT [fk_VehicleBookingID] FOREIGN KEY([VehicleBookingID])
REFERENCES [dbo].[VehicleBooking] ([VehicleBookingID])
GO

ALTER TABLE [dbo].[VehicleBookingFollowUp] CHECK CONSTRAINT [fk_VehicleBookingID]
GO

ALTER TABLE [dbo].[VehicleBookingFollowUp]  WITH CHECK ADD  CONSTRAINT [fk_VehicleFollowupCustomerID] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO

ALTER TABLE [dbo].[VehicleBookingFollowUp] CHECK CONSTRAINT [fk_VehicleFollowupCustomerID]
GO


