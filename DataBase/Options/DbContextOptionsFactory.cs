using Microsoft.EntityFrameworkCore;

namespace DataBase {
    public class DbContextOptionsFactory {
        public static DbContextOptions<ContentLibraryContext> Get() {
            var builder = new DbContextOptionsBuilder<ContentLibraryContext>();
            builder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ContentLibraryContextDb");
            return builder.Options;
        }
    }
}