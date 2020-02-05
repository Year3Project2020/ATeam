using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Yearthreeproject.Models
{
    public class YearthreeprojectContext : DbContext
    {
        public YearthreeprojectContext (DbContextOptions<YearthreeprojectContext> options)
            : base(options)
        {
        }

        public DbSet<Yearthreeproject.Models.Patients> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Consultation>()
                .HasKey(co => new { co.PatientID, co.ConsultationID });

            builder.Entity<Consultation>()
                .HasOne(co => co.Patients)
                .WithMany(c => c.Consultations)
                .HasForeignKey(co => co.PatientID);

            builder.Entity<Consultation>()
                .HasOne(co => co.Doctors)
                .WithMany(o => o.Consultations)
                .HasForeignKey(co => co.ConsultationID);
        }

    }
}
