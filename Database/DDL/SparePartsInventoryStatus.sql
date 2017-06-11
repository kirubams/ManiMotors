USE [ManiMotors]
GO

/****** Object:  Table [dbo].[SparePartsInventoryStatusType]    Script Date: 06/08/2017 22:07:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SparePartsInventoryStatus](
	[SparePartsInventoryStatusID] [int] IDENTITY(1,1) NOT NULL,
	[SparePartsInventoryID][int] NOT NULL,
	[SparePartsInventoryStatusTypeID] [int] NOT NULL,
	[Createdby] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SparePartsInventoryStatusID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SparePartsInventoryStatus]  WITH CHECK ADD  CONSTRAINT [fk_SparePartsInventoryStatusTypeID] FOREIGN KEY([SparePartsInventoryStatusTypeID])
REFERENCES [dbo].[SparePartsInventoryStatusType] ([SparePartsInventoryStatusTypeID])
GO

ALTER TABLE [dbo].[SparePartsInventoryStatus] CHECK CONSTRAINT [fk_SparePartsInventoryStatusTypeID]
GO

ALTER TABLE [dbo].[SparePartsInventoryStatus]  WITH CHECK ADD  CONSTRAINT [fk_SparePartsInventoryID] FOREIGN KEY([SparePartsInventoryID])
REFERENCES [dbo].[SparePartsInventory] ([SparePartsInventoryID])
GO

ALTER TABLE [dbo].[SparePartsInventoryStatus] CHECK CONSTRAINT [fk_SparePartsInventoryID]
GO



