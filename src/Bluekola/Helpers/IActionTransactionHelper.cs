using Microsoft.AspNetCore.Mvc.Filters;

namespace Bluekola.Helpers
{
    public interface IActionTransactionHelper
    {
        void BeginTransaction();
        void EndTransaction(ActionExecutedContext filterContext);
        void CloseSession();
    }
}