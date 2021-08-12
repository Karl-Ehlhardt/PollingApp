using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingApp.Data
{
    public class Responses
    {
        [Key]
        public int ResponseId { get; set; }

        [ForeignKey(nameof(Poll))]
        public int PollId { get; set; }

        [ForeignKey(nameof(User))]
        public int OwnerId { get; set; }

        [Required]
        public String Selection { get; set; }
    }
}
