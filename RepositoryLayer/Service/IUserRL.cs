using ModelLayer.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Service
{
    public interface IUserRL
    {
        public EmpModel AddEmployee(EmpModel empModel);
        public IEnumerable<EmpModel> GetAllEmployees();
        public EmpModel GetEmployeeData(int? id);
        public EmpModel UpdateEmployee(EmpModel empModel);
        public bool DeleteEmployee(int? id);
    }
}
