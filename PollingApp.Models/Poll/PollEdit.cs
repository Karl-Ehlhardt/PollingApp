using PollingApp.Models.Choice;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingApp.Models.Poll
{
    public class PollEdit
    {

        public int PollId { get; set; }

        public string PollQuestion { get; set; }

        public bool PublishFlag { get; set; }

        public int ResponseMultiFlag { get; set; }// 0 means unlimited responses, 1 and up to max is how many the user can choose


        public IList<ChoiceEdit> ChoiceEditList { get; set; }

        public IList<ChoiceCreate> ChoiceCreateList { get; set; }


    }
}
