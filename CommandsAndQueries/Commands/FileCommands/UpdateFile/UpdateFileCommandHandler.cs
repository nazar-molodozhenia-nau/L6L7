using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UoW;
using ViewModels;
using DataBase;

namespace CommandsAndQueries {
    public class UpdateFileCommandHandler : IRequestHandler<UpdateFileCommand> {
    
        private readonly IUnitOfWork unitOfWork;
        public UpdateFileCommandHandler(IUnitOfWork unitOfWork) =>
            this.unitOfWork = unitOfWork;

        public async Task<Unit> Handle(UpdateFileCommand request, CancellationToken cancellationToken) {
            var file = await unitOfWork.File.GetByIdAsync(request.Id, cancellationToken);
            if(file == null)
                throw new NotFoundException(nameof(File), request.Id);
            file.Id = request.Id;
            file.Name = request.Name;
            file.Type = request.Type;
            await unitOfWork.SaveAsync(cancellationToken);
            return Unit.Value;
        }
 
    }
}