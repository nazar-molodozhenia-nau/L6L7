using DataBase;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UoW;

namespace CommandsAndQueries {
    public class RemoveFileCommandHandler : IRequestHandler<RemoveFileCommand> {

        private readonly IUnitOfWork unitOfWork;

        public RemoveFileCommandHandler(IUnitOfWork unitOfWork) {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(RemoveFileCommand request, CancellationToken cancellationToken) {
            var file = await unitOfWork.File.GetByIdAsync(request.Id, cancellationToken);
            if(file == null)
                throw new NotFoundException(nameof(File), request.Id);
            unitOfWork.File.Remove(file.Id);
            await unitOfWork.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}