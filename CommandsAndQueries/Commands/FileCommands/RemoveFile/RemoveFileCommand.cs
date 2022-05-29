using System;
using MediatR;

namespace CommandsAndQueries {
    public class RemoveFileCommand : IRequest {
        public Guid Id { get; set; }
    }
}