--Select * from Import
Create table #finaltemp
(query varchar(2000))

Declare @ID int 
Select top 1 @ID =ID from Import where ID is not null and Looper = 0 order by ID

While(@ID <> 0 and @ID is not null)
Begin
print 'ID-'+ convert(varchar(10),@ID)
Declare @count int

Select @count = QUANTITY from Import where ID = @ID
print @count

While(@count >= 1)
begin
Declare @query varchar(8000)=''
Declare @sparepartsInfoId int
Declare @IdentificationNo varchar(255)
Declare @OtherDesc varchar(255)
Declare @MarginPrice float
Declare @ShowRoomPrice int

Select @sparepartsInfoId = SparePartsInfoID from Import where ID = @ID
Select @IdentificationNo = SparePartsType + '--' + CONVERT(varchar(10),@count) from Import where ID = @ID
Select @OtherDesc = 'Transfer from Niresh'
Select @MarginPrice = Price*0.125 from Import where ID = @ID
Select @ShowRoomPrice = Price from Import where ID = @ID
Insert into #finaltemp
Select 'Insert into SparePartsInventory Values(' + CONVERT(varchar(10),@sparepartsInfoId) +',' + ''''+ @IdentificationNo +'''' + ','+ ''''+ @OtherDesc +'''' + ',' + 'GetDATE(),1,null,null,' + CONVERT(varchar(10),@MarginPrice) +',' +CONVERT(varchar(10),@ShowRoomPrice)+')'

set @count = @count - 1

end
set @count = 0
Update Import Set Looper =1 where ID = @ID
Set @ID = 0
Select top 1 @ID =ID from Import where ID is not null and Looper = 0 order by ID
print 'IDafterupdate-'+ convert(varchar(10),@ID)

end

Select * from  #finaltemp

Drop table #finaltemp



