using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.DataLayer.Entities;

namespace MyShop.Core.Services.Interfaces
{
    public interface IPermissionService
    {
        List<Role> GetRoles();
        List<Role> GetFilterRoles(int roleId);
        void AddRolesToUser(List<int> roleIds, int userId);
    }
}
