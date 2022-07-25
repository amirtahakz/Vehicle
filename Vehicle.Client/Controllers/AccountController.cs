﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Vehicle.Core.Repositories;
using Vehicle.Core.ViewModels;
using Vehicle.Data.Entities;
using Vehicle.Client.Models;

namespace Vehicle.Client.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        #region Connections

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;
        private readonly IEmailService _emailService;

        public AccountController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public AccountController(ApplicationUserManager userManager,
            ApplicationSignInManager signInManager,
            ApplicationRoleManager roleManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
        }



        #endregion

        #region Controllers


        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginVm model, string returnUrl)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "User not found!");
                return View(model);
            }

            //if (!await _userManager.IsEmailConfirmedAsync(user.Id))
            //{
            //    ModelState.AddModelError(string.Empty, "Please confirm your email");
            //    return View(model);
            //}

            if (!user.ManagerConfirmed)
            {
                ModelState.AddModelError(string.Empty, "Please wait for manager confirmation");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);

            switch (result)
            {
                case SignInStatus.Success:
                    if (await _userManager.IsInRoleAsync(user.Id, "Manager"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "Manager" });
                    }
                    if (await _userManager.IsInRoleAsync(user.Id, "Secretary"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "Secretary" });
                    }
                    if (await _userManager.IsInRoleAsync(user.Id, "Employee"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "Employee" });
                    }
                    if (await _userManager.IsInRoleAsync(user.Id, "Driver"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "Driver" });
                    }
                    return RedirectToLocal(returnUrl);

                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }


        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterVm model)
        {
            if (!ModelState.IsValid) return View(model);


            var email = await _userManager.FindByEmailAsync(model.Email);
            if (email != null)
            {
                ModelState.AddModelError(string.Empty, "Email already exists!");
                return View(model);
            }

            var newUser = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.Phone
            };
            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (!result.Succeeded)
            {
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, err);
                    return View(model);
                }
            }

            var user = await _userManager.FindByEmailAsync(model.Email);


            if (!await _roleManager.RoleExistsAsync(UserRolesVm.Manager))
                await _roleManager.CreateAsync(new IdentityRole() { Name = UserRolesVm.Manager });

            if (!await _roleManager.RoleExistsAsync(UserRolesVm.Employee))
                await _roleManager.CreateAsync(new IdentityRole() { Name = UserRolesVm.Employee });

            if (!await _roleManager.RoleExistsAsync(UserRolesVm.Secretary))
                await _roleManager.CreateAsync(new IdentityRole() { Name = UserRolesVm.Secretary });

            if (!await _roleManager.RoleExistsAsync(UserRolesVm.Driver))
                await _roleManager.CreateAsync(new IdentityRole() { Name = UserRolesVm.Driver });

            if (await _roleManager.RoleExistsAsync(UserRolesVm.Driver))
                await _userManager.AddToRoleAsync(user.Id, UserRolesVm.Driver);

            // Send Email Confirmation Code
            //var code = await _userManager.GenerateChangePhoneNumberTokenAsync(user.Id, user.Email);
            //await _emailService.SendEmailAsync(new EmailModel(user.Email, "Email confirmation", "Your security code is" + code));

            //return RedirectToAction("ConfirmEmailCode", new { email = model.Email });
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        [AllowAnonymous]
        public ActionResult SendEmailCodeVerification()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendEmailCodeVerification(SendEmailCodeVm model)
        {
            if (!ModelState.IsValid) return View(model);

            // Send Email Confirmation Code
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "User not found");
                return View(model);
            }
            if (user.EmailConfirmed)
            {
                ModelState.AddModelError(string.Empty, "User email confirmed before");
                return View(model);
            }
            var code = await _userManager.GenerateChangePhoneNumberTokenAsync(user.Id, user.Email);
            await _emailService.SendEmailAsync(new EmailModel(user.Email, "Email confirmation", "Your security code is" + code));
            return RedirectToAction("Login");
        }



        [AllowAnonymous]
        public ActionResult ConfirmEmailCode(string email)
        {
            if (string.IsNullOrEmpty(email)) return View(email);

            ConfirmEmailCodeVm confirmEmailCodeVm = new ConfirmEmailCodeVm()
            {
                Email = email,
            };

            return View(confirmEmailCodeVm);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ConfirmEmailCode(ConfirmEmailCodeVm model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = _userManager.Users.SingleOrDefault(u => u.Email == model.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "User not found!");
                return View();
            }

            var result = await _userManager.ChangePhoneNumberAsync(user.Id, model.Email, model.Code);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Code is not valid");
                return View(model);
            }

            user.EmailConfirmed = true;
            user.PhoneNumberConfirmed = false;
            await _userManager.UpdateAsync(user);

            return RedirectToAction("Login");
        }



        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "User not found");
                return View();
            }
            if (!(await _userManager.IsEmailConfirmedAsync(user.Id)))
            {
                ModelState.AddModelError(string.Empty, "Please confirm your email");
                return View();
            }

            // Send an email with this link
            string code = await _userManager.GeneratePasswordResetTokenAsync(user.Id);
            var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
            await _emailService.SendEmailAsync(new EmailModel(user.Email, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>"));
            return RedirectToAction("ForgotPasswordConfirmation", "Account");

        }


        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }


        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordVm model)
        {
            if (!ModelState.IsValid) return View(model);


            var user = await _userManager.FindByNameAsync(model.Email);
            if (user == null) return RedirectToAction("ResetPasswordConfirmation", "Account");


            var result = await _userManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded) return RedirectToAction("Login", "Account");

            AddErrors(result);
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }


        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await _signInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationVm { Email = loginInfo.Email });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationVm model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await _userManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }


        public ActionResult LogOut()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }


        #endregion

        #region Helpers
        // Used for XSRF protection when adding external logins
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}