using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UoW;
using DataBase;

namespace CommandsAndQueries {
    public class UpdateStorageCommandHandler : IRequestHandler<UpdateStorageCommand> {
        private readonly IUnitOfWork unitOfWork;
        public UpdateStorageCommandHandler(IUnitOfWork unitOfWork) =>
            this.unitOfWork = unitOfWork;

        public async Task<Unit> Handle(UpdateStorageCommand request, CancellationToken cancellationToken) {
            var storage = await unitOfWork.Storage.GetByIdAsync(request.Id, cancellationToken);
            if(storage == null)
                throw new NotFoundException(nameof(Storage), request.Id);
            storage.Id = request.Id;
            storage.Owner = request.Owner;
            await unitOfWork.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}