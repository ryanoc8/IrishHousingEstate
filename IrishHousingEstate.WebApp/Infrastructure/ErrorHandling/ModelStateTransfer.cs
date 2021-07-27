using Microsoft.AspNetCore.Mvc.Filters;

namespace IrishHousingEstate.WebApp.Infrastructure.ErrorHandling
{
    public abstract class ModelStateTransfer : ActionFilterAttribute
    {
        protected const string Key = nameof(ModelStateTransfer);
    }
}