using System.Collections.Generic;
using MediatR;
using ViewModels;

namespace CommandsAndQueries {
    public class GetFolderListQuery : IRequest<List<FolderModel>> { }
}