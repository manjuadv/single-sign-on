using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApp_Login_System.Models;
using TestApp_Login_System.SingleSignOnService;

namespace TestApp_Login_System.Controllers
{
    public class LogInController : Controller
    {
        //
        // GET: /LogIn/
        public ActionResult Index(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            HttpCookie ssoAuthCookie = HttpContext.Request.Cookies["sso-token"];
            if (ssoAuthCookie != null && !string.IsNullOrEmpty(ssoAuthCookie.Value))
            {
                SingleSignOnService.Service1Client client = new SingleSignOnService.Service1Client();
                AuthenticatedUser authenticatedUser = client.GetAuthenticatedUser(ssoAuthCookie.Value);
                //TODO : Validate token with authenticatoin service
                if (authenticatedUser != null)
                {
                    SetLoggedIn(authenticatedUser);
                    Response.SetCookie(new HttpCookie("sso-token", ssoAuthCookie.Value));
                    
                    if (ReturnUrl != null)
                        return Redirect(HttpUtility.UrlDecode(ReturnUrl));
                    else
                        return RedirectToAction("LogInDefault");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult RegisterInSSO(LogInUser loginUser, string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            try
            {
                SingleSignOnService.Service1Client client = new SingleSignOnService.Service1Client();
                AuthenticatingUser user = new AuthenticatingUser();
                user.UserName = loginUser.UserName;
                user.Password = loginUser.Password;
                if (client.ValidateUser(loginUser.UserName, loginUser.Password))
                {
                    string ssoToken = client.GetSignOnToken(user);

                    if (ssoToken != null)
                    {
                        Response.SetCookie(new HttpCookie("sso-token", ssoToken));
                        return RedirectToAction("CompleteLogIn", new { ReturnUrl = ReturnUrl });
                    }
                    else
                    {
                        return RedirectToAction("Index", new { ReturnUrl = ReturnUrl });
                    }
                }
                else
                {
                    return RedirectToAction("Index", new { ReturnUrl = ReturnUrl });
                }
            }
            catch
            {
                return View();
            }
        }
        public ActionResult CompleteLogIn(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            HttpCookie ssoAuthCookie = HttpContext.Request.Cookies["sso-token"];
            if (ssoAuthCookie != null && !string.IsNullOrEmpty(ssoAuthCookie.Value))
            {
                SingleSignOnService.Service1Client client = new SingleSignOnService.Service1Client();
                AuthenticatedUser authenticatedUser = client.GetAuthenticatedUser(ssoAuthCookie.Value);

                if (authenticatedUser != null)
                {
                    SetLoggedIn(authenticatedUser);
                    if(authenticatedUser.Groups!=null && authenticatedUser.Groups.Length>0)
                    {
                        ViewBag.Groups = authenticatedUser.Groups[0].GroupName;
                        if (authenticatedUser.Groups.Length > 1)
                        {
                            for (int i = 1; i < authenticatedUser.Groups.Length; i++)
                            {
                                ViewBag.Groups = ViewBag.Groups + "," + authenticatedUser.Groups[i].GroupName;
                            }
                        }
                    }                   
                    Response.SetCookie(new HttpCookie("sso-token", ssoAuthCookie.Value));
                    if (ReturnUrl != null)
                        return Redirect(HttpUtility.UrlDecode(ReturnUrl));
                    else
                        return RedirectToAction("LogInDefault");
                }
                else
                {
                    return RedirectToAction("Index", new { ReturnUrl = ReturnUrl });
                }
            }
            else
            {
                return RedirectToAction("Index", new { ReturnUrl = ReturnUrl });
            }
        }
        [HttpPost]
        public ActionResult LogOff()
        {
            HttpCookie ssoAuthCookie = HttpContext.Request.Cookies["sso-token"];
            if (ssoAuthCookie != null && !string.IsNullOrEmpty(ssoAuthCookie.Value))
            {
                SingleSignOnService.Service1Client client = new SingleSignOnService.Service1Client();
                AuthenticatedUser authenticatedUser = client.GetAuthenticatedUser(ssoAuthCookie.Value);

                if (authenticatedUser != null)
                {
                    client.SignOff(ssoAuthCookie.Value);
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult LogInDefault()
        {
            HttpCookie ssoAuthCookie = HttpContext.Request.Cookies["sso-token"];
            if (ssoAuthCookie != null && !string.IsNullOrEmpty(ssoAuthCookie.Value))
            {
                SingleSignOnService.Service1Client client = new SingleSignOnService.Service1Client();
                AuthenticatedUser authenticatedUser = client.GetAuthenticatedUser(ssoAuthCookie.Value);

                if (authenticatedUser != null)
                {
                    SetLoggedIn(authenticatedUser);
                    if (authenticatedUser.Groups != null && authenticatedUser.Groups.Length > 0)
                    {
                        ViewBag.Groups = authenticatedUser.Groups[0].GroupName;
                        if (authenticatedUser.Groups.Length > 1)
                        {
                            for (int i = 1; i < authenticatedUser.Groups.Length; i++)
                            {
                                ViewBag.Groups = ViewBag.Groups + "," + authenticatedUser.Groups[i].GroupName;
                            }
                        }
                    }
                }
            }
            return View();
        }
        //
        // GET: /LogIn/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        private void SetLoggedIn(AuthenticatedUser user)
        {
            string[] roles = user.Groups.Select(r => r.GroupName).ToArray<string>();
            HttpContext.User = new System.Security.Principal.GenericPrincipal(new System.Web.Security.FormsIdentity(new System.Web.Security.FormsAuthenticationTicket(user.Name, false, 0)), roles);
        }
        //
        // GET: /LogIn/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /LogIn/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /LogIn/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /LogIn/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /LogIn/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /LogIn/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
