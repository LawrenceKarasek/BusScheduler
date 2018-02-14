using Microsoft.AspNet.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ScheduleApp.Filters
{
    public class AuthTokenFilter : AuthorizationFilterAttribute
    {
        public bool AllowInQueryString { get; set; }

        public override void OnAuthorization(AuthorizationContext actionContext)
        {
            string authToken = Parse(actionContext);

            if (authToken == null)
            {
                actionContext.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                //TODO:log error
                return;
            }

            if (String.IsNullOrWhiteSpace(authToken))
            {
                actionContext.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                //TODO:log error
                return;
            }


        }

        private static string Parse(AuthorizationContext actionContext)
        {
            try
            {
                if (!actionContext.HttpContext.Request.Headers.Any(s => s.Key == "authToken"))
                {
                    return null;
                }
                var token = actionContext.HttpContext.Request.Headers.Single(s => s.Key == "authToken");

                var encoding = Encoding.GetEncoding("ISO-8859-1");
                string authToken = token.Value.FirstOrDefault();

                return authToken.Trim();
            }
            catch (Exception ex)
            {
                string error = String.Format("{Url: {0}", "AuthToken/Parse}", ex.Message + " -- " + ex.StackTrace);
                //TODO:log error
                return string.Empty;
            }
        }
    }


}
