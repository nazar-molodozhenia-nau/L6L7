using DataBase;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UoW;

namespace CommandsAndQueries {
    public class RemoveStorageCommandHandler : IRequestHandler<RemoveStorageCommand> {
        private readonly IUnitOfWork unitOfWork;
        public RemoveStorageCommandHandler(IUnitOfWork unitOfWork) {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(RemoveStorageCommand request, CancellationToken cancellationToken) {
            var storage = await unitOfWork.Storage.GetByIdAsync(request.Id, cancellationToken);
            if(storage == null)
                throw new NotFoundException(nameof(Storage), request.Id);
            unitOfWork.Storage.Remove(storage.Id);
            await unitOfWork.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}