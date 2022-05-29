using System.Threading.Tasks;
using Xunit;
using CommandsAndQueries;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System;

namespace BLL.Tests
{
    public class UpdateStorageCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateClubPassCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateStorageCommandHandler(unitOfWork);
            var updatedOwner = "NewOwner";


            // Act
            await handler.Handle(new UpdateStorageCommand
            {
                Id = ContextFactory.StoragePassIdForUpdate,
                Owner = updatedOwner
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await context.Storage.SingleOrDefaultAsync(storage =>
            storage.Id == ContextFactory.StoragePassIdForUpdate && storage.Owner == updatedOwner));
        }

        [Fact]
        public async Task UpdateStoragePassCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateStorageCommandHandler(unitOfWork);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new UpdateStorageCommand
            {
                Id = Guid.NewGuid(),
            }, CancellationToken.None));
        }
    }
}
