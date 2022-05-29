using System;
using MediatR;

namespace CommandsAndQueries {
    public class UpdateStorageCommand : IRequest {
        public Guid Id { get; set; }
        public string Owner { get; set; }
    }
}