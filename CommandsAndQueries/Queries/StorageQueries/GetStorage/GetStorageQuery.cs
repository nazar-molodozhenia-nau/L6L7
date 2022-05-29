using System;
using MediatR;
using ViewModels;

namespace CommandsAndQueries {
    public class GetStorageQuery : IRequest<StorageModel> {
        public Guid Id { get; set; }
    }
}