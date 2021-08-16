using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingApp.Models.Choice
{
    public class ChoiceCreate
    {

        [Required]
        public string Answer { get; set; }

    }
}
