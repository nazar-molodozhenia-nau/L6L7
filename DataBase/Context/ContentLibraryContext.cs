using Microsoft.EntityFrameworkCore;

namespace DataBase {
    public class ContentLibraryContext : DbContext {

        public ContentLibraryContext(DbContextOptions<ContentLibraryContext> options) : base(options) {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        public DbSet<Storage> Storage { get; set; }
        public DbSet<Folder> Folder { get; set; }
        public DbSet<File> File { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    
    }
}