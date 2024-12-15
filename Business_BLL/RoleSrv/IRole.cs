using Data_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_BLL.RoleSrv
{
    public interface  IRole
    {
        Task<IEnumerable<Role>> GetAll();
        Task<Role> GetById(int id);
        Task Add(Role role);
        Task Delete(int id);
    }
}
