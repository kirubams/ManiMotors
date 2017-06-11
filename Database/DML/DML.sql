--Role Static Types
SET IDENTITY_INSERT MMRole ON

Insert into MMRole(RoleID,Description, CreatedDate, Createdby, ModifiedDate, Modifiedby) Values (1, 'proprietor',GETDATE(),1,null,null)
Insert into MMRole(RoleID,Description, CreatedDate, Createdby, ModifiedDate, Modifiedby) Values (2, 'SuperUser',GETDATE(),1,null,null)
Insert into MMRole(RoleID,Description, CreatedDate, Createdby, ModifiedDate, Modifiedby) Values (3, 'Admin',GETDATE(),1,null,null)
Insert into MMRole(RoleID,Description, CreatedDate, Createdby, ModifiedDate, Modifiedby) Values (4, 'SalesExecutive',GETDATE(),1,null,null)
Insert into MMRole(RoleID,Description, CreatedDate, Createdby, ModifiedDate, Modifiedby) Values (5, 'InventoryStockist',GETDATE(),1,null,null)
Insert into MMRole(RoleID,Description, CreatedDate, Createdby, ModifiedDate, Modifiedby) Values (6, 'Mechanic',GETDATE(),1,null,null)

SET IDENTITY_INSERT MMRole OFF
--End Role

--Employee Insert-----

Insert into Employees Values ('Kirubanandhan','Subramaniam','7559 Bellingrath Dr','Frisco,Texas,75035', 'manimotocorp@gmail.com', '0014692698733',null, GETDATE(), null,GETDATE(),1,null,null)
Insert into EmployeeRole Values (1,1,GETDATE(),1,null,null)

--End Employee Insert

--VehicleTypes Insert
SET IDENTITY_INSERT VehicleType ON
Insert into VehicleType(VehicleTypeID, Description,CreatedDate, Createdby, ModifiedDate, Modifiedby)  Values(1, 'Scooter',GETDATE(),1,null,null)
Insert into VehicleType(VehicleTypeID, Description,CreatedDate, Createdby, ModifiedDate, Modifiedby)  Values(2, 'MotorBike',GETDATE(),1,null,null)
SET IDENTITY_INSERT VehicleType OFF
--End VehicleTypes Insert

--VehicleInventoryStatusType Insert

Insert into VehicleInventoryStatusType Values('InStock',GETDATE(),1,null,null)
Insert into VehicleInventoryStatusType Values('Alloted',GETDATE(),1,null,null)
Insert into VehicleInventoryStatusType Values('Delivered',GETDATE(),1,null,null)

--End VehicleTypes Insert

--SparePartsType Insert
SET IDENTITY_INSERT SparePartsType ON
Insert into SparePartsType(SparePartsTypeID, Description,CreatedDate, Createdby, ModifiedDate, Modifiedby)  Values(1, 'MudGuard',GETDATE(),1,null,null)
Insert into SparePartsType(SparePartsTypeID, Description,CreatedDate, Createdby, ModifiedDate, Modifiedby)  Values(2, 'Mirror',GETDATE(),1,null,null)
SET IDENTITY_INSERT SparePartsType OFF
--End VehicleTypes Insert

--SparePartsInventoryStatusType Insert

Insert into SparePartsInventoryStatusType Values('InStock',GETDATE(),1,null,null)
Insert into SparePartsInventoryStatusType Values('Alloted',GETDATE(),1,null,null)
Insert into SparePartsInventoryStatusType Values('Delivered',GETDATE(),1,null,null)

--End SparePartsInventoryStatusTy Insert