using PollingApp.Data;
using PollingApp.Models.Poll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingApp.Services
{
    public class PollService
    {
        //private user field
        private readonly Guid _userId;

        //private context
        private ApplicationDbContext _context = new ApplicationDbContext();

        //service constructor
        public PollService(Guid userId)
        {
            _userId = userId;
        }

        //Create new poll
        public async Task<bool> CreatePoll(PollCreate model)
        {
            Poll poll =
                new Poll()
                {
                    OwnerId = _userId,
                    PollQuestion = model.PollQuestion,
                    PublishFlag = model.PublishFlag,
                    ResponseMultiFlag = model.ResponseMultiFlag
                };

            _context.Polls.Add(poll);
            return await _context.SaveChangesAsync() == 1;
        }

        //read

        //update

        public bool PublishFlag (PollEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Polls
                        .Single(e => e.PollId == model.PollId && e.OwnerId == _userId);

                entity.PollQuestion = model.PollQuestion;
                entity.PublishFlag = model.PublishFlag;
                entity.ResponseMultiFlag = model.ResponseMultiFlag;

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
