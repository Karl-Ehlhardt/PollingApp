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

        //Add choice to an existing poll
        public async Task<bool> CreateChoiceFromListEdit(PollEdit model)
        {
            
            foreach (ChoiceCreate c in model.ChoiceCreateList)
            {
                Choice choice =
                    new Choice()
                    {
                        PollId = model.PollId,
                        Answer = c.Answer,
                        Count = 0
                    };

                _context.Choices.Add(choice);

            }
            if (await _context.SaveChangesAsync() == model.ChoiceCreateList.Count())
            {
                return true;
            }

            return false;

        }

        //Edit choice to new poll
        public async Task<bool> EditChoiceFromList(PollEdit model)
        {
            int valadationOfChanges = model.ChoiceEditList.Count();
            foreach (ChoiceEdit c in model.ChoiceEditList)
            {

                Choice choice =
                _context
                .Choices
                .Single(a => a.ChoiceId == c.ChoiceId);

                if (c.Delete == true)
                {
                    _context.Choices.Remove(choice);
                }
                else if(choice.Answer == c.Answer)//no change so the database will not have an update
                {
                    valadationOfChanges -= 1;
                }
                else
                {
                choice.Answer = c.Answer;
                }

            }

            if (await _context.SaveChangesAsync() == valadationOfChanges)
            {
                return true;
            }

            return false;

        }

    }
}