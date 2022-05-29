using System.Threading.Tasks;
using Xunit;
using CommandsAndQueries;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System;

namespace BLL.Tests {
    public class AddStorageCommandHandlerTests : TestCommandBase {
        [Fact]
        public async Task AddStoragePassCommandHandler_Success() {
            //Arange
            var handler = new AddStorageCommandHandler(unitOfWork);
            var Owner = "Owner";

            //Act
            var storageId = await handler.Handle(
                new AddStorageCommand {
                    Owner = Owner,
                }, CancellationToken.None);

            //Assert
            Assert.NotNull(
                await context.Storage.SingleOrDefaultAsync(storage =>
                storage.Id == storageId && storage.Owner == Owner));
        }
    }
}