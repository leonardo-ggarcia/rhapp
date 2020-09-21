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
    public class TechnologyService
    {
        private readonly RHContext _context;

        public TechnologyService(RHContext context)
        {
            _context = context;
        }

        public async Task<List<Technology>> findAllAsync()
        {
            return await _context.Technology.OrderBy(obj => obj.Name).ToListAsync();
        }

        public async Task<Technology> findByIdAsync(int id)
        {
            return await _context.Technology.FirstOrDefaultAsync(obj => obj.Id == id);
        }
        public async Task insertAsync(Technology obj)
        {
            _context.Technology.Add(obj);
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
            catch (DbException e)
            {
                //
                throw new Exception(e.Message);
            }

        }

        public async Task UpdateAsync(Technology obj)
        {
            bool hasAny = await _context.Technology.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                //throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                //
                throw new Exception(e.Message);
            }
        }


    }
}
