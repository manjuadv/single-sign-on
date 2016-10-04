using SingleSignOnModule.SingleSignOnService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;

namespace SingleSignOnModule
{
    public class SSOHttpModule : IHttpModule
    {
        public String ModuleName
        {
            get { return "SSOHttpModule"; }
        }
        public void Dispose()
        {

        }

        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += new EventHandler(this.Application_AuthenticateRequest);
        }
        private void Application_AuthenticateRequest(Object source, EventArgs e)
        {
            HttpApplication application = (HttpApplication)source;
            
            HttpContext context = application.Context;           
            RouteData routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(context));
            string singleSignOnUrl = ConfigurationManager.AppSettings["SingleSignOnURL"];

            HttpCookie ssoAuthCookie = context.Request.Cookies["sso-token"];
            if (ssoAuthCookie == null)
            {
                context.Response.Redirect(singleSignOnUrl + "/LogIn/Index?ReturnUrl=" + HttpUtility.UrlEncode(context.Request.Url.AbsoluteUri), true);
            }
            else
            {
                if (string.IsNullOrEmpty(ssoAuthCookie.Value))
                {
                    context.Response.Redirect(singleSignOnUrl + "/LogIn/Index?ReturnUrl=" + HttpUtility.UrlEncode(context.Request.Url.AbsoluteUri), true);
                }
                else
                {
                    Service1Client ssoClient = new Service1Client();
                    AuthenticatedUser user = ssoClient.GetAuthenticatedUser(ssoAuthCookie.Value);
                    if (user != null)
                    {
                        string[] roles = user.Groups.Select(r => r.GroupName).ToArray<string>();
                        context.User = new System.Security.Principal.GenericPrincipal(new System.Web.Security.FormsIdentity(new System.Web.Security.FormsAuthenticationTicket(user.Name, false, 0)), roles);
                    }
                    else
                    {
                        context.Response.Redirect(singleSignOnUrl + "/LogIn/Index?ReturnUrl=" + HttpUtility.UrlEncode(context.Request.Url.AbsoluteUri), true);
                    }
                }
            }
        }
    }
}
