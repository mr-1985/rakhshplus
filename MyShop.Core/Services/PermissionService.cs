using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Core.Services.Interfaces;
using MyShop.DataLayer.Context;
using MyShop.DataLayer.Entities;

namespace MyShop.Core.Services
{
    public class PermissionService:IPermissionService
    {
        private MyShopContext _context;

        public PermissionService(MyShopContext context)
        {
            _context = context;
        }
        public List<Role> GetRoles()
        {
            return _context.Roles.Where(R => R.IsDelete == false).ToList();
        }

        public List<Role> GetFilterRoles(int roleId)
        {

            var query = _context.Roles;
            return query.ToList();
        }

        public void AddRolesToUser(List<int> roleIds, int userId)
        {
            foreach (int roleId in roleIds)
            {
                _context.UserRoles.Add(new UserRole()
                {
                    RoleId = roleId,
                    UserId = userId
                });

            }

            _context.SaveChanges();
        }
    }
}
