using Microsoft.AspNetCore.Identity.UI.Pages.Internal.Account;
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


        }
    }
}
