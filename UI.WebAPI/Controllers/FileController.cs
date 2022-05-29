using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommandsAndQueries;
using MediatR;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace UI.WebAPI {

    [ApiController]
    [Route("api/[controller]")]

    public class FileController : BaseController {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        public FileController(IMediator mediator, IMapper mapper) {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<FileModel>>> GetAll() {
            var query = new GetFolderListQuery { };
            var vm = await mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FileModel>> Get(Guid id) {
            var query = new GetFolderQuery { Id = id };
            var vm = await mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Add([FromBody] AddFilesModel addClubPasModel) {
            var command = mapper.Map<AddStorageCommand>(addClubPasModel);
            var clubPass = await mediator.Send(command);
            return Created($"{clubPass}", clubPass);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateFileModel updateClubPassModel) {
            var command = mapper.Map<UpdateStorageCommand>(updateClubPassModel);
            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id) {
            var command = new RemoveStorageCommand { Id = id };
            await mediator.Send(command);
            return NoContent();
        }
    }
}