USE [ManiMotors]
GO

/****** Object:  Table [dbo].[VehicleInventory]    Script Date: 06/08/2017 21:59:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CustomerEnquiryFollowUp](
	[CustomerEnquiryFollowUpID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[CustomerEnquiryID] int not null,
	[Description] nvarchar(max) Not null,
	[Createdby] int not null,
	[CreatedDate] Datetime not null,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerEnquiryFollowUpID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[CustomerEnquiryFollowUp]  WITH CHECK ADD  CONSTRAINT [fk_EnquiryCustomerID] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO

ALTER TABLE [dbo].[CustomerEnquiryFollowUp] CHECK CONSTRAINT [fk_EnquiryCustomerID]
GO

ALTER TABLE [dbo].[CustomerEnquiryFollowUp]  WITH CHECK ADD  CONSTRAINT [fk_CustomerEnquiryID] FOREIGN KEY([CustomerEnquiryID])
REFERENCES [dbo].[CustomerEnquiry] ([CustomerEnquiryID])

GO

ALTER TABLE [dbo].[CustomerEnquiryFollowUp] CHECK CONSTRAINT [fk_CustomerEnquiryID]
GO




