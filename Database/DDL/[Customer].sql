USE [ManiMotors]
GO

/****** Object:  Table [dbo].[Employees]    Script Date: 06/09/2017 21:04:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Address1] [varchar](255) NOT NULL,
	[Address2] [varchar](255) NULL,
	[Email] [varchar](55) NULL,
	[ContactNo] [int] NULL,
	[Age] [int] NULL,
	[DateOfBirth] DATETIME NULL,
	[Gender] varchar(10) Not Null,
	[Occupation] varchar(55) Not null,
	[AreaName] varchar(55) Not null,
	[CreatedDate] [datetime] NULL,
	[Createdby] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

