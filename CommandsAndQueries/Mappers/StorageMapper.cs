using AutoMapper;
using DataBase;
using ViewModels;

namespace CommandsAndQueries {
    public class StorageMapper : Profile {
        public StorageMapper() { CreateMap<Storage, StorageModel>().ReverseMap(); }
    }
}