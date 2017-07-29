--Add remarks column for vehicleinventorystatus
ALTER TABLE dbo.VehicleInventoryStatus
ADD Remarks nvarchar(max) default ''

ALTER TABLE dbo.SparePartsInventoryStatus
ADD Remarks nvarchar(max) default ''
--Select * from VehicleInventoryStatus
--Select  * from SparePartsInventoryStatus