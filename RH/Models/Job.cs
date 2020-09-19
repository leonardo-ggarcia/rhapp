using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;

namespace RH.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }

        public ICollection<Candidate> Candidates = new List<Candidate>();
        public ICollection<Technology> Technologies = new List<Technology>();

        public Job()
        {
        }

        public Job(int id, string name, int amount)
        {
            this.Id = id;
            this.Name = name;
            this.Amount = amount;
        }

        public void addCandidate(Candidate candidate)
        {
            this.Candidates.Add(candidate);
        }

        public void removeCandidate(Candidate candidate)
        {
            this.Candidates.Remove(candidate);
        }

        public int totalCandidate()
        {
            return this.Candidates.Count();
        }

        public void addTechnologies(Technology technology)
        {
            this.Technologies.Add(technology);
        }

        public void removeTechnologies(Technology technology)
        {
            this.Technologies.Remove(technology);
        }

        public Technology findTechnology(Technology technology)
        {
            return this.Technologies.FirstOrDefault(obj => obj == technology);
        }

        public void addTier(Technology technology, double tier)
        {
            findTechnology(technology).setTier(tier);      
            
            foreach(Technology tech in Candidates.Select(obj => obj.findTechnology(technology)))
            {
                tech.setTier(tier);
            }
        }     
    }
}
