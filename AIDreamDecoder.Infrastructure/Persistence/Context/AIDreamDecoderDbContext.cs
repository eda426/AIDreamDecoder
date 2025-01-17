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


            // User - Dream (One-to-Many)
            modelBuilder.Entity<Dream>()
                .HasOne(d => d.User) // Dream tablosundaki User navigation property
                .WithMany(u => u.Dreams) // User tablosundaki Dreams navigation property
                .HasForeignKey(d => d.UserId) // Foreign Key: Dream.UserId
                .OnDelete(DeleteBehavior.Cascade); // Kullanıcı silindiğinde rüyaları da silinsin.

            // Dream - DreamAnalysis (One-to-One)
            modelBuilder.Entity<Dream>()
                .HasOne(d => d.Analysis) // Dream tablosundaki Analysis navigation property
                .WithOne(a => a.Dream) // DreamAnalysis tablosundaki Dream navigation property
                .HasForeignKey<DreamAnalysis>(a => a.DreamId) // Foreign Key: DreamAnalysis.DreamId
                .OnDelete(DeleteBehavior.Cascade); // Rüya silindiğinde analiz de silinsin.

        }
    }
}
