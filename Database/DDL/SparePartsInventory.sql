USE [ManiMotors]
GO

/****** Object:  Table [dbo].[VehicleInventory]    Script Date: 06/08/2017 21:59:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SparePartsInventory](
	[SparePartsInventoryID] [int] IDENTITY(1,1) NOT NULL,
	[SparePartsInfoID] [int] NOT NULL,
	[IdentificationNo] varchar(255) Not null,
	[OtherDescription] varchar(255) Not null,
	[CreatedDate] [datetime] NULL,
	[Createdby] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SparePartsInventoryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SparePartsInventory]  WITH CHECK ADD  CONSTRAINT [fk_SparePartsInfoID] FOREIGN KEY([SparePartsInfoID])
REFERENCES [dbo].[SparePartsInfo] ([SparePartsInfoID])
GO

ALTER TABLE [dbo].[SparePartsInventory] CHECK CONSTRAINT [fk_SparePartsInfoID]
GO


