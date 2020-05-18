using System.Collections.Generic;
using AutoMapper;
using WNSA.Data;
using WNSA.Dtos;
using WNSA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;

namespace WNSA.Controllers
{
    
    // api/commands   
    //[Route("api/[controller]")]  // performs text substitution
  //  [Route("api/WNSA_Demo")]

    [Route("api/WNSA_Demo")]

    [ApiController]  // Api controller attribute - gives some default behaviour out of the box
    public class WNSAController : ControllerBase
    {
        public IMapper _mapper { get; }

        private readonly IWNSARepo _repository;

        public WNSAController(IWNSARepo repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository  = repository;
        }

      // No longer needed as the repository is injected into the constructor
      //  private readonly MockWNSARepo _repository = new MockWNSARepo();

         // GET api/commands
        [HttpGet]
        public ActionResult <IEnumerable<WNSAReadDto>> GetAllCommands()
        {
            var commandItems =  _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<WNSAReadDto>>(commandItems));
        }

        // GET api/commands/{id}
        [HttpGet("{id}", Name="GetCommandById")]        
        public ActionResult <WNSAReadDto> GetCommandById(int id)
        {
            var commandItem =  _repository.GetCommandById(id);  // Binding Sources - decoration gives default behaviour
            if (commandItem != null)
            {
                return Ok(_mapper.Map<WNSAReadDto>(commandItem));
            }
            return NotFound();
           
        }


        // POST api/commands
        [HttpPost]
        public ActionResult <WNSAReadDto>  CreateCommand(WNSACreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<WNSAModel>(commandCreateDto);
            // CGM Validate
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<WNSAReadDto>(commandModel);

            return CreatedAtRoute( nameof(GetCommandById), new {Id = commandReadDto.Id}, commandReadDto);
           // return Ok(commandReadDto);  
        }

         //PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand( int id, WNSAUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);   
          
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(commandUpdateDto, commandModelFromRepo);

            _repository.UpdateCommand(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        } 
        
      //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<WNSAUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<WNSAUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if(!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdateCommand(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
    
        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null)
            {
             
                return NotFound();
            }
        
            _repository.DeleteCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}