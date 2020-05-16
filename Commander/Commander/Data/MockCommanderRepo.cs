using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public IEnumerable<Command> GetAllCommands()
        {
            throw new NotImplementedException();
        }

        public Command GetCommandById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
