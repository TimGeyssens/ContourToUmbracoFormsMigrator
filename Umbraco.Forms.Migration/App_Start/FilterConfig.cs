using System.Web;
using System.Web.Mvc;

namespace Umbraco.Forms.Migration
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}