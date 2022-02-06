using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OTeaching.Infrastructure
{
    public class CustomAuthorizeAttribute: AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            //var userId = Convert.ToString(httpContext.Session["UserId"]);
            var role = Convert.ToString(httpContext.Session["UserId"]);
            if (role.Equals("admin") || role.Equals("staff") || role.Equals("student"))
            {
                authorize=true;
            }
            //if (!string.IsNullOrEmpty(userId))
            //    if (role.Equals("staff"))
            //    {

            //    }
            //    using (var context = new OTeachingContext())
            //    {
            //        var userRole = (from u in context.Users
            //                        join r in context.Roles on u.RoleId equals r.Id
            //                        where u.UserId == userId
            //                        select new
            //                        {
            //                            r.Name
            //                        }).FirstOrDefault();
            //        foreach (var role in allowedroles)
            //        {
            //            if (role == userRole.Name) return true;
            //        }
            //    }


            return authorize;
        }
    }
}