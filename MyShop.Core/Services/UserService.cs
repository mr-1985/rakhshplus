using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyShop.Core.Convertors;
using MyShop.Core.Generators;
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

        public bool IsExistMobile(string mobile)
        {
            return _context.Users.Any(u => u.Mobile == mobile);
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
                //Avatar = u.UserAvatar
            }).Single();
        }

        public int GetUserIdByUserName(string userName)
        {
            return _context.Users.Single(u => u.UserName == userName).UserId;
        }

        public User GetUserByUserName(string username)
        {
            return _context.Users.SingleOrDefault(u => u.UserName == username);
        }

        public List<User> GetAllUsers()
        {
            //return _context.Users.Where(u => u.IsDelete == false).ToList();

            var result = from user in _context.Users
                join city in _context.City
                    on user.City equals city.CityId.ToString()

                join province in _context.Province
                    on user.Province equals province.ProvinceId.ToString()
                where user.IsDelete == false
                select (new User()
                {
                    City = city.CityName,
                    Province = province.ProvinceName,
                    Address = user.Address,
                    CreateDate = user.CreateDate,
                    Email = user.Email,
                    UserId = user.UserId,
                    PostalCode = user.PostalCode,
                    Tell = user.Tell,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Mobile = user.Mobile
                });
            return result.ToList();
        }

        public UsersDocument GetDocumentByUserId(int userId)
        {
            return _context.UsersDocuments.SingleOrDefault(a => a.UserId == userId);
        }

        public int AddUserFromAdmin(CreateUserViewModel model)
        {
            User user = new User();
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.UserName = model.UserName.Trim();
            user.CreateDate = DateTime.Now;
            user.PostalCode=model.PostalCode;
            user.IsActive = model.IsActive;
            user.Mobile = model.Mobile.Trim();
            user.Password = PasswordHelper.EncodePasswordMd5(model.Password);
            user.BirthDate = DateTime.Now;
            user.Gender = model.Gendre;
            user.FatherName=model.FatherName;
            user.Province = model.Province;
            user.City = model.City;
            user.Address=model.Address;
            user.MahaleSodour=model.MahaleSodour;
            user.NationalCode=model.NationalCode;
            user.ShomareShenasnameh=model.ShomareShenasname;
            user.Tell=model.Phone;
            return AddUser(user);
        }

        public int AddUser(User user)
        {
            user.CreateDate=DateTime.Now;
            
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.UserId;
        }

        public int AddUserDocument(int userId, string fileName, string term)
        {
            var result = _context.UsersDocuments.FirstOrDefault(p => p.UserId == userId);
            if (result != null)
            {
                if (term == "PersonalImage")
                {
                    if (result.PersonalImage != "avatar.jpg")
                    {
                        string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserDocument", result.PersonalImage);
                        if (File.Exists(deleteimagePath))
                        {
                            File.Delete(deleteimagePath);
                        }
                    }
                    result.PersonalImage = fileName;
                }

                if (term == "FrontNationalImage")
                {
                    if (result.PersonalImage != "avatar.jpg")
                    {
                        string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserDocument", result.FrontNationalImage);
                        if (File.Exists(deleteimagePath))
                        {
                            File.Delete(deleteimagePath);
                        }
                    }
                    result.FrontNationalImage = fileName;
                }

                if (term == "BackNationalImage")
                {
                    if (result.PersonalImage != "avatar.jpg")
                    {
                        string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserDocument", result.BackNationalImage);
                        if (File.Exists(deleteimagePath))
                        {
                            File.Delete(deleteimagePath);
                        }
                    }
                    result.BackNationalImage = fileName;
                }

                if (term == "FrontShenasnamehImage")
                {
                    if (result.PersonalImage != "avatar.jpg")
                    {
                        string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserDocument", result.FrontShenasnamehImage);
                        if (File.Exists(deleteimagePath))
                        {
                            File.Delete(deleteimagePath);
                        }
                    }
                    result.FrontShenasnamehImage = fileName;
                }

                if (term == "DescriptionShenasnamehImage")
                {
                    if (result.PersonalImage != "avatar.jpg")
                    {
                        string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserDocument", result.DescriptionShenasnamehImage);
                        if (File.Exists(deleteimagePath))
                        {
                            File.Delete(deleteimagePath);
                        }
                    }
                    result.DescriptionShenasnamehImage = fileName;
                }

                result.CreateDate = DateTime.Now;
                
                _context.UsersDocuments.Update(result);
                _context.SaveChanges();
                return 1;
            }
            else
            {
                UsersDocument document = new UsersDocument();
                document.UserId = userId;
                document.CreateDate = DateTime.Now;

                if (term == "PersonalImage")
                {
                    document.PersonalImage = fileName;
                }

                if (term == "FrontNationalImage")
                {
                    document.FrontNationalImage = fileName;
                }

                if (term == "BackNationalImage")
                {
                    document.BackNationalImage = fileName;
                }

                if (term == "FrontShenasnamehImage")
                {
                    document.FrontShenasnamehImage = fileName;
                }

                if (term == "DescriptionShenasnamehImage")
                {
                    document.DescriptionShenasnamehImage = fileName;
                }

                if (document.PersonalImage == null)
                {
                    document.PersonalImage = "avatar.jpg";
                }

                if (document.FrontNationalImage == null)
                {
                    document.FrontNationalImage = "avatar.jpg";
                }

                if (document.BackNationalImage == null)
                {
                    document.BackNationalImage = "avatar.jpg";
                }

                if (document.FrontShenasnamehImage == null)
                {
                    document.FrontShenasnamehImage = "avatar.jpg";
                }

                if (document.DescriptionShenasnamehImage == null)
                {
                    document.DescriptionShenasnamehImage = "avatar.jpg";
                }
                _context.UsersDocuments.Add(document);
                _context.SaveChanges();
                return 1;
            }
        }

        public User GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }

        public void UpdateUser(User user)
        {

            user.CreateDate=DateTime.Now;
            user.IsActive = true;
            if (!string.IsNullOrEmpty(user.Password))
            {
                user.Password = PasswordHelper.EncodePasswordMd5(user.Password);
            }

            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            var user = GetUserById(userId);
            user.IsDelete = true;
            UpdateUser(user);
        }

        public InformationUserPanelViewModel GetUserPanelInformation(string userName)
        {
            var user = GetUserByUserName(userName);
            InformationUserPanelViewModel information = new InformationUserPanelViewModel();
            information.UserName = user.UserName;
            information.FirstName = user.FirstName;
            information.LastName = user.LastName;
            information.Email = user.Email;
            information.RegisterDate = user.CreateDate;
            information.Mobile = user.Mobile;
           

            return information;
        }

        public bool CompareOldPassword(string username, string oldPassword)
        {
            string hashOldPassword = PasswordHelper.EncodePasswordMd5(oldPassword);
            return _context.Users.Any(u => u.UserName == username && u.Password == hashOldPassword);
        }

        public bool ComparePasswords(string password, string rePassword)
        {
            if (password == rePassword)
            {
                return true;
            }

            return false;
        }

        public void ChangeUserPassword(string username, string newPassword)
        {
            var user = GetUserByUserName(username);
            user.Password = PasswordHelper.EncodePasswordMd5(newPassword);
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public User GetUserForShowInProfile(string username)
        {
            return _context.Users.Include(u=>u.UsersDocument).FirstOrDefault(u => u.UserName == username);
        }

        public EditProfileViewModel GetDataForEditProfileUser(string username)
        {
            return _context.Users.Where(u => u.UserName == username).Select(u => new EditProfileViewModel()
            {
                UserId = u.UserId,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Mobile = u.Mobile,
                Email = u.Email,
                UserName = u.UserName,

            }).Single();
        }

        public void EditProfile(string username, EditProfileViewModel profile)
        {
            var user = GetUserByUserName(username);
            user.UserName = profile.UserName;
            user.Email = profile.Email;
            user.FirstName= profile.FirstName;
            user.LastName= profile.LastName;
            user.Mobile= profile.Mobile;
           
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}
