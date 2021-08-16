using PollingApp.Data;
using PollingApp.Models.Choice;
using PollingApp.Models.Poll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingApp.Services
{
    public class ChoiceService
    {
        //private user field
        private readonly Guid _userId;

        //private context
        private ApplicationDbContext _context = new ApplicationDbContext();

        //service constructor
        public ChoiceService(Guid userId)
        {
            _userId = userId;
        }

        //Create new poll
        public async Task<int> CreateChoiceFromList(PollCreate model)
        {
            Poll poll =
                _context
                .Polls.OrderByDescending(p => p.PollId)
                .FirstOrDefault();

            foreach(ChoiceCreate c in model.ChoiceCreateList)
            {
            Choice choice =
                new Choice()
                {
                    PollId = poll.PollId,
                    Answer = c.Answer,
                    Count = 0
                };

            _context.Choices.Add(choice);

            }
            if (await _context.SaveChangesAsync() == model.ChoiceCreateList.Count())
            {
                return poll.PollId;
            }

            return 0;

        }


    }
}
