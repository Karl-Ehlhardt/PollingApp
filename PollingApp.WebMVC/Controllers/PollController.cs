using Microsoft.AspNet.Identity;
using PollingApp.Models.Choice;
using PollingApp.Models.Poll;
using PollingApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PollingApp.WebMVC.Controllers
{
    public class PollController : Controller
    {
        private PollService CreatePollService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var pollService = new PollService(userId);
            return pollService;
        }

        private ChoiceService CreateChoiceService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var choiceService = new ChoiceService(userId);
            return choiceService;
        }

        // GET: Poll
        public ActionResult Index()
        {
            return View();
        }

        // GET: Poll/Create
        public async Task<ActionResult> Create()
        {
            PollCreate newpoll = new PollCreate { ChoiceCreateList = new List<ChoiceCreate>() };
            return View(newpoll);
        }

        // POST: Poll/Create
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PollCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePollService();

            if (await service.CreatePoll(model))
            {
                ChoiceService choiceService = CreateChoiceService();
                int pollId  = await choiceService.CreateChoiceFromList(model);
                return RedirectToAction($"Details/{pollId}", "Poll");//Will redriect to the created poll
            };

            ModelState.AddModelError("", "Poll could not be added");

            return View(model);
            //https://eliot-jones.com/2014/11/mvc-ajax-4
        }

        // GET: Poll/Details
        public async Task<ActionResult> Details(int id)
        {
            var service = CreatePollService();

            PollDetail mymodel = await service.GetByIdPoll(id);

            return View(mymodel);
        }

        // GET: Poll/Edit
        public async Task<ActionResult> Edit(int id)
        {
            var service = CreatePollService();

            PollDetail mymodel = await service.GetByIdPoll(id);

            return View(mymodel);
        }

        // Post: Poll/Edit
        //public async Task<ActionResult> Edit(PollEdit model)
        //{
        //    if (!ModelState.IsValid) return View(model);

        //    var service = CreatePollService();

        //    if (await service.EditPoll(model))
        //    {
        //        ChoiceService choiceService = CreateChoiceService();
        //        int pollId = await choiceService.EditChoiceFromList(model);
        //        return RedirectToAction($"Details/{pollId}", "Poll");//Will redriect to the created poll
        //    };

        //    ModelState.AddModelError("", "Poll could not be edited");

        //    return View(model);
        //    //https://eliot-jones.com/2014/11/mvc-ajax-4
        //}
    }
}