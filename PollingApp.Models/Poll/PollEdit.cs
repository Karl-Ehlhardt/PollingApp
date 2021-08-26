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
        
        [Required]
        public string PollQuestion { get; set; }

        [Required]
        public bool PublishFlag { get; set; }

        [Required]
        public int ResponseMultiFlag { get; set; }
    }
}
