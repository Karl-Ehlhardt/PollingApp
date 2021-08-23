using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingApp.Models.Choice
{
    public class ChoiceEdit
    {
        public int ChoiceId { get; set; }

        public string Answer { get; set; }

        public bool Delete { get; set; }

    }
}
