using MM.DataLayer;
using MM.Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace MM.BusinessLayer.Customer
{
    public class CustomerBL
    {
        public List<CustomerDTO> GetAllCustomers()
        {
            List<CustomerDTO> lstCustomer = new List<CustomerDTO>();
            try
            {
                using (var entities = new ManiMotorsEntities1())
                {
                    var custlist = entities.Customers.ToList();
                    foreach (var cust in custlist)
                    {
                        CustomerDTO dto = new CustomerDTO();
                        dto.CustomerID = cust.CustomerID;
                        dto.Name = cust.Name;
                        dto.Address1 = cust.Address1;
                        dto.Address2 = cust.Address2;
                        dto.Email = cust.Email;
                        dto.ContactNo = cust.ContactNo;
                        dto.Age = cust.Age ?? 0;
                        dto.DOB = cust.DateOfBirth ?? DateTime.Now;
                        dto.Gender = cust.Gender;
                        dto.Occupation = cust.Occupation;
                        dto.AreaName = cust.AreaName;
                        dto.CreatedDate = cust.CreatedDate ?? DateTime.Now;
                        dto.CreatedBy = cust.Createdby ?? 1;
                        dto.ModifiedDate = cust.ModifiedDate ?? DateTime.Now;
                        dto.ModifiedBy = cust.Modifiedby ?? 1;
                        lstCustomer.Add(dto);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstCustomer;

        }

        public CustomerDTO GetCustomer(int CustomerId)
        {
            CustomerDTO dto = new CustomerDTO();

            try
            {
                using (var entities = new ManiMotorsEntities1())
                {
                    var cust = entities.Customers.FirstOrDefault(c => c.CustomerID == CustomerId);
                    dto.CustomerID = cust.CustomerID;
                    dto.Name = cust.Name;
                    dto.Address1 = cust.Address1;
                    dto.Address2 = cust.Address2;
                    dto.Email = cust.Email;
                    dto.ContactNo = cust.ContactNo;
                    dto.Age = cust.Age ?? 0;
                    dto.DOB = cust.DateOfBirth ?? DateTime.Now;
                    dto.Gender = cust.Gender;
                    dto.Occupation = cust.Occupation;
                    dto.AreaName = cust.AreaName;
                    dto.CreatedDate = cust.CreatedDate ?? DateTime.Now;
                    dto.CreatedBy = cust.Createdby ?? 1;
                    dto.ModifiedDate = cust.ModifiedDate ?? DateTime.Now;
                    dto.ModifiedBy = cust.Modifiedby ?? 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dto;

        }

        public bool DeleteCustomer(int CustomerID)
        {
            var flag = false;
            try
            {
                using (var entities = new ManiMotorsEntities1())
                {
                    entities.Customers.Remove(entities.Customers.FirstOrDefault(v => v.CustomerID == CustomerID));
                    entities.SaveChanges();
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return flag;

        }

        public bool SaveCustomer(CustomerDTO cust, string mode)
        {
            var flag = false;
            try
            {
                using (var entities = new ManiMotorsEntities1())
                {
                    if (mode == "EDIT")
                    {
                        var dto = entities.Customers.FirstOrDefault(v => v.CustomerID == cust.CustomerID);
                        //dto.CustomerID = cust.CustomerID;
                        dto.Name = cust.Name;
                        dto.Address1 = cust.Address1;
                        dto.Address2 = cust.Address2;
                        dto.Email = cust.Email;
                        dto.ContactNo = cust.ContactNo;
                        dto.Age = cust.Age;
                        dto.DateOfBirth = cust.DOB;
                        dto.Gender = cust.Gender;
                        dto.Occupation = cust.Occupation;
                        dto.AreaName = cust.AreaName;
                        dto.CreatedDate = cust.CreatedDate;
                        dto.Createdby = cust.CreatedBy;
                        dto.ModifiedDate = cust.ModifiedDate;
                        dto.Modifiedby = cust.ModifiedBy;
                        entities.SaveChanges();
                        flag = true;
                    }
                    else
                    {
                        MM.DataLayer.Customer dto = new MM.DataLayer.Customer();
                        dto.Name = cust.Name;
                        dto.Address1 = cust.Address1;
                        dto.Address2 = cust.Address2;
                        dto.Email = cust.Email;
                        dto.ContactNo = cust.ContactNo;
                        dto.Age = cust.Age;
                        dto.DateOfBirth = cust.DOB;
                        dto.Gender = cust.Gender;
                        dto.Occupation = cust.Occupation;
                        dto.AreaName = cust.AreaName;
                        dto.CreatedDate = cust.CreatedDate;
                        dto.Createdby = cust.CreatedBy;
                        dto.ModifiedDate = cust.ModifiedDate;
                        dto.Modifiedby = cust.ModifiedBy;
                        entities.SaveChanges();
                        entities.Customers.Add(dto);
                        entities.SaveChanges();
                        flag = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return flag;
        }

        public bool SaveCustomerEnquiry(CustomerEnquiryDTO eDTO, CustomerEnquiryFollowupDTO efDTO, int exchangeVehicleId = 0, string mode = "")
        {
            var flag = false;
            try {
                using (var entities = new ManiMotorsEntities1())
                {

                    using (TransactionScope scope = new TransactionScope())
                    {
                        if (mode != "EDIT")
                        {
                            try
                            {
                                CustomerEnquiry dbEnt = new CustomerEnquiry()
                                {
                                    CustomerID = eDTO.CustomerID,
                                    ReferenceBy = eDTO.ReferenceBy,
                                    CashORFinance = eDTO.CashorFinance,
                                    SalesExecutive = eDTO.SalesExecutiveId,
                                    Model1 = eDTO.Model1,
                                    Model2 = eDTO.Model2,
                                    Model3 = eDTO.Model3,
                                    Color = eDTO.Color,
                                    TestDrive = eDTO.TestDrive,
                                    ExchangeVehicle = eDTO.IsExchangeVehicle,
                                    CompetitiveModel = eDTO.CompetitiveModel,
                                    VehicleStatusID = eDTO.VehicleStatusId,
                                    Createdby = eDTO.CreatedBy,
                                    CreatedDate = eDTO.CreatedDate,
                                    Modifiedby = eDTO.ModifiedBy,
                                    ModifiedDate = eDTO.ModifiedDate
                                };
                                entities.CustomerEnquiries.Add(dbEnt);
                                entities.SaveChanges();
                                var CustomerEnquiryID = dbEnt.CustomerEnquiryID;

                                var lstCustomer = entities.CustomerEnquiryFollowUps.Where(i => i.CustomerEnquiryID == CustomerEnquiryID);
                                foreach (var followup in lstCustomer)
                                {
                                    followup.IsLatest = false;
                                    entities.SaveChanges();
                                }

                                CustomerEnquiryFollowUp dbEntf = new CustomerEnquiryFollowUp()
                                {
                                    CustomerID = efDTO.CustomerId,
                                    CustomerEnquiryID = CustomerEnquiryID,
                                    Description = efDTO.Description,
                                    FollowUpDate = efDTO.FollowUpDate,
                                    Createdby = eDTO.CreatedBy,
                                    CreatedDate = eDTO.CreatedDate,
                                    Modifiedby = eDTO.ModifiedBy,
                                    ModifiedDate = eDTO.ModifiedDate,
                                    IsLatest = true,
                                };
                                entities.CustomerEnquiryFollowUps.Add(dbEntf);
                                entities.SaveChanges();
                                if (exchangeVehicleId != 0)
                                {
                                    var customerExchange = entities.CustomerExchangeVehicles.FirstOrDefault(ev => ev.CustomerExchangeVehicleID == exchangeVehicleId);
                                    customerExchange.CustomerEnquiryID = CustomerEnquiryID;
                                    entities.SaveChanges();
                                }

                                scope.Complete();
                            }
                            catch (Exception ex)
                            {
                                scope.Dispose();
                                throw;
                            }
                        }
                        else
                        {
                            try
                            {
                                var ce = entities.CustomerEnquiries.FirstOrDefault(e => e.CustomerEnquiryID == eDTO.CustomerEnquiryID);

                                ce.CustomerID = eDTO.CustomerID;
                                ce.ReferenceBy = eDTO.ReferenceBy;
                                ce.CashORFinance = eDTO.CashorFinance;
                                ce.SalesExecutive = eDTO.SalesExecutiveId;
                                ce.Model1 = eDTO.Model1;
                                ce.Model2 = eDTO.Model2;
                                ce.Model3 = eDTO.Model3;
                                ce.Color = eDTO.Color;
                                ce.TestDrive = eDTO.TestDrive;
                                ce.ExchangeVehicle = eDTO.IsExchangeVehicle;
                                ce.CompetitiveModel = eDTO.CompetitiveModel;
                                ce.VehicleStatusID = eDTO.VehicleStatusId;
                                ce.Createdby = eDTO.CreatedBy;
                                ce.CreatedDate = eDTO.CreatedDate;
                                ce.Modifiedby = eDTO.ModifiedBy;
                                ce.ModifiedDate = eDTO.ModifiedDate;
                                entities.SaveChanges();
                                
                                var lstCustomer = entities.CustomerEnquiryFollowUps.Where(i => i.CustomerEnquiryID == eDTO.CustomerEnquiryID);
                                foreach (var followup in lstCustomer)
                                {
                                    followup.IsLatest = false;
                                    entities.SaveChanges();
                                }

                                CustomerEnquiryFollowUp dbEntf = new CustomerEnquiryFollowUp()
                                {
                                    CustomerID = efDTO.CustomerId,
                                    CustomerEnquiryID = eDTO.CustomerEnquiryID,
                                    Description = efDTO.Description,
                                    FollowUpDate = efDTO.FollowUpDate,
                                    Createdby = eDTO.CreatedBy,
                                    CreatedDate = eDTO.CreatedDate,
                                    Modifiedby = eDTO.ModifiedBy,
                                    ModifiedDate = eDTO.ModifiedDate,
                                    IsLatest = true,
                                };
                                entities.CustomerEnquiryFollowUps.Add(dbEntf);
                                entities.SaveChanges();
                                scope.Complete();
                            }
                            catch (Exception ex)
                            {
                                scope.Dispose();
                                throw;
                            }

                        }

                    }
                }
                flag = true;
            }
            catch(Exception ex)
            {
                throw ex;

            }
            return flag; ;
        }

        public int SaveExchangeVehicle(CustomerExchangeDTO dto)
        {
            var exchangeId = 0;
            try
            {
                CustomerExchangeVehicle obj = new CustomerExchangeVehicle()
                {
                    CustomerId = dto.CustomerId,
                    CustomerEnquiryID = dto.CustomerEnquiryID,
                    Model = dto.Model,
                    Color = dto.Color,
                    mfgdate = dto.MfgDate,
                    EngineCondition = dto.EngineCondition,
                    OutlookCondition = dto.OutlookCondition,
                    CustomerRate = dto.CustomerRate,
                    BrokerName1 = dto.BrokerName1,
                    Mobileno1 = dto.MobileNo1,
                    Rate1 = dto.Rate1,
                    DifferenceAmount1 = dto.DifferenceAmount1,
                    BrokerName2 = dto.BrokerName2,
                    Mobileno2 = dto.MobileNo2,
                    Rate2 = dto.Rate2,
                    DifferenceAmount2 = dto.DifferenceAmount2,
                    ExchangeRemark = dto.ExchangeRemark,
                    FinalAmount = dto.FinalAmount,
                    Createdby = dto.CreatedBy,
                    CreatedDate = dto.CreatedDate,
                    Modifiedby = dto.ModifiedBy,
                    ModifiedDate = dto.ModifiedDate
                };
                using (var entities = new ManiMotorsEntities1())
                {
                    entities.CustomerExchangeVehicles.Add(obj);
                    entities.SaveChanges();
                    exchangeId = obj.CustomerExchangeVehicleID;
                }
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return exchangeId;
        }

        public List<CustomerEnquiryDTO> GetCustomerEnquiryforCustomerId(int CustomerId)
        {
            List<CustomerEnquiryDTO> lst = new List<CustomerEnquiryDTO>();
            try
            {
                using (var entity = new ManiMotorsEntities1())
                {
                    var enquirylst = entity.CustomerEnquiries.Where(c => c.VehicleStatusID == 1 && c.CustomerID == CustomerId);
                    foreach(var enquiry in enquirylst)
                    {
                        lst.Add(GetCustomerEnquiry(enquiry.CustomerEnquiryID));
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return lst;
        }


        public CustomerEnquiryDTO GetCustomerEnquiry(int enquiryId)
        {
            CustomerEnquiryDTO dto = new CustomerEnquiryDTO();
            try
            {
                using (var entity = new ManiMotorsEntities1())
                {
                    dto = (from ce in entity.CustomerEnquiries
                           join c in entity.Customers on ce.CustomerID equals c.CustomerID
                           join emp in entity.Employees on ce.SalesExecutive equals emp.EmployeeID
                           join vs in entity.VehicleSalesStatus on ce.VehicleStatusID equals vs.VehicleSalesStatusID
                           join vi1 in entity.VehicleInfoes on ce.Model1 equals vi1.VehicleInfoID into viI1
                           from viInfo1 in viI1.DefaultIfEmpty()
                           join vi2 in entity.VehicleInfoes on ce.Model2 equals vi2.VehicleInfoID into viI2
                           from viInfo2 in viI2.DefaultIfEmpty()
                           join vi3 in entity.VehicleInfoes on ce.Model3 equals vi3.VehicleInfoID into viI3
                           from viInfo3 in viI3.DefaultIfEmpty()
                           where ce.CustomerEnquiryID == enquiryId
                           select new CustomerEnquiryDTO
                           {
                               CustomerID = ce.CustomerID,
                               CustomerName = c.Name,
                               ReferenceBy = ce.ReferenceBy,
                               SalesExecutiveName = emp.FirstName,
                               SalesExecutiveId = ce.SalesExecutive,
                               Model1 = ce.Model1,
                               ModelName1 = viInfo1.ModelName,
                               Model2 = ce.Model2,
                               ModelName2 = viInfo2.ModelName,
                               Model3 = ce.Model3,
                               ModelName3 = viInfo3.ModelName,
                               Color = ce.Color,
                               TestDrive = ce.TestDrive,
                               IsExchangeVehicle = ce.ExchangeVehicle,
                               CashorFinance = ce.CashORFinance,
                               CompetitiveModel = ce.CompetitiveModel,
                               VehicleStatusId = ce.VehicleStatusID,
                               VehicleStatusDescription = vs.Description
                           }).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return dto;
        }
        
    }
}
