USE [ManiMotors]
GO

/****** Object:  Table [dbo].[CustomerEnquiryFollowUp]    Script Date: 06/10/2017 13:11:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VehicleBookingFinanceAllotment](
	[VehicleBookingFinanceAllotmentID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleBookingID] [int] NOT NULL,
	[FinancierID] [int] NOT NULL,
	[LoanNo] [int] null,
	[FinanceDate] [DateTime] null,
	[FinanceAmount] [int] null,
	[OtherChargesDesc] nvarchar(max) null,
	[OtherAmount] int null,
	[Createdby] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[VehicleBookingFinanceAllotmentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[VehicleBookingFinanceAllotment]  WITH CHECK ADD  CONSTRAINT [fk_FinanceAllotmentBookingID] FOREIGN KEY([VehicleBookingID])
REFERENCES [dbo].[VehicleBooking] ([VehicleBookingID])
GO

ALTER TABLE [dbo].[VehicleBookingFinanceAllotment] CHECK CONSTRAINT [fk_FinanceAllotmentBookingID]
GO

ALTER TABLE [dbo].[VehicleBookingFinanceAllotment]  WITH CHECK ADD  CONSTRAINT [fk_financeInfoID] FOREIGN KEY([FinancierID])
REFERENCES [dbo].[FinanceInfo] ([FinanceInfoID])
GO

ALTER TABLE [dbo].[VehicleBookingFinanceAllotment] CHECK CONSTRAINT [fk_financeInfoID]
GO


