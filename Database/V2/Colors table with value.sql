USE [ManiMotors]
GO

/****** Object:  Table [dbo].[CashTransaction]    Script Date: 07/26/2017 19:14:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Colors](
	[ColorID] [int] IDENTITY(1,1) NOT NULL,
	[Description] varchar(255) Not NUll,
PRIMARY KEY CLUSTERED 
(
	[ColorID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] 

GO

SET ANSI_PADDING OFF
GO
Insert into [Colors] Values ('--Select--')
Insert into [Colors] Values ('Sassy Cyan')
Insert into [Colors] Values ('Rouge Red')
Insert into [Colors] Values ('Haute White')
Insert into [Colors] Values ('Cool Cobalt')
Insert into [Colors] Values ('Tuxedo Black')
Insert into [Colors] Values ('Blending Blue')
Insert into [Colors] Values ('Fusion Red')
Insert into [Colors] Values ('Unite White')
Insert into [Colors] Values ('Mingling Cyan')

Insert into [Colors] Values ('Blue/white')
Insert into [Colors] Values ('white/red')
Insert into [Colors] Values ('Red/black')
Insert into [Colors] Values ('cyan/black')
Insert into [Colors] Values ('white/cyan')
Insert into [Colors] Values ('mat black')
Insert into [Colors] Values ('mat green')
Insert into [Colors] Values ('green/white')
Insert into [Colors] Values ('green/black')

Insert into [Colors] Values ('grey/orange')
Insert into [Colors] Values ('cyan/gold')
Insert into [Colors] Values ('red/grey')
Insert into [Colors] Values ('grey/cyan')




