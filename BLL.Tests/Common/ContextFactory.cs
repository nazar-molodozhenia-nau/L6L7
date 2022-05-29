using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using Microsoft.EntityFrameworkCore;

namespace BLL.Tests {
    public static class ContextFactory {
        public static Guid FolderIdForUpdate = Guid.NewGuid();
        public static Guid FolderIdForDelete = Guid.NewGuid();

        public static Guid StoragePassIdForUpdate = Guid.NewGuid();
        public static Guid StoragePassIdForDelete = Guid.NewGuid();

        public static Guid FileIdForUpdate = Guid.NewGuid();
        public static Guid FileIdForDelete = Guid.NewGuid();

        public static ContentLibraryContext Create() {
            var options = new DbContextOptionsBuilder<ContentLibraryContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new ContentLibraryContext(options);
            context.Database.EnsureCreated();
            context.Storage.AddRange(
                new Storage {
                    Id = Guid.Parse("36F0407C-7202-46BF-9A1B-1D67507AB9BB"),
                    Owner = "Owner",
                },
               new Storage {
                   Id = Guid.Parse("36F0407C-7202-46BF-9A1B-1D67507AB9BB"),
                   Owner = "Owner",
               },
                new Storage {
                    Id = Guid.Parse("36F0407C-7202-46BF-9A1B-1D67507AB9BB"),
                    Owner = "Owner",
                });
            context.Folder.AddRange(
                new Folder {
                    Id = Guid.Parse("1E897888-B44E-4282-8290-2FD26FE78B15"),
                    Name = "Name",
                },
                new Folder {
                    Id = Guid.Parse("1E897888-B44E-4282-8290-2FD26FE78B15"),
                    Name = "Name",
                },
                new Folder {
                    Id = Guid.Parse("1E897888-B44E-4282-8290-2FD26FE78B15"),
                    Name = "Name",
                });
            context.File.AddRange(
                new File {
                    Id = Guid.Parse("04981315-E9E1-4639-8AFB-AC7319B417DF"),
                    Name = "Name",
                },
                new File {
                    Id = Guid.Parse("04981315-E9E1-4639-8AFB-AC7319B417DF"),
                    Name = "Name",
                },
                new File {
                    Id = Guid.Parse("04981315-E9E1-4639-8AFB-AC7319B417DF"),
                    Name = "Name",
                });
            context.SaveChanges();
            return context;
        }

        public static void Destroy(ContentLibraryContext context) {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}