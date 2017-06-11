USE [ManiMotors]
GO

/****** Object:  Table [dbo].[GamePrice]    Script Date: 06/07/2017 22:53:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employees](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] varchar(255) not null,
	[LastName] varchar(255) not null,
	[Address1] varchar(255) not null,
	[Address2] varchar(255) not null,
	[Email] varchar(55) null,
	[ContactNo] int null,
	[Image] varbinary(max),
	[CreatedDate] [datetime] NULL,
	[Createdby] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


