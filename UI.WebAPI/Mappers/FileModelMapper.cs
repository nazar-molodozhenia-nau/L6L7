using CommandsAndQueries;
using AutoMapper;

namespace UI.WebAPI
{
    public class FileModelMapper : Profile
    {
        public FileModelMapper()
        {
            CreateMap<AddFilesModel, AddStorageCommand>();
            CreateMap<UpdateFileModel, UpdateStorageCommand>();
        }
    }
}
