using System;
using MediatR;

namespace CommandsAndQueries {
    public class RemoveStorageCommand : IRequest {
        public Guid Id { get; set; }
    }
}