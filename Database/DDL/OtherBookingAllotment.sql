USE [ManiMotors]
GO

/****** Object:  Table [dbo].[CustomerEnquiryFollowUp]    Script Date: 06/10/2017 13:11:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OtherBookingAllotment](
	[OtherBookingAllotmentID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleBookingID] [int] NOT NULL,
	[NameofAllotment] varchar(255) NULL,
	[Description] nvarchar(max) null,
	[AllotmentAmount] int null,
	[ActualAmount] int null,
	[Createdby] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[OtherBookingAllotmentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[OtherBookingAllotment]  WITH CHECK ADD  CONSTRAINT [fk_OtherAllotmentBookingID] FOREIGN KEY([VehicleBookingID])
REFERENCES [dbo].[VehicleBooking] ([VehicleBookingID])
GO

ALTER TABLE [dbo].[OtherBookingAllotment] CHECK CONSTRAINT [fk_OtherAllotmentBookingID]
GO



