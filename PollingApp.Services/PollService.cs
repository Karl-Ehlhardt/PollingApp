using PollingApp.Data;
using PollingApp.Models.Choice;
using PollingApp.Models.Poll;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        //Deatils of a poll
        public async Task<PollDetail> GetByIdPoll(int id)
        {
            Poll poll =
               _context
               .Polls
               .Single(q => q.PollId == id);

            var choiceQuery =
                await
                _context
                .Choices
                .Where(q => q.PollId == id)
                .Select(
                    q =>
                    new ChoiceDetail()
                    {
                        Answer = q.Answer,
                        Count = q.Count
                    }).ToListAsync();

            PollDetail pollDetail =
                new PollDetail
                {
                    PollId = poll.PollId,
                    PollQuestion = poll.PollQuestion,
                    PublishFlag = poll.PublishFlag,
                    ResponseMultiFlag = poll.ResponseMultiFlag,
                    ChoiceList = choiceQuery

                };
            return pollDetail;
        }

    }

}