using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
        static private Dictionary<string, string> EventsDict = new Dictionary<string, string>();
        
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.events = EventsDict;

            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("/Events/Add")]
        public IActionResult NewEvent(string name, string descrip)
        {
            EventsDict.Add(name, descrip);

            return Redirect("/Events");
        }

    }
}
