using System;
using MediatR;

namespace CommandsAndQueries {
    public class AddStorageCommand : IRequest<Guid> {
        public Guid Id { get; set; }
        public string Owner { get; set; }

    }
}