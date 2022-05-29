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

    public class FolderController : BaseController {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        public FolderController(IMediator mediator, IMapper mapper) {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<FolderModel>>> GetAll() {
            var query = new GetFileListQuery { };
            var vm = await mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FolderModel>> Get(Guid id) {
            var query = new GetFileQuery { Id = id };
            var vm = await mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Add([FromBody] AddFolderModel addUserModel) {
            var command = mapper.Map<AddFolderCommand>(addUserModel);
            var userId = await mediator.Send(command);
            return Created($"{userId}", userId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateFolderModel updateUserModel) {
            var command = mapper.Map<UpdateFolderCommand>(updateUserModel);
            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id) {
            var command = new RemoveFolderCommand { Id = id };
            await mediator.Send(command);
            return NoContent();
        }
    }
}