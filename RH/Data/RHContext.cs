﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RH.Models;

namespace RH.Data
{
    public class RHContext : DbContext
    {
        public RHContext (DbContextOptions<RHContext> options)
            : base(options)
        {
        }

        public DbSet<RH.Models.Technology> Technology { get; set; }
        public DbSet<RH.Models.Job> Job { get; set; }
        public DbSet<RH.Models.Candidate > Candidate { get; set; }     


    }
}
