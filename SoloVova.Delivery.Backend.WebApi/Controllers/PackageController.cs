using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoloVova.Delivery.Backend.Application.Interfaces;
using SoloVova.Delivery.Backend.Application.Treatments.Package.Commands.CreatePackage;
using SoloVova.Delivery.Backend.Application.Treatments.Package.Commands.DeletePackage;
using SoloVova.Delivery.Backend.Application.Treatments.Package.Commands.UpdatePackage;
using SoloVova.Delivery.Backend.Application.Treatments.Package.Queries.GetPackageDetails;
using SoloVova.Delivery.Backend.Application.Treatments.Package.Queries.GetPackageList;
using SoloVova.Delivery.Backend.WebApi.Models;

namespace SoloVova.Delivery.Backend.WebApi.Controllers{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class PackageController : BaseController{
        private readonly int _timedelay = 2000;

        /// <summary>
        /// Gets the list of notes
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /note
        /// </remarks>
        /// <returns>Returns NoteListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet]
        public async Task<ActionResult<PackageListVm>> GetAll(){
            Thread.Sleep(_timedelay);

            var query = new GetPackageListQuery(){
                UserId = Guid.Empty
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


        /// <summary>
        /// Gets the note by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /note/D34D349E-43B8-429E-BCA4-793C932FD580
        /// </remarks>
        /// <param name="id">Note id (guid)</param>
        /// <returns>Returns NoteDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user in unauthorized</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<PackageDetailsDto>> Get(Guid id){
            Thread.Sleep(_timedelay);
            var query = new GetPackageDetailsQuery(){
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the note
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /note
        /// {
        ///     title: "note title",
        ///     details: "note details"
        /// }
        /// </remarks>
        /// <param name="createPackageDto">CreateNoteDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePackageDto createPackageDto){
            // var command = _mapper.Map < CreateNoteCommand > (createNoteDto);
            // command.UserId = UserId;
            // var noteId = await Mediator.Send(command);
            Thread.Sleep(_timedelay);
            var query = new CreatePackageCommand(){
                IdCreateUser = Guid.NewGuid(),
                Title = createPackageDto.Title ?? "",
                Details = createPackageDto.Details ?? ""
            };

            var packageId = await Mediator.Send(query);
            return Ok(packageId);
        }

        /// <summary>
        /// Updates the note
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /note
        /// {
        ///     title: "updated note title"
        /// }
        /// </remarks>
        /// <param name="updatePackageDto">UpdateNoteDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePackageDto updatePackageDto){
            Thread.Sleep(_timedelay);
            var command = new UpdatePackageCommand(){
                Id = updatePackageDto.Id,
                Title = updatePackageDto.Title ?? "",
                Details = updatePackageDto.Details ?? ""
            };

            // var command = _mapper.Map<UpdateNoteCommand>(updateNoteDto);
            // command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }
        
        /// <summary>
        /// Deletes the note by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /note/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="id">Id of the note (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id){
            Thread.Sleep(_timedelay);
            var command = new DeletePackageCommand(){
                Id = id
            };

            await Mediator.Send(command);
            return NoContent();
        }
    }
}