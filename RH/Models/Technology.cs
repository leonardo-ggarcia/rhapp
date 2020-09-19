using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace RH.Models
{
    public class Technology
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        private double _tier;

        public ICollection<Job> Jobs = new List<Job>();       

        public Technology()
        {
        }

        public Technology(int id, string name, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
        }

        public double getTier()
        {
            return _tier;
        }

        public void setTier(double tier)
        {
            _tier = tier;
        }
        
        public void addJobs(Job job)
        {
            this.Jobs.Add(job);
        }

        public void removeJobs(Job job)
        {
            this.Jobs.Remove(job);
        }

        public int totalJobs()
        {
            return this.Jobs.Count();
        }

        public Job findJobs(Job job)
        {
            return this.Jobs.FirstOrDefault(obj => obj == job);
        }
    }
}
