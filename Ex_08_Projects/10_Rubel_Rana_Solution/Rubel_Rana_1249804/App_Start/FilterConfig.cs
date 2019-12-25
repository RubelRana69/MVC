using System.Web;
using System.Web.Mvc;

namespace Rubel_Rana_1249804
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
