USE [ManiMotors]
GO

/****** Object:  Table [dbo].[ExpenseTransaction]    Script Date: 06/07/2017 22:59:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EmployeeRole](
	[EmployeeRoleID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[RoleID] [int] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[Createdby] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeRoleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[EmployeeRole]  WITH CHECK ADD  CONSTRAINT [fk_EmployeeID] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO

ALTER TABLE [dbo].[EmployeeRole] CHECK CONSTRAINT [fk_EmployeeID]
GO

ALTER TABLE [dbo].[EmployeeRole]  WITH CHECK ADD  CONSTRAINT [fk_RoleID] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO

ALTER TABLE [dbo].[EmployeeRole] CHECK CONSTRAINT [fk_RoleID]
GO


