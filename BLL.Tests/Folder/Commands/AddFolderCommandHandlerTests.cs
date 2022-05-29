using System.Threading.Tasks;
using Xunit;
using CommandsAndQueries;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System;

namespace BLL.Tests {
    public class AddFolderCommandHandlerTests : TestCommandBase {
        [Fact]
        public async Task AddFolderCommandHandler_Success() {
            //Arange
            var handler = new AddFolderCommandHandler(unitOfWork);
            var Name = "Name";

            //Act
            var folderId = await handler.Handle(
                new AddFolderCommand {
                    Name = Name,
                }, CancellationToken.None);

            //Assert
            Assert.NotNull(
                await context.Folder.SingleOrDefaultAsync(folder =>
                folder.Id == folderId && folder.Name == Name));
        }
    }
}