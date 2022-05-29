using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandsAndQueries;
using AutoMapper;

namespace UI.WebAPI
{
    public class FolderModelMapper : Profile
    {
        public FolderModelMapper()
        {
            CreateMap<AddFolderModel, AddFolderCommand>();
            CreateMap<UpdateFolderModel, UpdateFolderCommand>();
        }
    }
}
