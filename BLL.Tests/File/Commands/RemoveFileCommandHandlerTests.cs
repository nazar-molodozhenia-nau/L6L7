using CommandsAndQueries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BLL.Tests {
    public class RemoveFileCommandHandlerTests : TestCommandBase {
        [Fact]
        public async Task RemoveFileCommandHandler_Success() {
            // Arrange 
            var handler = new RemoveFileCommandHandler(unitOfWork);

            // Act
            await handler.Handle(new RemoveFileCommand {
                Id = ContextFactory.FileIdForDelete
            }, CancellationToken.None);

            // Assert
            Assert.Null(await context.File.SingleOrDefaultAsync(club =>
            club.Id == ContextFactory.FileIdForDelete));
        }

        [Fact]
        public async Task RemoveFileCommandHandler_FailedOnWrongId() {
            // Arrange
            var handler = new RemoveFileCommandHandler(unitOfWork);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new RemoveFileCommand { Id = Guid.NewGuid() }, CancellationToken.None));
        }
    }
}