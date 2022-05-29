using CommandsAndQueries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BLL.Tests {
    public class UpdateFileCommandHandlerTests : TestCommandBase {
        [Fact]
        public async Task UpdateFileCommandHandler_Success() {
            // Arrange
            var handler = new UpdateFileCommandHandler(unitOfWork);
            var updatedName = "New name";


            // Act
            await handler.Handle(new UpdateFileCommand {
                Id = ContextFactory.FileIdForUpdate,
                Name = updatedName
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await context.File.SingleOrDefaultAsync(club =>
            club.Id == ContextFactory.FileIdForUpdate && club.Name == updatedName));
        }

        [Fact]
        public async Task UpdateFileCommandHandler_FailOnWrongId() {
            // Arrange
            var handler = new UpdateFileCommandHandler(unitOfWork);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new UpdateFileCommand {
                Id = Guid.NewGuid(),
            }, CancellationToken.None));
        }

    }
}