﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoloVova.Delivery.Backend.Application.Interfaces;
using SoloVova.Delivery.Backend.Application.Treatments.Package.Queries.GetPackageDetails;
using SoloVova.Delivery.Backend.Application.Treatments.Package.Queries.GetPackageList;

namespace SoloVova.Delivery.Backend.WebApi.Controllers{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PackageController : BaseController{
        private  IDeliveryDbContext _dbContext;
        
        public PackageController(IDeliveryDbContext dbContext){
            _dbContext = dbContext;
        }
        
        [HttpGet]
        public async Task<ActionResult<PackageListVm>> GetAll(){
            Thread.Sleep( 3000 );
            var query = new GetPackageListQuery(){
                UserId = Guid.Empty
            };
            var getPackageListQueryHandler = new GetPackageListQueryHandler(_dbContext);
            var vm = await getPackageListQueryHandler.Handle(query, CancellationToken.None);
            //var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        

        [HttpGet("{id}")]
        public async Task<ActionResult<PackageDetailsDto>> Get(Guid id){
            Thread.Sleep( 3000 );
            var query = new GetPackageDetailsQuery(){
                Id = id
            };
            var getPackageDetailsQueryHandler = new GetPackageDetailsQueryHandler(_dbContext);
            var vm = await getPackageDetailsQueryHandler.Handle(query, CancellationToken.None);
            //var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        // [HttpPost]
        // public async Task<ActionResult<Guid>> Create([FromBody] CreateNoteDto createNoteDto){
        //     var command = _mapper.Map < CreateNoteCommand > (createNoteDto);
        //     command.UserId = UserId;
        //     var noteId = await Mediator.Send(command);
        //     return Ok(noteId);
        // }

        // [HttpPut]
        // public async Task<IActionResult> Update([FromBody] UpdateNoteDto updateNoteDto){
        //     var command = _mapper.Map<UpdateNoteCommand>(updateNoteDto);
        //     command.UserId = UserId;
        //     await Mediator.Send(command);
        //     return NoContent();
        // }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> Delete(Guid id){
        //     var command = new DeleteNoteCommand(){
        //         Id = id,
        //         UserId = UserId
        //     };
        //     await Mediator.Send(command);
        //     return NoContent();
        // }

    }
}