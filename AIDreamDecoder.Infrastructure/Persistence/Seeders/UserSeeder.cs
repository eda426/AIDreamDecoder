using AIDreamDecoder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Infrastructure.Persistence.Seeders
{
    public class UserSeeder : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var user = new User
            {
                Id = new Guid("4d7b6b79-8fb3-4e1d-9211-d917f498d197"),
                Name = "AIDreamDecoder",
                Email = "AIDreamDecoder@gmail.com",
                CreatedAt = DateTime.UtcNow,
                Dreams = new List<Dream>()
            };

            user.PasswordHash = CreatePasswordHash(user, "123456789");

            builder.HasData(user);
        }

        private string CreatePasswordHash(User user, string password)
        {
            var passwordHasher = new PasswordHasher<User>();

            return passwordHasher.HashPassword(user, password);
        }
    }
}
