using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UoW;
using DataBase;

namespace CommandsAndQueries {
    public class AddFileCommandHandler : IRequestHandler<AddFileCommand, Guid> {
        
        private readonly IUnitOfWork unitOfWork;
        
        public AddFileCommandHandler(IUnitOfWork unitOfWork) =>
           this.unitOfWork = unitOfWork;

        public async Task<Guid> Handle(AddFileCommand request, CancellationToken cancellationToken) {
            var file = new File {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Type = request.Type,
            };
            await unitOfWork.File.AddAsync(file, cancellationToken);
            await unitOfWork.SaveAsync(cancellationToken);
            return file.Id;
        }

    }
}