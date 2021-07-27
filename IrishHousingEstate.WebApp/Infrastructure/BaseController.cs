using Microsoft.AspNetCore.Mvc;

namespace IrishHousingEstate.WebApp.Infrastructure
{
    [Route("[controller]/[action]", Name = "[controller]_[action]")]
    public abstract class BaseController : Controller
    {
    }
}
