using ModelLayer.Service;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class UserBL : IUserBL
    {
        private readonly IUserRL iuserRL;

        public UserBL(IUserRL iuserRL)
        {
            this.iuserRL = iuserRL;
        }

        public EmpModel AddEmployee(EmpModel empModel)
        {
            try
            {
                return iuserRL.AddEmployee(empModel);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public IEnumerable<EmpModel> GetAllEmployees()
        {

            try
            {
                return iuserRL.GetAllEmployees();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public EmpModel GetEmployeeData(int? id)
        {
            try
            {
                return iuserRL.GetEmployeeData(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public EmpModel UpdateEmployee(EmpModel empModel)
        {
            try
            {
                return iuserRL.UpdateEmployee(empModel);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool DeleteEmployee(int? id)
        {
            try
            {
                return iuserRL.DeleteEmployee(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
