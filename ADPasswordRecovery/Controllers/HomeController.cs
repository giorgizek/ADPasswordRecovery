using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;
using System.Web.Mvc;
using ADPasswordRecovery.Models;
using Zek.Extensions;
using Zek.Security;
using Zek.Service.SMS;
using Zek.Web;

namespace ADPasswordRecovery.Controllers
{
    public class HomeController : Controller
    {
        private IEnumerable<UserViewModel> GetUsersForPasswordReset()
        {
            var result = BaseCacheHelper.Get<List<UserViewModel>>("GetUsersForPasswordReset");
            if (result == null)
            {
                result = ADHelper.GetUsersForPasswordReset()
                .Select(u => new UserViewModel
                {
                    ID = u.SamAccountName,
                    FullName = (u.Name ?? string.Empty).Trim(),
                    //EmailAddress = (string.IsNullOrWhiteSpace(u.EmailAddress) ? (u.UserPrincipalName ?? string.Empty) : string.Empty),
                    MobileNumber = ADHelper.GetUserPhone(u) ?? string.Empty,
                    Department = ADHelper.GetUserDepartment(u) ?? string.Empty
                }).ToList();

                BaseCacheHelper.Add("GetUsersForPasswordReset", result);
            }

            return result;
        }


        public ActionResult GetUsers(string text)
        {
            text = text != null ? text.ToLowerInvariant() : string.Empty;

            var users = GetUsersForPasswordReset();//ADHelper.GetUsersForPasswordReset();
            var list = users
                .Where(u =>
                        (u.FullName != null && u.FullName.ToLower().Contains(text)) ||
                        (u.ID.ToLower().Contains(text))
                        //(u.EmailAddress.ToLower().Contains(text))
                    ).Take(10);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ClearCache()
        {
            try
            {
                BaseCacheHelper.Remove("GetUsersForPasswordReset");
                return Json(new { status = true, msg = "მომხმარებლები ჩაიტვირთა ხელახლა" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { status = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Index()
        {
            //ViewBag.Users = GetUsersForPasswordReset();

            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(string userName, bool requestPasswordChangeOnLogin)
        {
            try
            {
                var newPassword = new PasswordGenerator(8, 8, 6, 0).Generate();
                //var newPassword = Membership.GeneratePassword(8, 1);

                var user = ADHelper.FindByIdentity(userName);

                if (user == null)
                    throw new Exception(userName + " მომხმარებელი ვერ მოიძებნა");

                var mobile = ADHelper.GetUserPhone(user).ParseMobile();

                if (string.IsNullOrWhiteSpace(mobile))
                    throw new Exception(userName + "-ს მობილური არ აქვს მითითებული!!!");

                ADHelper.ChangeUserPassword(user, newPassword, requestPasswordChangeOnLogin);
                using (var db = new ADDBEntities())
                {
                    db.PasswordChanges.Add(new PasswordChange { CreatorUsername = User.Identity.Name, Password = newPassword, Username = userName, SysDate = DateTime.Now });
                    db.SaveChanges();
                }

                SendSMS(mobile, newPassword);

                return Json(new { status = true, msg = "პაროლი წარმატებით შეიცვალა" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { status = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        private void SendSMS(string mobile, string password)
        {
            var response = GeocellHttpToSMSHelper.Send(WebConfigurationManager.AppSettings["GeocellID"], mobile, string.Format("New Password: {0}", password));
            if (response.IfNullEmpty().ToUpperInvariant() != "Y")
                throw new Exception("პაროლი შეიცვალა, მაგრამ SMS-ის გაგზავნისას წარმოიშვა შეცდომა");
        }
    }


}
