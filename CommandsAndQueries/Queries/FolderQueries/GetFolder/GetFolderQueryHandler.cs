using MediatR;
using ViewModels;
using UoW;
using DataBase;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;

namespace CommandsAndQueries {
    public class GetFolderQueryHandler : IRequestHandler<GetFolderQuery, FolderModel> {
        
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        
        public GetFolderQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<FolderModel> Handle(GetFolderQuery request, CancellationToken cancellationToken) {
            var clubPass = await unitOfWork.Folder.GetByIdAsync(request.Id, cancellationToken);
            if(clubPass == null || clubPass.Id != request.Id)
                throw new NotFoundException(nameof(Folder), request.Id);
            return mapper.Map<FolderModel>(clubPass);
        }

    }
}