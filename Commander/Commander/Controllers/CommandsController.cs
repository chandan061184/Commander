using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        /* Dependency injection : Create a variable of Interface and inject in the
           constructor of the class. */
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;
        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // Get api/commands
        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
            
        }
        // Get api/commands/{id}
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult <Command> GetCommandById(int id)
        {
            var command = _repository.GetCommandById(id);
            if(command != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(command));
            }
            return NotFound();
            
        }
        //Post api/commands
        [HttpPost]
        public ActionResult <CommandReadDto> CreateCommand(CommandCreateDto cmd)
        {
            var commandCreateModel = _mapper.Map<Command>(cmd);
            _repository.CreateCommand(commandCreateModel);
            _repository.SaveChanges();
            var commandReadDto = _mapper.Map<CommandReadDto>(commandCreateModel);
            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandCreateModel.Id }, commandReadDto);
        }
    }
}