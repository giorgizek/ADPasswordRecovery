using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Web.Configuration;
using ADPasswordRecovery.Models;

namespace ADPasswordRecovery.Controllers
{
    public static class ADHelper
    {
        public static string MenegeableRoles;
        public static string PasswordPersistRoles;
        private static PrincipalContext GetPrincipalContextForUsers()
        {
            return new PrincipalContext(ContextType.Domain, DomainName, AdminUserName, AdminPassword);
        }
        private static PrincipalContext GetPrincipalContextForGroups()
        {
            return new PrincipalContext(ContextType.Domain, DomainName, AdminUserName, AdminPassword);
        }

        public static string DomainName;
        public static string AdminUserName;
        public static string AdminPassword;

        static ADHelper()
        {
            DomainName = WebConfigurationManager.AppSettings["DomainName"];
            AdminUserName = WebConfigurationManager.AppSettings["AdminUserName"];
            AdminPassword = WebConfigurationManager.AppSettings["AdminPassword"];
            MenegeableRoles = WebConfigurationManager.AppSettings["MenegeableRoles"];
            PasswordPersistRoles = WebConfigurationManager.AppSettings["PasswordPersistRoles"];
        }
        public static List<UserPrincipal> GetUsersForPasswordReset()
        {
            var result = new List<UserPrincipal>();

            /////////// წასაშლელია //////////////
            //List<GroupPrincipal> lbGroups = new List<GroupPrincipal>();

            //var user = UserPrincipal.FindByIdentity(PrincipalContext, IdentityType.SamAccountName, "tbenidze");

            //GroupPrincipal insGroupPrincipal = new GroupPrincipal(PrincipalContext);
            //insGroupPrincipal.Name = "*";
            //PrincipalSearcher insPrincipalSearcher = new PrincipalSearcher();
            //insPrincipalSearcher.QueryFilter = insGroupPrincipal;
            //PrincipalSearchResult<Principal> results = insPrincipalSearcher.FindAll();
            //foreach (Principal p in results)
            //{
            //    lbGroups.Add((GroupPrincipal)p);
            //}

            //bool changeSuccessfull = PrincipalContextForGroups.ValidateCredentials("test", "RxuK:1Fd");
            /////////////////////////

            foreach (var item in MenegeableRoles.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
            {
                var grp = GroupPrincipal.FindByIdentity(GetPrincipalContextForGroups(), IdentityType.Name, item.Trim());

                if (grp != null)
                {
                    foreach (var user in grp.GetMembers(true))
                    {
                        if (user is UserPrincipal && !result.Contains(user))
                            result.Add((UserPrincipal)user);
                    }
                }
            }

            return result.OrderBy(x => x.UserPrincipalName).ToList();
        }

        public static string GetUserPhone(UserPrincipal user)
        {
            if (user != null)
            {
                var userEntry = user.GetUnderlyingObject() as DirectoryEntry;
                if (userEntry != null && userEntry.Properties.Contains("mobile"))
                {
                    var mobile = userEntry.Properties["mobile"].Value;
                    if (mobile != null)
                        return mobile.ToString();
                }
            }
            return null;
        }

        public static string GetUserDepartment(UserPrincipal user)
        {
            if (user != null)
            {
                var userEntry = user.GetUnderlyingObject() as DirectoryEntry;
                if (userEntry != null && userEntry.Properties.Contains("department"))
                {
                    var department = userEntry.Properties["department"].Value;
                    if (department != null)
                        return department.ToString();
                }
            }
            return null;
        }
        public static string GetUserPhone(string userName)
        {
            var user = UserPrincipal.FindByIdentity(GetPrincipalContextForUsers(), IdentityType.SamAccountName, userName);
            return GetUserPhone(user);
        }
        public static UserPrincipal FindByIdentity(string userName)
        {
            return UserPrincipal.FindByIdentity(GetPrincipalContextForUsers(), IdentityType.SamAccountName, userName);
        }

        public static void ChangeUserPassword(UserPrincipal user, string newPassword, bool requestPasswordChangeOnLogin)
        {
            foreach (var item in PasswordPersistRoles.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    if (user.IsMemberOf(GetPrincipalContextForGroups(), IdentityType.Name, item))
                    {
                        requestPasswordChangeOnLogin = false;
                        break;
                    }
                }
            }

            user.SetPassword(newPassword);
            if (requestPasswordChangeOnLogin)
            {
                user.PasswordNeverExpires = false;
                user.Save();
                user.ExpirePasswordNow();
                user.Save();
            }
        }


        public static void ChangeUserPassword(string userName, string newPassword, bool requestPasswordChangeOnLogin)
        {
            var user = FindByIdentity(userName);
            foreach (var item in PasswordPersistRoles.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    if (user.IsMemberOf(GetPrincipalContextForGroups(), IdentityType.Name, item))
                    {
                        requestPasswordChangeOnLogin = false;
                        break;
                    }
                }
            }

            user.SetPassword(newPassword);
            if (requestPasswordChangeOnLogin)
            {
                user.PasswordNeverExpires = false;
                user.Save();
                user.ExpirePasswordNow();
                user.Save();
            }
        }
    }
}