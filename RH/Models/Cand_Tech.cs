using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace RH.Models
{
    public class Cand_Tech
    {
        [Key]
        public int Id { get; set; }
        public Technology Technology { get; set; }
        public int TechnologyId { get; set; }
        public Candidate Candidate { get; set; }
        public int CandidateId { get; set; }

        public Cand_Tech()
        {
        }
        public Cand_Tech(int id, Technology technology, Candidate candidate)
        {
            Id = id;
            Technology = technology;
            Candidate = candidate;
        }
    }
}
