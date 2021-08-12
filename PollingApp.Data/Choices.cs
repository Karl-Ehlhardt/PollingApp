using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingApp.Data
{
    public class Choices
    {
        [Key]
        public int ChoiceId { get; set; }

        [ForeignKey(nameof(Poll))]
        public int PollId { get; set; }

        [Required]
        public string Choice { get; set; }

        [Required]
        public int Count { get; set; }

    }
}
