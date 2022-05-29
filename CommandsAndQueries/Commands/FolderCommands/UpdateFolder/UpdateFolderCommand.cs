using System;
using MediatR;

namespace CommandsAndQueries {
    public class UpdateFolderCommand : IRequest {

        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}