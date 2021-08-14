using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingApp.Data
{
    public class Poll
    {
        [Key]
        public int PollId { get; set; }

        [Required]
        public int OwnerId { get; set; }

        [Required]
        public string PollQuestion { get; set; }

        [Required]
        public int PublishFlag { get; set; }

        [Required]
        public int Response_multiFlag { get; set; }
    }
}
