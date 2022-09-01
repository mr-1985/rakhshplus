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
        bool IsExistMobile(string mobile);
        User LoginUser(LoginViewModel login);
        SideBarAdminPanelViewModel GetAdminPanelSideBarData(string username);
        int GetUserIdByUserName(string userName);
        User GetUserByUserName(string username);
        List<User> GetAllUsers();
        UsersDocument GetDocumentByUserId(int userId);
        int AddUserFromAdmin(CreateUserViewModel model);
        int AddUser(User user);
        int AddUserDocument(int userId, string fileName, string term);
        User GetUserById(int userId);
        void UpdateUser(User user);
        void DeleteUser(int userId);
        InformationUserPanelViewModel GetUserPanelInformation(string userName);
        bool CompareOldPassword(string username, string oldPassword);
        bool ComparePasswords(string password, string rePassword);
        void ChangeUserPassword(string username, string newPassword);
        User GetUserForShowInProfile(string username);
        EditProfileViewModel GetDataForEditProfileUser(string username);
        void EditProfile(string username, EditProfileViewModel profile);
    }
}
