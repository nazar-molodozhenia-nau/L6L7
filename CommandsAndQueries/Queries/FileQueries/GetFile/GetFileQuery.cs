using System;
using MediatR;
using ViewModels;

namespace CommandsAndQueries {
    public class GetFileQuery : IRequest<FileModel> {
        public Guid Id { get; set; }
    }
}