Alter table VehicleInfo
Add WarrantyPrice int default 0
Go
Alter table VehicleInventory 
Add ExShowroomPrice int 
Go
Alter table VehicleInventory 
Add LT_RT_OtherExp int 
Go
Alter table VehicleInventory 
Add InsurancePrice int 
Go
Alter table VehicleInventory 
Add WarrantyPrice int 
Go
Alter table VehicleInventory 
Add MarginPrice int 
Go
Alter table VehicleInventory 
Add CreditPercentMargin int 
Go

Alter table VehicleInventory 
Add OnRoadPrice int 
Go

Alter table VehicleInventory 
Add FullCashPercentMargin int 
Go
Alter table dbo.SparePartsInventory
Add MarginPrice int 
Go
Alter table dbo.sparepartsinventory
Add ShowroomPrice int
Go

Insert into SparePartsInventoryStatusType Values('NireshTransfer',GETDATE(),1,null,null) 
Go


