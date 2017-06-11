USE [ManiMotors]
GO

/****** Object:  Table [dbo].[SparePartsInventoryStatus]    Script Date: 06/08/2017 22:17:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VehicleInventoryStatus](
	[VehicleInventoryStatusID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleInventoryID] [int] NOT NULL,
	[VehicleInventoryStatusTypeID] [int] NOT NULL,
	[Createdby] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[VehicleInventoryStatusID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[VehicleInventoryStatus]  WITH CHECK ADD  CONSTRAINT [fk_VehicleInventoryID] FOREIGN KEY([VehicleInventoryID])
REFERENCES [dbo].[VehicleInventory] ([VehicleInventoryID])
GO

ALTER TABLE [dbo].[VehicleInventoryStatus] CHECK CONSTRAINT [fk_VehicleInventoryID]
GO

ALTER TABLE [dbo].[VehicleInventoryStatus]  WITH CHECK ADD  CONSTRAINT [fk_VehicleInventoryStatusTypeID] FOREIGN KEY([VehicleInventoryStatusTypeID])
REFERENCES [dbo].[VehicleInventoryStatusType] ([VehicleInventoryStatusTypeID])
GO

ALTER TABLE [dbo].[VehicleInventoryStatus] CHECK CONSTRAINT [fk_VehicleInventoryStatusTypeID]
GO


