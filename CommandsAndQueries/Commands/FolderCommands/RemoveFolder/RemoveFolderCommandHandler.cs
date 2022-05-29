using DataBase;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UoW;

namespace CommandsAndQueries {
    public class RemoveFolderCommandHandler : IRequestHandler<RemoveFolderCommand> {
       
        private readonly IUnitOfWork unitOfWork;
       
        public RemoveFolderCommandHandler(IUnitOfWork unitOfWork) {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(RemoveFolderCommand request, CancellationToken cancellationToken) {
            var folder = await unitOfWork.Folder.GetByIdAsync(request.Id, cancellationToken);
            if(folder == null)
                throw new NotFoundException(nameof(Folder), request.Id);
            unitOfWork.Folder.Remove(folder.Id);
            await unitOfWork.SaveAsync(cancellationToken);
            return Unit.Value;
        }
 
    }
}