using ERPProject.Models;
using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Entity;
using ERPProject.ViewModels;
using AutoMapper;
using ERPProject.Infrastructure;

namespace ERPProject.Infrastructure
{
    public class CustomMembershipProvider: MembershipProvider
    {
        private ERPProjectDataContext db;

        public CustomMembershipProvider()
        {
            db = new ERPProjectDataContext();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline) // get user
        {
            var user = GetByUserName(username);
            var userModel = new UserModel();
            Mapper.CreateMap<AccUser, UserModel>()
                .ForMember(dest => dest.UserRoles, opt => opt.MapFrom(src => src.UserRoles));
            Mapper.CreateMap<AccUserRoles, UserRoleModel>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName));
            Mapper.Map(user, userModel);
            return new CustomMembershipUser(userModel);
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password) // validate user
        {
            var userModel = GetByUserName(username);
            if (userModel.UserName == null)
                return false;
            else if (userModel.IsApproved == false)
                return false;

            return password == userModel.Password;            

        }
        public AccUser GetByUserName(string userName)
        {
            //  var user = DataContext.AccUsers.FirstOrDefault(x => x.UserName == userName);
            var user = db.AccUsers.Include(x => x.UserRoles.Select(t => t.Role)).FirstOrDefault(x => x.UserName == userName);
            db.Entry(user).Reload();

            //db.Entry(user).Collection(x => x.UserRoles).Load();
            //var user = DataContext.AccUsers.FirstOrDefault(x => x.UserName == userName);
            return user;
        }

    }
}