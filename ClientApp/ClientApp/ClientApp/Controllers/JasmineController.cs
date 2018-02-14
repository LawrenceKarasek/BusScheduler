using System;
using System.Web.Mvc;

namespace ClientApp.Controllers
{
    public class JasmineController : Controller
    {
        public ViewResult Run()
        {
            return View("SpecRunner");
        }
    }
}
