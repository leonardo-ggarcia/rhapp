using Microsoft.EntityFrameworkCore;
using RH.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RH.Service
{
    public class TechnologyService
    {
        private readonly RHContext _context;

        public TechnologyService(RHContext context)
        {
            _context = context;
        }

        public async Task insert(TechnologyService technology)
        {
             await _context.AddAsync(technology);
             await _context.SaveChangesAsync();

        }
    }
}
