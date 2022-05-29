using AutoMapper;
using DataBase;
using ViewModels;

namespace CommandsAndQueries {
    public class FolderMapper : Profile {
        public FolderMapper() { CreateMap<Folder, FolderModel>().ReverseMap(); }
    }
}