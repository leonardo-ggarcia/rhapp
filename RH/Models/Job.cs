using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;
using System.Runtime.Serialization;
using Microsoft.VisualBasic.CompilerServices;

namespace RH.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }        

        public ICollection<Technology> Technologies = new List<Technology>();
        public Job()
        {
        }

        public Job(int id, string name, string description, int amount)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Amount = amount;            
        }

        public void addTechnologies(Technology technology)
        {
            this.Technologies.Add(technology);
        }

        public void removeTechnologies(Technology technology)
        {
            this.Technologies.Remove(technology);
        }

    }
}
