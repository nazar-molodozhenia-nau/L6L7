using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ViewModels;
using AutoMapper;
using UoW;

namespace CommandsAndQueries {
    public class GetStorageListQueryHandler : IRequestHandler<GetStorageListQuery, List<StorageModel>> {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetStorageListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<StorageModel>> Handle(GetStorageListQuery request, CancellationToken cancellationToken) {
            var clubs = await unitOfWork.Storage.GetAllAsync(cancellationToken);
            return mapper.Map<List<StorageModel>>(clubs);
        }

    }
}