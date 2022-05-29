using System.Collections.Generic;
using MediatR;
using ViewModels;

namespace CommandsAndQueries {
    public class GetStorageListQuery : IRequest<List<StorageModel>> { }
}