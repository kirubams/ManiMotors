USE [ManiMotors]
GO

/****** Object:  Table [dbo].[CustomerEnquiryFollowUp]    Script Date: 06/10/2017 13:11:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VehicleBookingRTOAllotment](
	[VehicleBookingRTOAllotmentID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleBookingID] [int] NOT NULL,
	[RTOInfoID] int not null,
	[TempRegNo] varchar(55) null,
	[RegNo] varchar(55) null,
	[RegDate] DateTime null,
	[Amount] int null,
	[AgentName] varchar(255) null,
	[RCBookNo] varchar(55) null,
	[RCDeliveredTo] int null,
	[RCDeliveredDate] Datetime null,
	[Remark] nvarchar(max) null,
	[Createdby] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[VehicleBookingRTOAllotmentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[VehicleBookingRTOAllotment]  WITH CHECK ADD  CONSTRAINT [fk_RTOAllotmentBookingID] FOREIGN KEY([VehicleBookingID])
REFERENCES [dbo].[VehicleBooking] ([VehicleBookingID])
GO

ALTER TABLE [dbo].[VehicleBookingRTOAllotment] CHECK CONSTRAINT [fk_RTOAllotmentBookingID]
GO

ALTER TABLE [dbo].[VehicleBookingRTOAllotment]  WITH CHECK ADD  CONSTRAINT [fk_RTOInfoID] FOREIGN KEY([RTOInfoID])
REFERENCES [dbo].[RTOInfo] ([RTOInfoID])
GO

ALTER TABLE [dbo].[VehicleBookingRTOAllotment] CHECK CONSTRAINT [fk_RTOInfoID]
GO


