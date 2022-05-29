using System.Threading.Tasks;
using Xunit;
using CommandsAndQueries;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System;

namespace BLL.Tests {
    public class RemoveStorageCommandHandlerTests : TestCommandBase {
        [Fact]
        public async Task RemoveStoragePassCommandHandler_Success() {
            // Arrange 
            var handler = new RemoveStorageCommandHandler(unitOfWork);

            // Act
            await handler.Handle(new RemoveStorageCommand {
                Id = ContextFactory.StoragePassIdForDelete
            }, CancellationToken.None);

            // Assert
            Assert.Null(await context.Storage.SingleOrDefaultAsync(clubPass =>
            clubPass.Id == ContextFactory.StoragePassIdForDelete));
        }

        [Fact]
        public async Task RemoveClubPassCommandHandler_FailedOnWrongId() {
            // Arrange
            var handler = new RemoveStorageCommandHandler(unitOfWork);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new RemoveStorageCommand { Id = Guid.NewGuid() }, CancellationToken.None));
        }
    }
}