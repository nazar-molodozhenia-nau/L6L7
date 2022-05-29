using System.Threading.Tasks;
using Xunit;
using CommandsAndQueries;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System;

namespace BLL.Tests {
    public class UpdateFolderCommandHandlerTests : TestCommandBase {
        [Fact]
        public async Task UpdateFolderCommandHandler_Success() {
            // Arrange
            var handler = new UpdateFolderCommandHandler(unitOfWork);
            var Name = "Name";


            // Act
            await handler.Handle(new UpdateFolderCommand {
                Id = ContextFactory.FolderIdForUpdate,
                Name = Name,

            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await context.Folder.SingleOrDefaultAsync(folder =>
            folder.Id == ContextFactory.FolderIdForUpdate && folder.Name == Name));
        }

        [Fact]
        public async Task UpdateFolderCommandHandler_FailOnWrongId() {
            // Arrange
            var handler = new UpdateFolderCommandHandler(unitOfWork);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new UpdateFolderCommand {
                Id = Guid.NewGuid(),
            }, CancellationToken.None));
        }
    }
}