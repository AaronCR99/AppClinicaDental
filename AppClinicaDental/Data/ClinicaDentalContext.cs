using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppClinicaDental.Models;

    public class ClinicaDentalContext : DbContext
    {
        public ClinicaDentalContext (DbContextOptions<ClinicaDentalContext> options)
            : base(options)
        {
        }

        public DbSet<AppClinicaDental.Models.Cita> Cita { get; set; }
    }
