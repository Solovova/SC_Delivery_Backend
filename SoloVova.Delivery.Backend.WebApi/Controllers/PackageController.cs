using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoloVova.Delivery.Backend.Application.Interfaces;
using SoloVova.Delivery.Backend.Application.Treatments.Package.Commands.CreatePackage;
using SoloVova.Delivery.Backend.Application.Treatments.Package.Commands.UpdatePackage;
using SoloVova.Delivery.Backend.Application.Treatments.Package.Queries.GetPackageDetails;
using SoloVova.Delivery.Backend.Application.Treatments.Package.Queries.GetPackageList;
using SoloVova.Delivery.Backend.WebApi.Models;

namespace SoloVova.Delivery.Backend.WebApi.Controllers{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PackageController : BaseController{
        private  IDeliveryDbContext _dbContext;
        private readonly int _timedelay = 0;
        
        public PackageController(IDeliveryDbContext dbContext){
            _dbContext = dbContext;
        }
        
        [HttpGet]
        public async Task<ActionResult<PackageListVm>> GetAll(){
            Thread.Sleep( _timedelay );
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
            Thread.Sleep( _timedelay );
            var query = new GetPackageDetailsQuery(){
                Id = id
            };
            var getPackageDetailsQueryHandler = new GetPackageDetailsQueryHandler(_dbContext);
            var vm = await getPackageDetailsQueryHandler.Handle(query, CancellationToken.None);
            //var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePackageDto createPackageDto){
            // var command = _mapper.Map < CreateNoteCommand > (createNoteDto);
            // command.UserId = UserId;
            // var noteId = await Mediator.Send(command);
            Thread.Sleep( _timedelay );
            var query = new CreatePackageCommand(){
                IdCreateUser = Guid.NewGuid(),
                Title = createPackageDto.Title ?? "",
                Details = createPackageDto.Details ?? ""
            };
            var createPackageCommandHandler = new CreatePackageCommandHandler(_dbContext);
            var packageId = await createPackageCommandHandler.Handle(query, CancellationToken.None);
            
            return Ok(packageId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePackageDto updatePackageDto){
            Thread.Sleep( _timedelay );
            var query = new UpdatePackageCommand(){
                Id = updatePackageDto.Id,
                Title = updatePackageDto.Title ?? "",
                Details = updatePackageDto.Details ?? ""
            };
            var updatePackageCommandHandler = new UpdatePackageCommandHandler(_dbContext);

            await updatePackageCommandHandler.Handle(query, CancellationToken.None);
            
            // var command = _mapper.Map<UpdateNoteCommand>(updateNoteDto);
            // command.UserId = UserId;
            // await Mediator.Send(command);
            return NoContent();
        }

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