using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CandleShop.Controllers
{
    public class CandlesController : Controller
    {
        // GET: Candles
        public ActionResult Index()
        {
            return View();
        }
    }
}