using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ViewModels;
using AutoMapper;
using UoW;

namespace CommandsAndQueries {
    public class GetFolderListQueryHandler : IRequestHandler<GetFolderListQuery, List<FolderModel>> {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetFolderListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<FolderModel>> Handle(GetFolderListQuery request, CancellationToken cancellationToken) {
            var clubPasses = await unitOfWork.Folder.GetAllAsync(cancellationToken);
            return mapper.Map<List<FolderModel>>(clubPasses);
        }

    }
}