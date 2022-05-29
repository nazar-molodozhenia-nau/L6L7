using MediatR;
using ViewModels;
using UoW;
using DataBase;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;

namespace CommandsAndQueries {
    public class GetFileQueryHandler : IRequestHandler<GetFileQuery, FileModel> {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetFileQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<FileModel> Handle(GetFileQuery request, CancellationToken cancellationToken) {
            var user = await unitOfWork.File.GetUserAsync(request.Id);
            if(user == null || user.Id != request.Id)
                throw new NotFoundException(nameof(File), request.Id);
            return mapper.Map<FileModel>(user);
        }
 
    }
}