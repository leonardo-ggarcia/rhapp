using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RH.Models
{
    public class Cand_Job
    {
        public int Id { get; set; }
        public Candidate Candidate { get; set; }
        public Job Job { get; set; }
    }
}
