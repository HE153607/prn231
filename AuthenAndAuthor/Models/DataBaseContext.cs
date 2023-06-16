using Microsoft.EntityFrameworkCore;

namespace AuthenAndAuthor.Models
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }
        public virtual DbSet<User> Users { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, UserName = "hungbao1", PassWord = "hungbao1", Role = "Admin" },
                new User { Id= 2, UserName = "hoanganh2", PassWord = "hoanganh2", Role = "Admin" },
                new User { Id= 3,  UserName = "minhhoang3", PassWord = "minhhoang3", Role = "User" },
                new User { Id = 4, UserName = "quangthai4", PassWord = "quangthai4", Role = "Member" }
                );
        }
    }
}
