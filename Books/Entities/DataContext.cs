using Microsoft.EntityFrameworkCore;

namespace Books.Entities
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }
        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable(nameof(Book));
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedOnAdd();
                entity.Property(e => e.Title).IsUnicode(true).IsRequired();
                entity.Property(e => e.Author).IsUnicode(true).IsRequired();
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable(nameof(User));
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedOnAdd();
                entity.Property(e => e.Username).IsUnicode(false).IsRequired();
                entity.Property(e => e.FullName).IsUnicode(true).IsRequired();
                entity.Property(e => e.Password).IsUnicode(false).IsRequired();
            });
            modelBuilder.Entity<ReadingBook>(entity =>
            {
                entity.ToTable(nameof(ReadingBook));
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedOnAdd();
                entity.Property(e => e.BookId).IsRequired();
                entity.Property(e => e.UserId).IsRequired();
            });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ReadingBook>? UserBooks { get; set; }
        public DbSet<Book>? Books { get; set; }
        public DbSet<User>? Users{ get; set; }
    }
}
