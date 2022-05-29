using AutoMapper;
using DataBase;
using ViewModels;

namespace CommandsAndQueries {
    public class FileMapper : Profile {
        public FileMapper() { CreateMap<File, FileModel>().ReverseMap(); }
    }
}