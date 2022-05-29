using System;
using MediatR;

namespace CommandsAndQueries {
    public class UpdateFileCommand : IRequest {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}