using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace RH.Models.ViewModels
{
    public class CandidateFormViewModels
    {
        public Candidate Candidate { get; set; }
        public ICollection<Job> Jobs { get; set; } = new List<Job>();
        public ICollection<Technology> Technologies { get; set; } = new List<Technology>();
    }
}
