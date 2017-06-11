USE [ManiMotors]
GO

/****** Object:  Table [dbo].[VehicleInfo]    Script Date: 06/08/2017 21:54:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SparePartsInfo](
	[SparePartsInfoID] [int] IDENTITY(1,1) NOT NULL,
	[SparePartsTypeID] [int] NOT NULL,
	[ModelCode] [varchar](255) NOT NULL,
	[ModelName] [varchar](255) NOT NULL,
	[ShowRoomPrice] [int] NOT NULL,
	[MarginPrice] [int] NOT NULL,
	[50PercentMargin] [int] NOT NULL,
	[70PercentMargin] [int] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[Createdby] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SparePartsInfoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SparePartsInfo]  WITH CHECK ADD  CONSTRAINT [fk_SparePartstypeID] FOREIGN KEY([SparePartsTypeID])
REFERENCES [dbo].[SparePartsType] ([SparePartsTypeID])
GO

ALTER TABLE [dbo].[SparePartsInfo] CHECK CONSTRAINT [fk_SparePartstypeID]
GO


