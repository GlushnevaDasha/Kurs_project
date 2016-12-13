using kr_avt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace kr_avt.Controllers
{
   
        [Authorize]
        [AllowAnonymous]
        public class AccountController : Controller
        {
            // 
            // GET: /Account/ 
            public ActionResult Login(string returnUrl)
            {
                ViewBag.ReturnUrl = returnUrl;
                return View();
            }

            [HttpPost]
            public ActionResult Login(LoginModel model, string returnUrl)
            {
                if (ModelState.IsValid)
                {
                    if (Membership.ValidateUser(model.UserName, model.Password))
                    {
                        FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                        if (Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            //if (MyRoleProvider.Role(User.Identity.Name, "Администратор") || MyRoleProvider.Role(User.Identity.Name, "Директор")) 
                            //{
                            //    return RedirectToAction("Index", "User"); 
                            //}
                            return RedirectToAction("HomePage", "Home"); 
                            
                        }
                    }
                }

                // Появление этого сообщения означает наличие ошибки; повторное отображение формы 
                ModelState.AddModelError("", "Имя пользователя или пароль указаны неверно.");
                return View(model);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult LogOff()
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("HomePage", "Home");
            }

           }
    }

