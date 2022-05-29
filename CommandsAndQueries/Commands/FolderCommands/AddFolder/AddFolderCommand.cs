using System;
using MediatR;

namespace CommandsAndQueries {
    public class AddFolderCommand : IRequest<Guid> {

        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}