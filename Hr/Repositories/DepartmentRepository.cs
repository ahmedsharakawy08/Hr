using Hr.Interfaces;
using Hr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.Repositories
{
    public class DepartmentRepository : GenericRepositoryAsync<Department>, Idepartment
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public bool IdExists(long id)
        {
            var found = _context.   Department.Find(id);
            if (found == null)
            {
                return false;
            }
            else
            {
                return true;


            }
        }
        public bool departentInUse(long id)
        {
           var data = _context.Employee.Where(x => x.DeptId == id).FirstOrDefault();
            if(data==null)
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