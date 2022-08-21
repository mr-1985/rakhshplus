using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Core.Convertors;
using MyShop.Core.Security;
using MyShop.Core.Services.Interfaces;
using MyShop.Core.ViewModels;
using MyShop.DataLayer.Context;
using MyShop.DataLayer.Entities;

namespace MyShop.Core.Services
{
    public class UserService:IUserService
    {
        private MyShopContext _context;

        public UserService(MyShopContext context)
        {
            _context = context;
        }
        public bool IsExistUserName(string userName)
        {
            return _context.Users.Any(u => u.UserName == userName);
        }

        public bool IsExistEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public User LoginUser(LoginViewModel login)
        {
            string password = PasswordHelper.EncodePasswordMd5(login.Password);
            // var t= _context.Users.FirstOrDefault(u => u.UserName == login.UserName && u.Password == password);
            return _context.Users.FirstOrDefault(u => u.UserName == login.UserName.Trim() && u.Password == password);
        }

        public SideBarAdminPanelViewModel GetAdminPanelSideBarData(string username)
        {
            return _context.Users.Where(u => u.UserName == username).Select(u => new SideBarAdminPanelViewModel()
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Avatar = u.UserAvatar
            }).Single();
        }
    }
}
