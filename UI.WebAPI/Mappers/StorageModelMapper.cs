using CommandsAndQueries;
using AutoMapper;

namespace UI.WebAPI {
    public class StorageModelMapper : Profile {
        public StorageModelMapper() {
            CreateMap<AddStorageModel, AddFolderCommand>();
            CreateMap<UpdateStorageModel, UpdateFolderCommand>();
        }
    }
}