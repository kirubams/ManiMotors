using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MM.Model.Customer;
using MM.DataLayer;

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
    }
}
