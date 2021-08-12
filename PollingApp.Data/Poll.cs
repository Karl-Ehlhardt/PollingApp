using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingApp.Data
{
    class Questions
    {
        [key]
        public int Id { get; set; }

        [required]
        public int OwnerId { get; set; }

        [required]
        public string PollQuestion { get; set; }

        [required]
        public int PublishFlag { get; set; }

        [required]
        public int Response_multiFlag { get; set; }
    }
}
