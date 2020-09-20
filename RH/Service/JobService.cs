using Microsoft.EntityFrameworkCore;
using RH.Data;
using RH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RH.Service
{
    public class JobService
    {
        private readonly RHContext _context;

        public JobService(RHContext context)
        {
            _context = context;
        }

        public async Task<List<Job>> findAllAsync()
        {
            return await _context.Job.OrderBy(obj => obj.Name).ToListAsync();
        }
            
    }
}
