using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace IKBlok
{
    public class Yetki: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)

        {

            //BaseController bs = new BaseController();

            base.OnActionExecuting(filterContext);



            if (filterContext.HttpContext.Session.GetInt32("roleid") == 2)

            {

                //bs.Notify("Erişim Yetkiniz Bulunmamaktadır!!!","Erişim Yetkisi",notificationType:Models.NotificationType.error);

                filterContext.Result = new RedirectToRouteResult(

                    new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });

                return;

            }
            else if(filterContext.HttpContext.Session.GetInt32("roleid") == 1)
            {

            }
        }
    }
}



