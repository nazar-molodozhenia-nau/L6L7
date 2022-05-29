using System.Threading.Tasks;
using Xunit;
using CommandsAndQueries;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace BLL.Tests {
    public class AddClubCommandHandlerTests : TestCommandBase {
        [Fact]
        public async Task AddFileCommandHandler_Success() {
            //Arange
            var handler = new AddFileCommandHandler(unitOfWork);
            var Name = "Name";
            var Type = "City";

            //Act
            var storageId = await handler.Handle(
                new AddFileCommand {
                    Name = Name,
                    Type = Type,
                }, CancellationToken.None);

            //Assert
            Assert.NotNull(
                await context.File.SingleOrDefaultAsync(storage =>
                storage.Id == storageId && storage.Name == Name && storage.Type == Type));
        }
    }
}