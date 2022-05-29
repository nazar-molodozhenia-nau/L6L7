using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using UoW;
using ViewModels;

namespace CommandsAndQueries {
    public class GetUserListQueryHandler : IRequestHandler<GetFileListQuery, List<FileModel>> {
        
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        
        public GetUserListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<FileModel>> Handle(GetFileListQuery request, CancellationToken cancellationToken) {
            var users = await unitOfWork.File.GetAllAsync(cancellationToken);
            return mapper.Map<List<FileModel>>(users);
        }
    
    }
}