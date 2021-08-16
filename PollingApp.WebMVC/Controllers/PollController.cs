using Microsoft.AspNet.Identity;
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
            return View();
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
                await choiceService.CreateChoiceFromList(model);
                return RedirectToAction($"Index", "Poll");//Will redriect to the created poll
            };

            ModelState.AddModelError("", "Poll could not be added");

            return View(model);
        }
    }
}