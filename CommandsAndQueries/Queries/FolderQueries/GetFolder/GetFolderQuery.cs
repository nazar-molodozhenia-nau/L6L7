using System;
using MediatR;
using ViewModels;

namespace CommandsAndQueries {
    public class GetFolderQuery : IRequest<FolderModel> {
        public Guid Id { get; set; }
    }
}