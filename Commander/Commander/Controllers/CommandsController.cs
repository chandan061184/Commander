using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commander.Data;
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
        public CommandsController(ICommanderRepo repository)
        {
            _repository = repository;
        }
        // Get api/commands
        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            return Ok(commandItems);
            
        }
        // Get api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult <Command> GetCommandById(int id)
        {
            var command = _repository.GetCommandById(id);
            return Ok(command);
        }
    }
}