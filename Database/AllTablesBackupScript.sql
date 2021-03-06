USE [ManiMotors]
GO
/****** Object:  Table [dbo].[VehicleType]    Script Date: 06/10/2017 16:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VehicleType](
	[VehicleTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](255) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[Createdby] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[VehicleTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VehicleSalesStatus]    Script Date: 06/10/2017 16:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VehicleSalesStatus](
	[VehicleSalesStatusID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](255) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Createdby] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[VehicleSalesStatusID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VehicleInventoryStatusType]    Script Date: 06/10/2017 16:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VehicleInventoryStatusType](
	[VehicleInventoryStatusTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](255) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[Createdby] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[VehicleInventoryStatusTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MainDealer]    Script Date: 06/10/2017 16:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MainDealer](
	[MainDealerID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](255) NOT NULL,
	[Contact FirstName] [varchar](255) NOT NULL,
	[Contact LastName] [varchar](255) NOT NULL,
	[Address1] [varchar](255) NULL,
	[Address2] [varchar](255) NULL,
	[ContactNo] [int] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[Createdby] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MainDealerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InsuranceInfo]    Script Date: 06/10/2017 16:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InsuranceInfo](
	[InsuranceInfoID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Address1] [varchar](255) NOT NULL,
	[Address2] [varchar](255) NULL,
	[ContactNo] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Createdby] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[InsuranceInfoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FinanceInfo]    Script Date: 06/10/2017 16:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FinanceInfo](
	[FinanceInfoID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Address1] [varchar](255) NOT NULL,
	[Address2] [varchar](255) NULL,
	[ContactNo] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Createdby] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[FinanceInfoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 06/10/2017 16:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](255) NOT NULL,
	[LastName] [varchar](255) NOT NULL,
	[Address1] [varchar](255) NOT NULL,
	[Address2] [varchar](255) NOT NULL,
	[Email] [varchar](55) NULL,
	[ContactNo] [int] NULL,
	[Image] [varbinary](max) NULL,
	[CreatedDate] [datetime] NULL,
	[Createdby] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 06/10/2017 16:09:12 ******/
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
	[DateOfBirth] [datetime] NULL,
	[Gender] [varchar](10) NOT NULL,
	[Occupation] [varchar](55) NOT NULL,
	[AreaName] [varchar](55) NOT NULL,
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RTOInfo]    Script Date: 06/10/2017 16:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RTOInfo](
	[RTOInfoID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Address1] [varchar](255) NOT NULL,
	[Address2] [varchar](255) NULL,
	[ContactNo] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Createdby] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[RTOInfoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Role]    Script Date: 06/10/2017 16:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](255) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[Createdby] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VehicleBooking]    Script Date: 06/10/2017 16:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VehicleBooking](
	[VehicleBookingID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleEnquiryID] [int] NULL,
	[CustomerID] [int] NOT NULL,
	[CommittedDays] [int] NULL,
	[CommittedDate] [datetime] NULL,
	[ModelID] [int] NOT NULL,
	[Color1] [varchar](55) NULL,
	[Color2] [varchar](55) NULL,
	[Color3] [varchar](55) NULL,
	[CustomerRemark] [nvarchar](max) NULL,
	[Referenceby] [varchar](255) NULL,
	[SalesExecutiveID] [int] NOT NULL,
	[isCash] [bit] NOT NULL,
	[AdvanceAmount] [int] NULL,
	[AdvanceAmountModeBit] [bit] NULL,
	[AdvanceChequeno] [int] NULL,
	[FinancierID] [int] NULL,
	[FinancierRemark] [nvarchar](max) NULL,
	[ReadytoDelivery] [bit] NULL,
	[StatusID] [int] NULL,
	[ClosingRemark] [nvarchar](max) NULL,
	[Createdby] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[VehicleBookingID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SparePartsType]    Script Date: 06/10/2017 16:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SparePartsType](
	[SparePartsTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](255) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[Createdby] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SparePartsTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SparePartsInventoryStatusType]    Script Date: 06/10/2017 16:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SparePartsInventoryStatusType](
	[SparePartsInventoryStatusTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](255) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[Createdby] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SparePartsInventoryStatusTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CustomerEnquiry]    Script Date: 06/10/2017 16:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CustomerEnquiry](
	[CustomerEnquiryID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[ReferenceBy] [varchar](255) NULL,
	[CashORFinance] [varchar](55) NOT NULL,
	[SalesExecutive] [int] NOT NULL,
	[Model1] [int] NOT NULL,
	[Model2] [int] NULL,
	[Model3] [int] NULL,
	[Color] [varchar](55) NULL,
	[TestDrive] [bit] NOT NULL,
	[FollowupDate] [datetime] NOT NULL,
	[ExchangeVehicle] [bit] NOT NULL,
	[CompetitiveModel] [varchar](55) NULL,
	[VehicleStatusID] [int] NOT NULL,
	[Createdby] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerEnquiryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SparePartsInfo]    Script Date: 06/10/2017 16:09:12 ******/
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
/****** Object:  Table [dbo].[VehicleInfo]    Script Date: 06/10/2017 16:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VehicleInfo](
	[VehicleInfoID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleTypeID] [int] NOT NULL,
	[ModelCode] [varchar](255) NOT NULL,
	[ModelName] [varchar](255) NOT NULL,
	[ExShowRoomPrice] [int] NOT NULL,
	[LT_RT_OtherExp] [int] NOT NULL,
	[InsurancePrice] [int] NOT NULL,
	[OnRoadPrice] [int] NOT NULL,
	[MarginPrice] [int] NOT NULL,
	[50PercentMargin] [int] NOT NULL,
	[70PercentMargin] [int] NOT NULL,
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VehicleBookingRTOAllotment]    Script Date: 06/10/2017 16:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VehicleBookingRTOAllotment](
	[VehicleBookingRTOAllotmentID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleBookingID] [int] NOT NULL,
	[RTOInfoID] [int] NOT NULL,
	[TempRegNo] [varchar](55) NULL,
	[RegNo] [varchar](55) NULL,
	[RegDate] [datetime] NULL,
	[Amount] [int] NULL,
	[AgentName] [varchar](255) NULL,
	[RCBookNo] [varchar](55) NULL,
	[RCDeliveredTo] [int] NULL,
	[RCDeliveredDate] [datetime] NULL,
	[Remark] [nvarchar](max) NULL,
	[Createdby] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[VehicleBookingRTOAllotmentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VehicleBookingInsuranceAllotment]    Script Date: 06/10/2017 16:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleBookingInsuranceAllotment](
	[VehicleBookingInsuranceAllotmentID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleBookingID] [int] NOT NULL,
	[InsuranceByDealer] [bit] NOT NULL,
	[InsuranceInfoID] [int] NOT NULL,
	[CoverNoteNo] [int] NULL,
	[PolicyNo] [int] NULL,
	[PolicyAmount] [int] NULL,
	[FromDate] [datetime] NULL,
	[ToDate] [datetime] NULL,
	[PolicyDeliveredTo] [int] NULL,
	[PolicyDeliveredDate] [datetime] NULL,
	[ContactNo] [int] NULL,
	[Createdby] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[VehicleBookingInsuranceAllotmentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehicleBookingFollowUp]    Script Date: 06/10/2017 16:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleBookingFollowUp](
	[VehicleBookingFollowUpID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleBookingID] [int] NOT NULL,
	[CustomerID] [int] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[FollowupDate] [datetime] NOT NULL,
	[isActive] [bit] NOT NULL,
	[Createdby] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[VehicleBookingFollowUpID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehicleBookingFinanceAllotment]    Script Date: 06/10/2017 16:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleBookingFinanceAllotment](
	[VehicleBookingFinanceAllotmentID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleBookingID] [int] NOT NULL,
	[FinancierID] [int] NOT NULL,
	[LoanNo] [int] NULL,
	[FinanceDate] [datetime] NULL,
	[FinanceAmount] [int] NULL,
	[OtherChargesDesc] [nvarchar](max) NULL,
	[OtherAmount] [int] NULL,
	[Createdby] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[VehicleBookingFinanceAllotmentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OtherBookingAllotment]    Script Date: 06/10/2017 16:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OtherBookingAllotment](
	[OtherBookingAllotmentID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleBookingID] [int] NOT NULL,
	[NameofAllotment] [varchar](255) NULL,
	[Description] [nvarchar](max) NULL,
	[AllotmentAmount] [int] NULL,
	[ActualAmount] [int] NULL,
	[Createdby] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[OtherBookingAllotmentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmployeeRole]    Script Date: 06/10/2017 16:09:12 ******/
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
/****** Object:  Table [dbo].[EmployeeLoginDetails]    Script Date: 06/10/2017 16:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmployeeLoginDetails](
	[EmployeeLoginDetailsID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[UserName] [varchar](255) NOT NULL,
	[Password] [varchar](255) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastLoginDate] [datetime] NOT NULL,
	[IsLocked] [bit] NOT NULL,
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CustomerExchangeVehicle]    Script Date: 06/10/2017 16:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CustomerExchangeVehicle](
	[CustomerExchangeVehicleID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerEnquiryID] [int] NOT NULL,
	[Model] [varchar](55) NULL,
	[Color] [varchar](55) NULL,
	[mfgdate] [datetime] NULL,
	[EngineCondition] [varchar](255) NULL,
	[OutlookCondition] [varchar](255) NULL,
	[CustomerRate] [int] NOT NULL,
	[BrokerName1] [varchar](255) NULL,
	[Mobileno1] [int] NULL,
	[Rate1] [int] NULL,
	[DifferenceAmount1] [int] NULL,
	[BrokerName2] [varchar](255) NULL,
	[Mobileno2] [int] NULL,
	[Rate2] [int] NULL,
	[DifferenceAmount2] [int] NULL,
	[ExchangeRemark] [nvarchar](max) NULL,
	[FinalAmount] [int] NULL,
	[Createdby] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerExchangeVehicleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CustomerEnquiryFollowUp]    Script Date: 06/10/2017 16:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerEnquiryFollowUp](
	[CustomerEnquiryFollowUpID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[CustomerEnquiryID] [int] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Createdby] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerEnquiryFollowUpID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehicleInventory]    Script Date: 06/10/2017 16:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VehicleInventory](
	[VehicleInventoryID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleInfoID] [int] NOT NULL,
	[ChasisNo] [varchar](255) NOT NULL,
	[EngineNo] [varchar](255) NOT NULL,
	[Color] [varchar](255) NOT NULL,
	[ManfgDate] [datetime] NULL,
	[ServiceBookNo] [varchar](255) NOT NULL,
	[KeyNo] [varchar](255) NOT NULL,
	[BatteryNo] [varchar](255) NOT NULL,
	[BatteryMake] [varchar](255) NOT NULL,
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SparePartsInventory]    Script Date: 06/10/2017 16:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SparePartsInventory](
	[SparePartsInventoryID] [int] IDENTITY(1,1) NOT NULL,
	[SparePartsInfoID] [int] NOT NULL,
	[IdentificationNo] [varchar](255) NOT NULL,
	[OtherDescription] [varchar](255) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[Createdby] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SparePartsInventoryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VehicleInventoryStatus]    Script Date: 06/10/2017 16:09:12 ******/
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
/****** Object:  Table [dbo].[VehicleBookingAllotment]    Script Date: 06/10/2017 16:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleBookingAllotment](
	[VehicleBookingAllotmentID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleBookingID] [int] NOT NULL,
	[VehicleInventoryID] [int] NOT NULL,
	[Createdby] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[VehicleBookingAllotmentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SparePartsBookingAllotment]    Script Date: 06/10/2017 16:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SparePartsBookingAllotment](
	[SparePartsBookingAllotmentID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleBookingID] [int] NOT NULL,
	[SparePartsInventoryID] [int] NOT NULL,
	[Createdby] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SparePartsBookingAllotmentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SparePartsInventoryStatus]    Script Date: 06/10/2017 16:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SparePartsInventoryStatus](
	[SparePartsInventoryStatusID] [int] IDENTITY(1,1) NOT NULL,
	[SparePartsInventoryID] [int] NOT NULL,
	[SparePartsInventoryStatusTypeID] [int] NOT NULL,
	[Createdby] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[Modifiedby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SparePartsInventoryStatusID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [fk_CustomerID]    Script Date: 06/10/2017 16:09:12 ******/
ALTER TABLE [dbo].[CustomerEnquiry]  WITH CHECK ADD  CONSTRAINT [fk_CustomerID] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[CustomerEnquiry] CHECK CONSTRAINT [fk_CustomerID]
GO
/****** Object:  ForeignKey [fk_CustomerEnquiryID]    Script Date: 06/10/2017 16:09:12 ******/
ALTER TABLE [dbo].[CustomerEnquiryFollowUp]  WITH CHECK ADD  CONSTRAINT [fk_CustomerEnquiryID] FOREIGN KEY([CustomerEnquiryID])
REFERENCES [dbo].[CustomerEnquiry] ([CustomerEnquiryID])
GO
ALTER TABLE [dbo].[CustomerEnquiryFollowUp] CHECK CONSTRAINT [fk_CustomerEnquiryID]
GO
/****** Object:  ForeignKey [fk_EnquiryCustomerID]    Script Date: 06/10/2017 16:09:12 ******/
ALTER TABLE [dbo].[CustomerEnquiryFollowUp]  WITH CHECK ADD  CONSTRAINT [fk_EnquiryCustomerID] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[CustomerEnquiryFollowUp] CHECK CONSTRAINT [fk_EnquiryCustomerID]
GO
/****** Object:  ForeignKey [fk_CustomerExchangeEnquiryID]    Script Date: 06/10/2017 16:09:12 ******/
ALTER TABLE [dbo].[CustomerExchangeVehicle]  WITH CHECK ADD  CONSTRAINT [fk_CustomerExchangeEnquiryID] FOREIGN KEY([CustomerEnquiryID])
REFERENCES [dbo].[CustomerEnquiry] ([CustomerEnquiryID])
GO
ALTER TABLE [dbo].[CustomerExchangeVehicle] CHECK CONSTRAINT [fk_CustomerExchangeEnquiryID]
GO
/****** Object:  ForeignKey [fk_EmployeeLoginID]    Script Date: 06/10/2017 16:09:12 ******/
ALTER TABLE [dbo].[EmployeeLoginDetails]  WITH CHECK ADD  CONSTRAINT [fk_EmployeeLoginID] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[EmployeeLoginDetails] CHECK CONSTRAINT [fk_EmployeeLoginID]
GO
/****** Object:  ForeignKey [fk_EmployeeID]    Script Date: 06/10/2017 16:09:12 ******/
ALTER TABLE [dbo].[EmployeeRole]  WITH CHECK ADD  CONSTRAINT [fk_EmployeeID] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[EmployeeRole] CHECK CONSTRAINT [fk_EmployeeID]
GO
/****** Object:  ForeignKey [fk_RoleID]    Script Date: 06/10/2017 16:09:12 ******/
ALTER TABLE [dbo].[EmployeeRole]  WITH CHECK ADD  CONSTRAINT [fk_RoleID] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[EmployeeRole] CHECK CONSTRAINT [fk_RoleID]
GO
/****** Object:  ForeignKey [fk_OtherAllotmentBookingID]    Script Date: 06/10/2017 16:09:12 ******/
ALTER TABLE [dbo].[OtherBookingAllotment]  WITH CHECK ADD  CONSTRAINT [fk_OtherAllotmentBookingID] FOREIGN KEY([VehicleBookingID])
REFERENCES [dbo].[VehicleBooking] ([VehicleBookingID])
GO
ALTER TABLE [dbo].[OtherBookingAllotment] CHECK CONSTRAINT [fk_OtherAllotmentBookingID]
GO
/****** Object:  ForeignKey [fk_SparePartsAllomentInventoryID]    Script Date: 06/10/2017 16:09:12 ******/
ALTER TABLE [dbo].[SparePartsBookingAllotment]  WITH CHECK ADD  CONSTRAINT [fk_SparePartsAllomentInventoryID] FOREIGN KEY([SparePartsInventoryID])
REFERENCES [dbo].[SparePartsInventory] ([SparePartsInventoryID])
GO
ALTER TABLE [dbo].[SparePartsBookingAllotment] CHECK CONSTRAINT [fk_SparePartsAllomentInventoryID]
GO
/****** Object:  ForeignKey [fk_SparePartsAllotmentBookingID]    Script Date: 06/10/2017 16:09:12 ******/
ALTER TABLE [dbo].[SparePartsBookingAllotment]  WITH CHECK ADD  CONSTRAINT [fk_SparePartsAllotmentBookingID] FOREIGN KEY([VehicleBookingID])
REFERENCES [dbo].[VehicleBooking] ([VehicleBookingID])
GO
ALTER TABLE [dbo].[SparePartsBookingAllotment] CHECK CONSTRAINT [fk_SparePartsAllotmentBookingID]
GO
/****** Object:  ForeignKey [fk_SparePartstypeID]    Script Date: 06/10/2017 16:09:12 ******/
ALTER TABLE [dbo].[SparePartsInfo]  WITH CHECK ADD  CONSTRAINT [fk_SparePartstypeID] FOREIGN KEY([SparePartsTypeID])
REFERENCES [dbo].[SparePartsType] ([SparePartsTypeID])
GO
ALTER TABLE [dbo].[SparePartsInfo] CHECK CONSTRAINT [fk_SparePartstypeID]
GO
/****** Object:  ForeignKey [fk_SparePartsInfoID]    Script Date: 06/10/2017 16:09:12 ******/
ALTER TABLE [dbo].[SparePartsInventory]  WITH CHECK ADD  CONSTRAINT [fk_SparePartsInfoID] FOREIGN KEY([SparePartsInfoID])
REFERENCES [dbo].[SparePartsInfo] ([SparePartsInfoID])
GO
ALTER TABLE [dbo].[SparePartsInventory] CHECK CONSTRAINT [fk_SparePartsInfoID]
GO
/****** Object:  ForeignKey [fk_SparePartsInventoryID]    Script Date: 06/10/2017 16:09:12 ******/
ALTER TABLE [dbo].[SparePartsInventoryStatus]  WITH CHECK ADD  CONSTRAINT [fk_SparePartsInventoryID] FOREIGN KEY([SparePartsInventoryID])
REFERENCES [dbo].[SparePartsInventory] ([SparePartsInventoryID])
GO
ALTER TABLE [dbo].[SparePartsInventoryStatus] CHECK CONSTRAINT [fk_SparePartsInventoryID]
GO
/****** Object:  ForeignKey [fk_SparePartsInventoryStatusTypeID]    Script Date: 06/10/2017 16:09:12 ******/
ALTER TABLE [dbo].[SparePartsInventoryStatus]  WITH CHECK ADD  CONSTRAINT [fk_SparePartsInventoryStatusTypeID] FOREIGN KEY([SparePartsInventoryStatusTypeID])
REFERENCES [dbo].[SparePartsInventoryStatusType] ([SparePartsInventoryStatusTypeID])
GO
ALTER TABLE [dbo].[SparePartsInventoryStatus] CHECK CONSTRAINT [fk_SparePartsInventoryStatusTypeID]
GO
/****** Object:  ForeignKey [fk_VehicleAllotmentBookingID]    Script Date: 06/10/2017 16:09:12 ******/
ALTER TABLE [dbo].[VehicleBookingAllotment]  WITH CHECK ADD  CONSTRAINT [fk_VehicleAllotmentBookingID] FOREIGN KEY([VehicleBookingID])
REFERENCES [dbo].[VehicleBooking] ([VehicleBookingID])
GO
ALTER TABLE [dbo].[VehicleBookingAllotment] CHECK CONSTRAINT [fk_VehicleAllotmentBookingID]
GO
/****** Object:  ForeignKey [fk_VehicleAllotmentInventoryID]    Script Date: 06/10/2017 16:09:12 ******/
ALTER TABLE [dbo].[VehicleBookingAllotment]  WITH CHECK ADD  CONSTRAINT [fk_VehicleAllotmentInventoryID] FOREIGN KEY([VehicleInventoryID])
REFERENCES [dbo].[VehicleInventory] ([VehicleInventoryID])
GO
ALTER TABLE [dbo].[VehicleBookingAllotment] CHECK CONSTRAINT [fk_VehicleAllotmentInventoryID]
GO
/****** Object:  ForeignKey [fk_FinanceAllotmentBookingID]    Script Date: 06/10/2017 16:09:12 ******/
ALTER TABLE [dbo].[VehicleBookingFinanceAllotment]  WITH CHECK ADD  CONSTRAINT [fk_FinanceAllotmentBookingID] FOREIGN KEY([VehicleBookingID])
REFERENCES [dbo].[VehicleBooking] ([VehicleBookingID])
GO
ALTER TABLE [dbo].[VehicleBookingFinanceAllotment] CHECK CONSTRAINT [fk_FinanceAllotmentBookingID]
GO
/****** Object:  ForeignKey [fk_financeInfoID]    Script Date: 06/10/2017 16:09:12 ******/
ALTER TABLE [dbo].[VehicleBookingFinanceAllotment]  WITH CHECK ADD  CONSTRAINT [fk_financeInfoID] FOREIGN KEY([FinancierID])
REFERENCES [dbo].[FinanceInfo] ([FinanceInfoID])
GO
ALTER TABLE [dbo].[VehicleBookingFinanceAllotment] CHECK CONSTRAINT [fk_financeInfoID]
GO
/****** Object:  ForeignKey [fk_VehicleBookingID]    Script Date: 06/10/2017 16:09:12 ******/
ALTER TABLE [dbo].[VehicleBookingFollowUp]  WITH CHECK ADD  CONSTRAINT [fk_VehicleBookingID] FOREIGN KEY([VehicleBookingID])
REFERENCES [dbo].[VehicleBooking] ([VehicleBookingID])
GO
ALTER TABLE [dbo].[VehicleBookingFollowUp] CHECK CONSTRAINT [fk_VehicleBookingID]
GO
/****** Object:  ForeignKey [fk_VehicleFollowupCustomerID]    Script Date: 06/10/2017 16:09:12 ******/
ALTER TABLE [dbo].[VehicleBookingFollowUp]  WITH CHECK ADD  CONSTRAINT [fk_VehicleFollowupCustomerID] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[VehicleBookingFollowUp] CHECK CONSTRAINT [fk_VehicleFollowupCustomerID]
GO
/****** Object:  ForeignKey [fk_InsuranceAllotmentBookingID]    Script Date: 06/10/2017 16:09:12 ******/
ALTER TABLE [dbo].[VehicleBookingInsuranceAllotment]  WITH CHECK ADD  CONSTRAINT [fk_InsuranceAllotmentBookingID] FOREIGN KEY([VehicleBookingID])
REFERENCES [dbo].[VehicleBooking] ([VehicleBookingID])
GO
ALTER TABLE [dbo].[VehicleBookingInsuranceAllotment] CHECK CONSTRAINT [fk_InsuranceAllotmentBookingID]
GO
/****** Object:  ForeignKey [fk_InsuranceInfoID]    Script Date: 06/10/2017 16:09:12 ******/
ALTER TABLE [dbo].[VehicleBookingInsuranceAllotment]  WITH CHECK ADD  CONSTRAINT [fk_InsuranceInfoID] FOREIGN KEY([InsuranceInfoID])
REFERENCES [dbo].[InsuranceInfo] ([InsuranceInfoID])
GO
ALTER TABLE [dbo].[VehicleBookingInsuranceAllotment] CHECK CONSTRAINT [fk_InsuranceInfoID]
GO
/****** Object:  ForeignKey [fk_RTOAllotmentBookingID]    Script Date: 06/10/2017 16:09:12 ******/
ALTER TABLE [dbo].[VehicleBookingRTOAllotment]  WITH CHECK ADD  CONSTRAINT [fk_RTOAllotmentBookingID] FOREIGN KEY([VehicleBookingID])
REFERENCES [dbo].[VehicleBooking] ([VehicleBookingID])
GO
ALTER TABLE [dbo].[VehicleBookingRTOAllotment] CHECK CONSTRAINT [fk_RTOAllotmentBookingID]
GO
/****** Object:  ForeignKey [fk_RTOInfoID]    Script Date: 06/10/2017 16:09:12 ******/
ALTER TABLE [dbo].[VehicleBookingRTOAllotment]  WITH CHECK ADD  CONSTRAINT [fk_RTOInfoID] FOREIGN KEY([RTOInfoID])
REFERENCES [dbo].[RTOInfo] ([RTOInfoID])
GO
ALTER TABLE [dbo].[VehicleBookingRTOAllotment] CHECK CONSTRAINT [fk_RTOInfoID]
GO
/****** Object:  ForeignKey [fk_vehicletypeID]    Script Date: 06/10/2017 16:09:12 ******/
ALTER TABLE [dbo].[VehicleInfo]  WITH CHECK ADD  CONSTRAINT [fk_vehicletypeID] FOREIGN KEY([VehicleTypeID])
REFERENCES [dbo].[VehicleType] ([VehicleTypeID])
GO
ALTER TABLE [dbo].[VehicleInfo] CHECK CONSTRAINT [fk_vehicletypeID]
GO
/****** Object:  ForeignKey [fk_VehicleInfoID]    Script Date: 06/10/2017 16:09:12 ******/
ALTER TABLE [dbo].[VehicleInventory]  WITH CHECK ADD  CONSTRAINT [fk_VehicleInfoID] FOREIGN KEY([VehicleInfoID])
REFERENCES [dbo].[VehicleInfo] ([VehicleInfoID])
GO
ALTER TABLE [dbo].[VehicleInventory] CHECK CONSTRAINT [fk_VehicleInfoID]
GO
/****** Object:  ForeignKey [fk_VehicleInventoryID]    Script Date: 06/10/2017 16:09:12 ******/
ALTER TABLE [dbo].[VehicleInventoryStatus]  WITH CHECK ADD  CONSTRAINT [fk_VehicleInventoryID] FOREIGN KEY([VehicleInventoryID])
REFERENCES [dbo].[VehicleInventory] ([VehicleInventoryID])
GO
ALTER TABLE [dbo].[VehicleInventoryStatus] CHECK CONSTRAINT [fk_VehicleInventoryID]
GO
/****** Object:  ForeignKey [fk_VehicleInventoryStatusTypeID]    Script Date: 06/10/2017 16:09:12 ******/
ALTER TABLE [dbo].[VehicleInventoryStatus]  WITH CHECK ADD  CONSTRAINT [fk_VehicleInventoryStatusTypeID] FOREIGN KEY([VehicleInventoryStatusTypeID])
REFERENCES [dbo].[VehicleInventoryStatusType] ([VehicleInventoryStatusTypeID])
GO
ALTER TABLE [dbo].[VehicleInventoryStatus] CHECK CONSTRAINT [fk_VehicleInventoryStatusTypeID]
GO
