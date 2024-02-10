using System.Collections.Generic;
using _Nisab_Calculator.Models;
using Microsoft.EntityFrameworkCore;

namespace _Nisab_Calculator.Controllers
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) 
        {
            this.ChangeTracker.LazyLoadingEnabled = true;

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.comments)
                .HasForeignKey(c => c.UserId);
        }
        public async Task<User> GetByUsername(string username)
        {
            return await Users.FirstOrDefaultAsync(u => u.username == username);
        }
        public async Task<User> GetByUserId(int userId)
        {
            return await Users.FirstOrDefaultAsync(u => u.id == userId);
        }
    }

}