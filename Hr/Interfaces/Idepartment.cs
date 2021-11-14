using Hr.Models;
using Hr.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.Interfaces
{
    public interface Idepartment : IGenecricRepository<Department>
    {
        public bool IdExists(long id);
        public bool departentInUse(long id);
    }
}
