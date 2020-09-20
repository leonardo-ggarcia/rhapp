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
    }
}
