USE [ManiMotors] 
GO

/****** Object:  Table [dbo].[GamePrice]    Script Date: 06/07/2017 22:53:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VehicleInventory](
	[VehicleInventoryID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleInfoID] [int] not null,
	[ChasisNo] varchar(255) not null,
	[EngineNo] varchar(255) not null,
	[Color] varchar(255) not null,
	[ManfgDate] DateTime null,
	[ServiceBookNo] varchar(255) not null,
	[KeyNo] varchar(255) not null,
	[BatteryNo] varchar(255) not null,
	[BatteryMake] varchar(255) not null,
	[CreatedDate] [datetime] NULL,
	[Createdby] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[VehicleInventoryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[VehicleInventory]  WITH CHECK ADD  CONSTRAINT [fk_VehicleInfoID] FOREIGN KEY([VehicleInfoID])
REFERENCES [dbo].[VehicleInfo] ([VehicleInfoID])
GO

ALTER TABLE [dbo].[VehicleInventory] CHECK CONSTRAINT [fk_VehicleInfoID] 
GO






