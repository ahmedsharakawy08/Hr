using Hr.Models;
using Hr.Repositories;
using Hr.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.Interfaces
{
    public interface IEmployee : IGenecricRepository<Employee>
    {
        public bool IdExists(long id);
        public List<EmployeeVM> GetallwithDeptName();
    }
}
