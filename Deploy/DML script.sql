USE [ManiMotors]
GO
/****** Object:  Table [dbo].[VehicleType]    Script Date: 07/10/2017 17:23:08 ******/
SET IDENTITY_INSERT [dbo].[VehicleType] ON
INSERT [dbo].[VehicleType] ([VehicleTypeID], [Description], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (1, N'Scooter', CAST(0x0000A78E010F65B4 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[VehicleType] ([VehicleTypeID], [Description], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (2, N'MotorBike', CAST(0x0000A78E010F7DD1 AS DateTime), 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[VehicleType] OFF
/****** Object:  Table [dbo].[VehicleSalesStatus]    Script Date: 07/10/2017 17:23:08 ******/
SET IDENTITY_INSERT [dbo].[VehicleSalesStatus] ON
INSERT [dbo].[VehicleSalesStatus] ([VehicleSalesStatusID], [Description], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (1, N'Open', CAST(0x0000A79C00FB920A AS DateTime), 1, NULL, NULL)
INSERT [dbo].[VehicleSalesStatus] ([VehicleSalesStatusID], [Description], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (2, N'Pending', CAST(0x0000A79C00FB920E AS DateTime), 1, NULL, NULL)
INSERT [dbo].[VehicleSalesStatus] ([VehicleSalesStatusID], [Description], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (3, N'Enquiry', CAST(0x0000A79C00FB920E AS DateTime), 1, NULL, NULL)
INSERT [dbo].[VehicleSalesStatus] ([VehicleSalesStatusID], [Description], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (4, N'Booked', CAST(0x0000A79C00FB920E AS DateTime), 1, NULL, NULL)
INSERT [dbo].[VehicleSalesStatus] ([VehicleSalesStatusID], [Description], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (5, N'Delivered', CAST(0x0000A79C00FB920E AS DateTime), 1, NULL, NULL)
INSERT [dbo].[VehicleSalesStatus] ([VehicleSalesStatusID], [Description], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (6, N'Closed', CAST(0x0000A79C00FB920E AS DateTime), 1, NULL, NULL)
INSERT [dbo].[VehicleSalesStatus] ([VehicleSalesStatusID], [Description], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (7, N'Cancelled', CAST(0x0000A79C00FBCACF AS DateTime), 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[VehicleSalesStatus] OFF
/****** Object:  Table [dbo].[VehicleInventoryStatusType]    Script Date: 07/10/2017 17:23:08 ******/
SET IDENTITY_INSERT [dbo].[VehicleInventoryStatusType] ON
INSERT [dbo].[VehicleInventoryStatusType] ([VehicleInventoryStatusTypeID], [Description], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (1, N'InStock', CAST(0x0000A78E0113A0C4 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[VehicleInventoryStatusType] ([VehicleInventoryStatusTypeID], [Description], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (2, N'Alloted', CAST(0x0000A78E0113A0C4 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[VehicleInventoryStatusType] ([VehicleInventoryStatusTypeID], [Description], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (3, N'Delivered', CAST(0x0000A78E0113A0C4 AS DateTime), 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[VehicleInventoryStatusType] OFF
/****** Object:  Table [dbo].[SparePartsInventoryStatusType]    Script Date: 07/10/2017 17:23:08 ******/
SET IDENTITY_INSERT [dbo].[SparePartsInventoryStatusType] ON
INSERT [dbo].[SparePartsInventoryStatusType] ([SparePartsInventoryStatusTypeID], [Description], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (1, N'InStock', CAST(0x0000A78E01148D69 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[SparePartsInventoryStatusType] ([SparePartsInventoryStatusTypeID], [Description], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (2, N'Alloted', CAST(0x0000A78E01148D69 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[SparePartsInventoryStatusType] ([SparePartsInventoryStatusTypeID], [Description], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (3, N'Delivered', CAST(0x0000A78E01148D69 AS DateTime), 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[SparePartsInventoryStatusType] OFF
/****** Object:  Table [dbo].[RTOInfo]    Script Date: 07/10/2017 17:23:08 ******/
SET IDENTITY_INSERT [dbo].[RTOInfo] ON
INSERT [dbo].[RTOInfo] ([RTOInfoID], [Name], [Address1], [Address2], [ContactNo], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (1, N'RTO Name1', N'Address1', N'Address2', N'1234567890', CAST(0x0000A7A4011D4056 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[RTOInfo] ([RTOInfoID], [Name], [Address1], [Address2], [ContactNo], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (2, N'RTO Name 2', N'Address1', N'Address2', N'1234567890', CAST(0x0000A7A4011D4056 AS DateTime), 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[RTOInfo] OFF
/****** Object:  Table [dbo].[Role]    Script Date: 07/10/2017 17:23:08 ******/
/****** Object:  Table [dbo].[MMRole]    Script Date: 07/10/2017 17:23:08 ******/
SET IDENTITY_INSERT [dbo].[MMRole] ON
INSERT [dbo].[MMRole] ([RoleID], [Description], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (1, N'proprietor', CAST(0x0000A78E010E875A AS DateTime), 1, NULL, NULL)
INSERT [dbo].[MMRole] ([RoleID], [Description], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (2, N'SuperUser', CAST(0x0000A78E010EF3E7 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[MMRole] ([RoleID], [Description], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (3, N'Admin', CAST(0x0000A78E010EEEAC AS DateTime), 1, NULL, NULL)
INSERT [dbo].[MMRole] ([RoleID], [Description], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (4, N'SalesExecutive', CAST(0x0000A78E010EEEAD AS DateTime), 1, NULL, NULL)
INSERT [dbo].[MMRole] ([RoleID], [Description], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (5, N'InventoryStockist', CAST(0x0000A78E010EEEAD AS DateTime), 1, NULL, NULL)
INSERT [dbo].[MMRole] ([RoleID], [Description], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (6, N'Mechanic', CAST(0x0000A78E010EEEAD AS DateTime), 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[MMRole] OFF
/****** Object:  Table [dbo].[MainDealer]    Script Date: 07/10/2017 17:23:08 ******/
/****** Object:  Table [dbo].[InsuranceInfo]    Script Date: 07/10/2017 17:23:08 ******/
SET IDENTITY_INSERT [dbo].[InsuranceInfo] ON
INSERT [dbo].[InsuranceInfo] ([InsuranceInfoID], [Name], [Address1], [Address2], [ContactNo], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (1, N'UnitedIndia Insurance', N'Address1', N'Address2', N'1234567890', CAST(0x0000A7A400FA986A AS DateTime), 1, NULL, NULL)
INSERT [dbo].[InsuranceInfo] ([InsuranceInfoID], [Name], [Address1], [Address2], [ContactNo], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (2, N'ICICI', N'Address1', N'Address2', N'1234567890', CAST(0x0000A7A400FAA93B AS DateTime), 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[InsuranceInfo] OFF
/****** Object:  Table [dbo].[FinanceInfo]    Script Date: 07/10/2017 17:23:08 ******/
SET IDENTITY_INSERT [dbo].[FinanceInfo] ON
INSERT [dbo].[FinanceInfo] ([FinanceInfoID], [Name], [Address1], [Address2], [ContactNo], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (1, N'HDFC', N'Address1', N'Address2', N'1234567890', CAST(0x0000A79D0163AB40 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[FinanceInfo] ([FinanceInfoID], [Name], [Address1], [Address2], [ContactNo], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (2, N'ICICI', N'Address1', N'Address2', N'1234567890', CAST(0x0000A79D0163B92C AS DateTime), 1, NULL, NULL)
INSERT [dbo].[FinanceInfo] ([FinanceInfoID], [Name], [Address1], [Address2], [ContactNo], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (3, N'AXISBANK', N'Address1', N'Address2', N'1234567890', CAST(0x0000A79D0163C81D AS DateTime), 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[FinanceInfo] OFF
/****** Object:  Table [dbo].[Employees]    Script Date: 07/10/2017 17:23:08 ******/
SET IDENTITY_INSERT [dbo].[Employees] ON
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [LastName], [Address1], [Address2], [Email], [ContactNo], [Image], [StartDate], [EndDate], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (1, N'Kirubanandhan', N'Subramaniam', N'7559 Bellingrath Dr', N'Frisco,Texas,75035', N'manimotocorp@gmail.com', N'0014692698733', NULL, CAST(0x0000A78E011212B9 AS DateTime), NULL, CAST(0x0000A78E011212B9 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [LastName], [Address1], [Address2], [Email], [ContactNo], [Image], [StartDate], [EndDate], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (2, N'Nithiya', N'Sivasankaran Kandhan', N'7559 Bellingrath Dr', N'Frisco,TX,75035', N'nithiya.kirubanandhan@gmail.com', N'0012245781873', NULL, CAST(0x0000A79C00F71935 AS DateTime), NULL, CAST(0x0000A79C00F71935 AS DateTime), 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Employees] OFF

Go
CREATE LOGIN [sqlmanimotors] WITH PASSWORD=N'manimotors@123', DEFAULT_DATABASE=[ManiMotors], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
