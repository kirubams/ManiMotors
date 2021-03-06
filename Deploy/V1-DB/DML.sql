Select * from Employees
Select * from EmployeeLoginDetails
Delete from Employees
Delete from EmployeeLoginDetails
DBCC CHECKIDENT ('Employees', RESEED, 0);
DBCC CHECKIDENT ('EmployeeLoginDetails', RESEED, 0);

DECLARE @Date char(8)
set @Date='07162017'
Insert into Employees Values ('Kiruba','Subramaniam','Not Needed','Not Needed','Not Needed','4692698733',null,CONVERT(datetime,RIGHT(@Date,4)+LEFT(@Date,2)+SUBSTRING(@Date,3,2)),null, GETDATE(),1,null,null)
Insert into Employees Values ('Suganya','Subramaniam','Not Needed','Not Needed','Not Needed','9344474390',null,CONVERT(datetime,RIGHT(@Date,4)+LEFT(@Date,2)+SUBSTRING(@Date,3,2)),null, GETDATE(),1,null,null)
Insert into Employees Values ('Ashok','Kannan','Not Needed','Not Needed','Not Needed','9443319071',null,CONVERT(datetime,RIGHT(@Date,4)+LEFT(@Date,2)+SUBSTRING(@Date,3,2)),null, GETDATE(),1,null,null)
Insert into Employees Values ('Arulkumar','A','Not Needed','Not Needed','Not Needed','9659765670',null,CONVERT(datetime,RIGHT(@Date,4)+LEFT(@Date,2)+SUBSTRING(@Date,3,2)),null, GETDATE(),1,null,null)
Insert into Employees Values ('Dhasarathan','K','Not Needed','Not Needed','Not Needed','7538863936',null,CONVERT(datetime,RIGHT(@Date,4)+LEFT(@Date,2)+SUBSTRING(@Date,3,2)),null, GETDATE(),1,null,null)
Insert into Employees Values ('Sowmiya','A','Not Needed','Not Needed','Not Needed','9597826727',null,CONVERT(datetime,RIGHT(@Date,4)+LEFT(@Date,2)+SUBSTRING(@Date,3,2)),null, GETDATE(),1,null,null)
Insert into Employees Values ('Susila','A','Not Needed','Not Needed','Not Needed','7904026380',null,CONVERT(datetime,RIGHT(@Date,4)+LEFT(@Date,2)+SUBSTRING(@Date,3,2)),null, GETDATE(),1,null,null)

Insert into EmployeeLoginDetails Values (1,'NA','NA',1,GETDATE(),0,GETDATE(),1,null,null)
Insert into EmployeeLoginDetails Values (2,'NA','NA',1,GETDATE(),0,GETDATE(),1,null,null)
Insert into EmployeeLoginDetails Values (3,'NA','NA',1,GETDATE(),0,GETDATE(),1,null,null)
Insert into EmployeeLoginDetails Values (4,'NA','NA',1,GETDATE(),0,GETDATE(),1,null,null)
Insert into EmployeeLoginDetails Values (5,'NA','NA',1,GETDATE(),0,GETDATE(),1,null,null)
Insert into EmployeeLoginDetails Values (6,'NA','NA',1,GETDATE(),0,GETDATE(),1,null,null)
Insert into EmployeeLoginDetails Values (7,'NA','NA',1,GETDATE(),0,GETDATE(),1,null,null)

Delete from dbo.VehicleBookingAllotment 
Delete from dbo.VehicleInventoryStatus
Delete from  VehicleInventory
Delete from VehicleInfo 
DBCC CHECKIDENT ('VehicleBookingAllotment', RESEED, 1);
DBCC CHECKIDENT ('VehicleInventoryStatus', RESEED, 1);
DBCC CHECKIDENT ('VehicleInventory', RESEED, 1);
DBCC CHECKIDENT ('VehicleInfo', RESEED, 1);

--Select  * from VehicleInfo

Insert into VehicleInfo Values (1,'B812 & B822','RAY Z',52143,6521,2060,61279,0,0,0,GETDATE(), 1, null,null)
Insert into VehicleInfo Values (1,'BP11',	'ALPHA - Drum',	53556,	6634,	2091,	62836,0,0,0,GETDATE(), 1, null,null)
Insert into VehicleInfo Values (1,'BP12',	'ALPHA - Disc',	56816,	6895,	2165,	 	66431,0,0,0,GETDATE(), 1, null,null)
Insert into VehicleInfo Values (1,'2SP2',	'FASCINO',			56415,	6863,	2155,	 	65988,0,0,0,GETDATE(), 1, null,null)
Insert into VehicleInfo Values (1,'B623',	'RAY ZR (Drum)',	54777,	6732,	2119,	 	64183,0,0,0,GETDATE(), 1, null,null)
Insert into VehicleInfo Values (1,'B624',	'RAY ZR (Disc)',	57224,	6928,	2173,	 	66880,0,0,0,GETDATE(), 1, null,null)
Insert into VehicleInfo Values (2,'B441 / B445',	'SALUTO RX',	47734,	6499,	1963,	 	56751,0,0,0,GETDATE(), 1, null,null)
Insert into VehicleInfo Values (2,'2LP5',	'SALUTO 125 DRUM', 	55768,	7461,	2141,	 	66147,0,0,0,GETDATE(), 1, null,null)
Insert into VehicleInfo Values (2,'2LPA',	'SALUTO 125 DRUM - LE', 	56752,	7540,	2163,	 	67232,0,0,0,GETDATE(), 1, null,null)
Insert into VehicleInfo Values (2,'2LP8',	'SALUTO Disc',	58234,	7659,	2195,	 	68865,0,0,0,GETDATE(), 1, null,null)
Insert into VehicleInfo Values (2,'2LPB',	'SALUTO Disc - LE',	59214,	7737,	2242,	 	69970,0,0,0,GETDATE(), 1, null,null)
Insert into VehicleInfo Values (2,'2PY4',	'SZ RR',	68027,	8292,	2412,	 	79508,0,0,0,GETDATE(), 1, null,null)
Insert into VehicleInfo Values (2,'2PY5',	'SZ RR - LE',	69027,	8372,	2435,	 	80611,0,0,0,GETDATE(), 1, null,null)
Insert into VehicleInfo Values (2,'2GS1/2GS5',	'FZ - FI',	81264,	8951,	2705,	 	93697,0,0,0,GETDATE(), 1, null,null)
Insert into VehicleInfo Values (2,'2GS4/2GS6',	'FZ S - FI',	83266,	9111,	2750,	 	95904,0,0,0,GETDATE(), 1, null,null)
Insert into VehicleInfo Values (2,'2GS3/2GS7',	'FZ S - FI LE',	84236,	9189,	2771,	 	96973,0,0,0,GETDATE(), 1, null,null)
Insert into VehicleInfo Values (2,'2WS2/ 2WS3',	'FAZER - FI',	88367,	9519,	2863,	 	101526,0,0,0,GETDATE(), 1, null,null)
Insert into VehicleInfo Values (2,'2FB8',	'R 15',	119062,	12175,	3543,	 	135557,0,0,0,GETDATE(), 1, null,null)
Insert into VehicleInfo Values (2,'2FB9',	'R 15',	119062,	12175,	3543,	 	135557,0,0,0,GETDATE(), 1, null,null)
Insert into VehicleInfo Values (2,'BB72',	'R15S',	115970,	11928,	3473,	 	132148,0,0,0,GETDATE(), 1, null,null)
Insert into VehicleInfo Values (2,'B971','FZ25',	120559,	12295,	3886,	 	137517,0,0,0,GETDATE(), 1, null,null)

Insert into VehicleInventoryStatusType Values('Returned', GETDATE(),1, null,null)
Insert into SparePartsInventoryStatusType Values('Returned', GETDATE(),1, null,null)
