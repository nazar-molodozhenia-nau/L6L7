using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UoW;
using ViewModels;
using DataBase;

namespace CommandsAndQueries {
    public class UpdateFolderCommandHandler : IRequestHandler<UpdateFolderCommand> {
        
        private readonly IUnitOfWork unitOfWork;
        
        public UpdateFolderCommandHandler(IUnitOfWork unitOfWork) =>
            this.unitOfWork = unitOfWork;

        public async Task<Unit> Handle(UpdateFolderCommand request, CancellationToken cancellationToken) {
            var folder = await unitOfWork.File.GetByIdAsync(request.Id, cancellationToken);
            if(folder == null)
                throw new NotFoundException(nameof(File), request.Id);
            folder.Id = request.Id;
            folder.Name = request.Name;
            await unitOfWork.SaveAsync(cancellationToken);
            return Unit.Value;
        }

    }
}