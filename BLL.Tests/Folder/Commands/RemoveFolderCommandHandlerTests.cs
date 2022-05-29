using System.Threading.Tasks;
using Xunit;
using CommandsAndQueries;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System;

namespace BLL.Tests {
    public class RemoveFolderCommandHandlerTests : TestCommandBase {
        [Fact]
        public async Task RemoveFolderCommandHandler_Success() {
            // Arrange 
            var handler = new RemoveFolderCommandHandler(unitOfWork);

            // Act
            await handler.Handle(new RemoveFolderCommand {
                Id = ContextFactory.FolderIdForDelete
            }, CancellationToken.None);

            // Assert
            Assert.Null(await context.Folder.SingleOrDefaultAsync(user =>
            user.Id == ContextFactory.FolderIdForDelete));
        }

        [Fact]
        public async Task RemoveFolderCommandHandler_FailedOnWrongId() {
            // Arrange
            var handler = new RemoveFolderCommandHandler(unitOfWork);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new RemoveFolderCommand { Id = Guid.NewGuid() }, CancellationToken.None));
        }
    }
}