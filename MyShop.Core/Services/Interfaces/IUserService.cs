using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Core.ViewModels;
using MyShop.DataLayer.Entities;

namespace MyShop.Core.Services.Interfaces
{
    public interface IUserService
    {
        bool IsExistUserName(string userName);
        bool IsExistEmail(string email);
        User LoginUser(LoginViewModel login);
        SideBarAdminPanelViewModel GetAdminPanelSideBarData(string username);
    }
}
