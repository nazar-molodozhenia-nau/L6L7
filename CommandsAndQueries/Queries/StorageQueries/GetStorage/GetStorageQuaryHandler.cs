using MediatR;
using ViewModels;
using UoW;
using DataBase;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;

namespace CommandsAndQueries {
    public class GetStorageQueryHandler : IRequestHandler<GetStorageQuery, StorageModel> {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetStorageQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<StorageModel> Handle(GetStorageQuery request, CancellationToken cancellationToken) {
            var club = await unitOfWork.Storage.GetByIdAsync(request.Id, cancellationToken);
            if(club == null || club.Id != request.Id)
                throw new NotFoundException(nameof(Storage), request.Id);
            return mapper.Map<StorageModel>(club);
        }

    }
}