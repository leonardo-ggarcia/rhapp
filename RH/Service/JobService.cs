using Microsoft.EntityFrameworkCore;
using RH.Data;
using RH.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
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

        public async Task<Job> findByIdAsync(int id)
        {
            return await _context.Job.FirstOrDefaultAsync(obj => obj.Id == id);
        }
        public async Task insertAsync(Job obj)
        {
            _context.Job.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task removeAsync(int id)
        {
            try
            {
                var obj = await findByIdAsync(id);
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbException)
            {
                //Lançar um exceção por integridade referencial
            }
            
        }

        public async Task UpdateAsync(Job obj)
        {
            bool hasAny = await _context.Job.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                //throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //throw new DbConcurrencyException(e.Message);
            }
        }  
    }
}
