using PollingApp.Models.Choice;
using PollingApp.Models.Poll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PollingApp.WebMVC.Controllers
{
    public class ChoiceController : Controller
    {
        // GET: Choice
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _CreateChoiceFields(PollCreate model, int? index)// will make a partial view to be used when creating the poll
        {
            ViewBag.Index = index ?? 0;
            return PartialView(model);
        }
    }
}