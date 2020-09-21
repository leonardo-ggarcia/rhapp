using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RH.Models
{
    public class Tech_Job
    {
        public int Id { get; set; }
        public Technology Technology { get; set; }
        public Job Job { get; set; }
    }
}
