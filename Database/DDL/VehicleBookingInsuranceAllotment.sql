USE [ManiMotors]
GO

/****** Object:  Table [dbo].[CustomerEnquiryFollowUp]    Script Date: 06/10/2017 13:11:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VehicleBookingInsuranceAllotment](
	[VehicleBookingInsuranceAllotmentID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleBookingID] [int] NOT NULL,
	[InsuranceByDealer] bit not null,
	[InsuranceInfoID] int not null,
	[CoverNoteNo] [int] null,
	[PolicyNo] [int] null,
	[PolicyAmount] int null,
	[FromDate] Datetime null,
	[ToDate] Datetime null,
	[PolicyDeliveredTo] int null,
	[PolicyDeliveredDate] DateTime null,
	[ContactNo] [int] null,
	[Createdby] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[VehicleBookingInsuranceAllotmentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[VehicleBookingInsuranceAllotment]  WITH CHECK ADD  CONSTRAINT [fk_InsuranceAllotmentBookingID] FOREIGN KEY([VehicleBookingID])
REFERENCES [dbo].[VehicleBooking] ([VehicleBookingID])
GO

ALTER TABLE [dbo].[VehicleBookingInsuranceAllotment] CHECK CONSTRAINT [fk_InsuranceAllotmentBookingID]
GO

ALTER TABLE [dbo].[VehicleBookingInsuranceAllotment]  WITH CHECK ADD  CONSTRAINT [fk_InsuranceInfoID] FOREIGN KEY([InsuranceInfoID])
REFERENCES [dbo].[InsuranceInfo] ([InsuranceInfoID])
GO

ALTER TABLE [dbo].[VehicleBookingInsuranceAllotment] CHECK CONSTRAINT [fk_InsuranceInfoID]
GO


