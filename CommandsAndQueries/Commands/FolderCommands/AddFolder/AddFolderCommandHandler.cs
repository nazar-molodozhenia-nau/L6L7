using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UoW;
using DataBase;

namespace CommandsAndQueries {
    public class AddFolderCommandHandler : IRequestHandler<AddFolderCommand, Guid> {
        private readonly IUnitOfWork unitOfWork;
        public AddFolderCommandHandler(IUnitOfWork unitOfWork) =>
           this.unitOfWork = unitOfWork;

        public async Task<Guid> Handle(AddFolderCommand request, CancellationToken cancellationToken) {

            var folder = new Folder {
                Id = Guid.NewGuid(),
                Name = request.Name,
            };
          
            await unitOfWork.Folder.AddAsync(folder, cancellationToken);
            await unitOfWork.SaveAsync(cancellationToken);
            return folder.Id;
        }
    }
}
