USE [ManiMotors] 
GO

/****** Object:  Table [dbo].[GamePrice]    Script Date: 06/07/2017 22:53:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VehicleInfo](
	[VehicleInfoID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleTypeID] [int] not null,
	[ModelCode] varchar(255) not null,
	[ModelName] varchar(255) not null,
	[ExShowRoomPrice] int not null,
	[LT_RT_OtherExp] int not null,
	[InsurancePrice] int not null,
	[OnRoadPrice] int not null,
	[MarginPrice] int not null,
	[50PercentMargin] int not null,
	[70PercentMargin] int not null,
	[CreatedDate] [datetime] NULL,
	[Createdby] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[VehicleInfoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[VehicleInfo]  WITH CHECK ADD  CONSTRAINT [fk_vehicletypeID] FOREIGN KEY([VehicleTypeID])
REFERENCES [dbo].[VehicleType] ([VehicleTypeID])
GO

ALTER TABLE [dbo].[VehicleInfo] CHECK CONSTRAINT [fk_vehicletypeID] 
GO






