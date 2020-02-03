using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ATeam.Models
{
    public class ATeamContext : DbContext
    {
        public ATeamContext (DbContextOptions<ATeamContext> options)
            : base(options)
        {
        }

        public DbSet<ATeam.Models.PatientInput> PatientInput { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DoctorConsultation>()
                .HasKey(co => new { co.ID, co.PatientID });

            builder.Entity<DoctorConsultation>()
                .HasOne(co => co.PatientInput)
                .WithMany(c => c.DoctorConsultations)
                .HasForeignKey(co => co.ID);

            builder.Entity<DoctorConsultation>()
                .HasOne(co => co.Consultation)
                .WithMany(o => o.DoctorConsultations)
                .HasForeignKey(co => co.PatientID);
        }
    }
}
