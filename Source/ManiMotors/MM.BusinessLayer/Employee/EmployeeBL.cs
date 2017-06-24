using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MM.Model.Employee;
using MM.DataLayer;

namespace MM.BusinessLayer.Employee
{
    public class EmployeeBL
    {
        public List<EmployeeDTO> GetEmployeelist()
        {
            List<EmployeeDTO> employeelist = new List<EmployeeDTO>();
            try
            {
                using (var entity = new ManiMotorsEntities1())
                {
                    employeelist = (from e in entity.Employees
                                    join ed in entity.EmployeeLoginDetails on e.EmployeeID equals ed.EmployeeID
                                    where ed.IsActive == true  && ed.IsLocked == false
                                    select new EmployeeDTO
                                    {
                                        EmployeeID = e.EmployeeID,
                                        FirstName = e.FirstName,
                                        LastName = e.LastName,
                                        Address1 = e.Address1,
                                        Address2 = e.Address2,
                                        Email = e.Email,
                                        ContactNo = e.ContactNo,
                                        StartDate = e.StartDate,
                                        EndDate = e.EndDate,
                                        IsActive = ed.IsActive,
                                        IsLocked = ed.IsLocked,
                                        CreatedDate = e.CreatedDate,
                                        CreatedBy = e.Createdby,
                                        ModifiedBy = e.Modifiedby,
                                        ModifiedDate = e.ModifiedDate
                                    }).ToList();
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
            return employeelist;
        }
    }
}

