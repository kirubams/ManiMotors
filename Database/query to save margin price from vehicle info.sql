Select * from VehicleInventory

Select * from vehicleinfo

UPDATE vi
SET vi.ExShowroomPrice = vin.ExShowRoomPrice,
vi.LT_RT_OtherExp = vin.LT_RT_OtherExp,
vi.InsurancePrice = vin.InsurancePrice,
vi.WarrantyPrice = vin.WarrantyPrice,
vi.MarginPrice = vin.MarginPrice,
vi.FullCashPercentMargin = vin.[70PercentMargin],
vi.CreditPercentMargin = vin.[50PercentMargin],
vi.OnRoadPrice = vin.OnRoadPrice
FROM VehicleInventory AS vi
INNER JOIN VehicleInfo AS vin 
       ON vi.VehicleInfoID = vin.VehicleInfoID
