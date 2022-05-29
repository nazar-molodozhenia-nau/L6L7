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

    public class StorageController : BaseController {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        public StorageController(IMediator mediator, IMapper mapper) {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<StorageModel>>> GetAll() {
            var query = new GetStorageListQuery { };
            var vm = await mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StorageModel>> Get(Guid id) {
            var query = new GetStorageQuery { Id = id };
            var vm = await mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Add([FromBody] AddStorageModel addClubModel) {
            var command = mapper.Map<AddFileCommand>(addClubModel);
            var clubId = await mediator.Send(command);
            return Created($"{clubId}", clubId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateStorageModel updateClubModel) {
            var command = mapper.Map<UpdateFileCommand>(updateClubModel);
            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id) {
            var command = new RemoveFileCommand { Id = id };
            await mediator.Send(command);
            return NoContent();
        }
    }
}