using MM.DataLayer;
using MM.Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.BusinessLayer.Reports
{
    public class CustomerEnquiryReportBL
    {
        public List<CustomerEnquiryDTO> GetAllCustomerEnquiry()
        {
            List<CustomerEnquiryDTO> dto = new List<CustomerEnquiryDTO>();
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
                           select new CustomerEnquiryDTO
                           {
                               CustomerEnquiryID = ce.CustomerEnquiryID,
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
                               VehicleStatusDescription = vs.Description,
                               CreatedDate = ce.CreatedDate,
                               CreatedBy = ce.Createdby,
                               ModifiedDate = ce.ModifiedDate,
                               ModifiedBy = ce.Modifiedby
                           }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dto;
        }
    }
}
