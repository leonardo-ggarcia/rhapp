
using System;
using System.Collections.Generic;
using System.Linq;

namespace RH.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Job Job { get; set; }
        public ICollection<Technology> Technologies = new List<Technology>();
        public Candidate()
        {
        }
        public Candidate(int id, string fullName, int age, string address, string city, string phone, string email, Job job)
        {
            this.Id = id;
            this.FullName = fullName;
            this.Age = age;
            this.Address = address;
            this.City = city;
            this.Phone = phone;
            this.Email = email;
            this.Job = job;
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
    }
}
