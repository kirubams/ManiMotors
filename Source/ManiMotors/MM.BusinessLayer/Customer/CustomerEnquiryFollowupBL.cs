using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MM.DataLayer;
using MM.Model.Customer;

namespace MM.BusinessLayer.Customer
{
    public class CustomerEnquiryFollowupBL
    {
        public List<CustomerEnquiryFollowupDTO> GetCustomerEnquiryFollowup(DateTime startDate, DateTime endDate, int statusId)
        {
            List<CustomerEnquiryFollowupDTO> lst = new List<CustomerEnquiryFollowupDTO>();
            try
            {
                using (var entity = new ManiMotorsEntities1())
                {
                    lst = (from ce in entity.CustomerEnquiries
                           join cef in entity.CustomerEnquiryFollowUps on ce.CustomerEnquiryID equals cef.CustomerEnquiryID
                           join vs in entity.VehicleSalesStatus on ce.VehicleStatusID equals vs.VehicleSalesStatusID
                           join vi in entity.VehicleInfoes on ce.Model1 equals vi.VehicleInfoID
                           join c in entity.Customers on ce.CustomerID equals c.CustomerID
                           where cef.FollowUpDate >= startDate && cef.FollowUpDate <= endDate && vs.VehicleSalesStatusID == statusId
                           && cef.IsLatest == true
                           select new CustomerEnquiryFollowupDTO
                           {
                               CustomerName = c.Name,
                               CustomerId = c.CustomerID,
                               ModelName = vi.ModelName,
                               CustomerEnquiryId = ce.CustomerEnquiryID,
                               FollowUpDate = cef.FollowUpDate,
                               StatusDescription = vs.Description,
                               StatusId = vs.VehicleSalesStatusID,
                               CustomerMobileNo = c.ContactNo,
                               Description = cef.Description
                           }).ToList();
       
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return lst;
        }


        public CustomerEnquiryFollowupDTO GetCustomerEnquiryFollowupbyId(int CustomerEnquiryid)
        {
            CustomerEnquiryFollowupDTO lst = new CustomerEnquiryFollowupDTO();
            try
            {
                using (var entity = new ManiMotorsEntities1())
                {
                    lst = (from ce in entity.CustomerEnquiries
                           join cef in entity.CustomerEnquiryFollowUps on ce.CustomerEnquiryID equals cef.CustomerEnquiryID
                           join vs in entity.VehicleSalesStatus on ce.VehicleStatusID equals vs.VehicleSalesStatusID
                           join vi in entity.VehicleInfoes on ce.Model1 equals vi.VehicleInfoID
                           join c in entity.Customers on ce.CustomerID equals c.CustomerID
                           where cef.CustomerEnquiryID == CustomerEnquiryid
                           && cef.IsLatest == true
                           select new CustomerEnquiryFollowupDTO
                           {
                               CustomerName = c.Name,
                               CustomerId = c.CustomerID,
                               ModelName = vi.ModelName,
                               CustomerEnquiryId = ce.CustomerEnquiryID,
                               FollowUpDate = cef.FollowUpDate,
                               StatusDescription = vs.Description,
                               StatusId = vs.VehicleSalesStatusID,
                               CustomerMobileNo = c.ContactNo,
                               Description = cef.Description
                           }).FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lst;
        }
    }
}
