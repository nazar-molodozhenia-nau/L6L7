using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UoW;
using DataBase;

namespace CommandsAndQueries {

    public class AddStorageCommandHandler : IRequestHandler<AddStorageCommand, Guid> {
        private readonly IUnitOfWork unitOfWork;
        public AddStorageCommandHandler(IUnitOfWork unitOfWork) =>
           this.unitOfWork = unitOfWork;

        public async Task<Guid> Handle(AddStorageCommand request, CancellationToken cancellationToken) {
            
            var storage = new Storage {
                Id = Guid.NewGuid(),
                Owner = request.Owner,
            };

            await unitOfWork.Storage.AddAsync(storage, cancellationToken);
            await unitOfWork.SaveAsync(cancellationToken);
            return storage.Id;
        }
    }
}