using System.Collections.Generic;
using MediatR;
using ViewModels;

namespace CommandsAndQueries {
    public class GetFileListQuery : IRequest<List<FileModel>> { }
}