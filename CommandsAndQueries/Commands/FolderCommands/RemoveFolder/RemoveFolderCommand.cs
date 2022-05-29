using System;
using MediatR;

namespace CommandsAndQueries {
    public class RemoveFolderCommand : IRequest {
        public Guid Id { get; set; }
    }
}