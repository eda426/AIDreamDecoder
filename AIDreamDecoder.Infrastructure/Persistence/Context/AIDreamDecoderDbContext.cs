using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIDreamDecoder.Domain.Entities;

namespace AIDreamDecoder.Infrastructure.Persistence.Context
{
    public class AIDreamDecoderDbContext : DbContext
    {
        public AIDreamDecoderDbContext(DbContextOptions<AIDreamDecoderDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } //Kullanıcılar tablosu
        public DbSet<Dream> Dreams { get; set; } //Rüyalar tablosu
        public DbSet<DreamAnalysis> DreamAnalyses { get; set; } //Rüya analizleri tablosu

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // İlişkileri ve kuralları tanımlayın
            modelBuilder.Entity<Dream>()
                .HasOne(d => d.Analysis)
                .WithOne()
                .HasForeignKey<DreamAnalysis>(da => da.DreamId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Dreams)
                .WithOne()
                .HasForeignKey(d => d.UserId);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AIDreamDecoderDbContext).Assembly);
        }
    }
}
