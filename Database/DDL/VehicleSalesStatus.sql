USE [ManiMotors]
GO

/****** Object:  Table [dbo].[SparePartsInventoryStatus]    Script Date: 06/09/2017 21:43:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VehicleSalesStatus](
	[VehicleSalesStatusID] [int] IDENTITY(1,1) NOT NULL,
	[Description] varchar(255) NOT NULL,
	[CreatedDate] [DateTime] not null,
	[Createdby] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[VehicleSalesStatusID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

 

