USE [ManiMotors]
GO

/****** Object:  Table [dbo].[GamePrice]    Script Date: 06/07/2017 22:53:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EmployeeLoginDetails](
	[EmployeeLoginDetailsID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] not null,
	[UserName] varchar(255) not null,
	[Password] varchar(255) not null,
	[IsActive] bit not null,
	[LastLoginDate] DateTime not null,
	[IsLocked] bit not null,
	[CreatedDate] [datetime] NULL,
	[Createdby] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeLoginDetailsID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[EmployeeLoginDetails]  WITH CHECK ADD  CONSTRAINT [fk_EmployeeLoginID] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO

ALTER TABLE [dbo].[EmployeeLoginDetails] CHECK CONSTRAINT [fk_EmployeeLoginID] 
GO



