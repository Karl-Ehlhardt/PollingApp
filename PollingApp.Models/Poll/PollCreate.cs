using PollingApp.Models.Choice;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingApp.Models.Poll
{
    public class PollCreate
    {

        [Required]
        public string PollQuestion { get; set; }

        [Required]
        public bool PublishFlag { get; set; }

        [Required]
        public int ResponseMultiFlag { get; set; }// 0 means unlimited responses, 1 and up to max is how many the user can choose


        public IEnumerable<ChoiceCreate> ChoiceCreateList { get; set; }


    }
}
