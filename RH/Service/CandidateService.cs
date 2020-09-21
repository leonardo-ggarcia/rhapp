using Microsoft.EntityFrameworkCore;
using RH.Data;
using RH.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace RH.Service
{
    public class CandidateService
    {
        private readonly RHContext _context;

        public CandidateService(RHContext context)
        {
            _context = context;
        }

        public async Task<List<Candidate>> findAllAsync()
        {
            return await _context.Candidate.OrderBy(obj => obj.FullName).ToListAsync();
        }

        public async Task<Candidate> findByIdAsync(int id)
        {
            return await _context.Candidate.FirstOrDefaultAsync(obj => obj.Id == id);
        }
        public async Task insertAsync(Candidate obj)
        {
            _context.Candidate.Add(obj);
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

        public async Task UpdateAsync(Candidate obj)
        {
            bool hasAny = await _context.Candidate.AnyAsync(x => x.Id == obj.Id);
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
