using Hr.Interfaces;
using Hr.Models;
using Hr.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.Repositories
{
    public class EmployeeRepository : GenericRepositoryAsync<Employee>, IEmployee
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public List<EmployeeVM> GetallwithDeptName()
        {
            var data = (from Employee in _context.Employee
                       join  Dept in _context.Department on Employee.DeptId equals Dept.Id into Details
                        from m in Details.DefaultIfEmpty()



                        select new EmployeeVM { DeptName=m.Name,Id=Employee.Id,title=Employee.title,Name=Employee.Name,EmpNumber=Employee.EmpNumber }).ToList();
            
            return data;
        }

        public bool IdExists(long id)
        {
            var found = _context.Employee.Find(id);
            if (found == null)
            {
                return false;
            }
            else
            {
                return true;


            }
        }
   
    }
}
 

