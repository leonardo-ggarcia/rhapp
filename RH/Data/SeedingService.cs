using Microsoft.AspNetCore.Identity.UI.Pages.Internal.Account;
using RH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RH.Data
{
    public class SeedingService
    {
        private readonly RHContext _context;

        public SeedingService(RHContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Technology.Any() ||
                _context.Candidate.Any() ||
                _context.Job.Any())
            {
                return;
            }

            Technology tech1 = new Technology(1, "Java", "Java is a class-based, object-oriented programming language that is designed to have as few implementation dependencies as possible...");
            Technology tech2 = new Technology(2, "C#", "C # is a programming language");
            Technology tech3 = new Technology(3, "C++", "C # is a programming language");
            Technology tech4 = new Technology(4, "C", "C # is a programming language");
            Technology tech5 = new Technology(5, "Phyton", "C # is a programming language");
            Technology tech6 = new Technology(6, ".Net", ".Net is a Microsoft framework for web development");

            Job job1 = new Job(1, "Developer", 6);
            Job job2 = new Job(2, "UI/UX Designer", 5);
            Job job3 = new Job(3, "DB Manager", 4);
            Job job4 = new Job(4, "Project Manager", 3);
            Job job5 = new Job(5, "System Analyst", 2);
            Job job6 = new Job(6, "Support Analyst", 1);

            Candidate cand1 = new Candidate(1, "Richard Mathew Stallman", 67, "Street 7º", "Nova York-NY", "(+1) 565-454", "richard@mail.com", job1);
            Candidate cand2 = new Candidate(2, "Steven Paul Jobs", 66, "Avenue Pablo", "Califórnia-CA", "(+1) 565-234", "steve@mail.com", job2);
            Candidate cand3 = new Candidate(3, "William Henry Gates", 64, "Avenue Boulevard", "Washington-DC", "(+1) 565-454", "billgates@mail.com", job3);
            Candidate cand4 = new Candidate(4, "Larry Ellison", 59, "Street 6º", "Nova York-NY", "(+1) 565-454", "larry@mail.com", job4);
            Candidate cand5 = new Candidate(5, "Mark Elliot Zuckerberg ", 36, "Green Street", "Los Angeles-CA", "(+1) 565-854", "mark@mail.com", job5);
            Candidate cand6 = new Candidate(6, "Jeff Bezo", 56, "Route 68", "Albuquerque-NM", "(+1) 565-054", "jeff@mail.com", job6);

            _context.Technology.AddRange(tech1, tech2, tech3, tech4, tech5, tech6);
            _context.Job.AddRange(job1, job2, job3, job4, job5, job6);
            _context.Candidate.AddRange(cand1, cand2, cand3, cand4, cand5, cand6);

            _context.SaveChanges();

        }
    }
}
