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
            var commands = new List<Command>
            {
                new Command { Id = 0, HowTo = "Create Web API Core project", Line = "Test Web API Core", Platform = "LINUX" },
                new Command { Id = 0, HowTo = "Create web application project", Line = "Test application project", Platform = "Windows" },
                new Command { Id = 0, HowTo = "Create Razor page project", Line = "Test Razor page", Platform = "MAC" }
            };

            return commands;
        }

        public Command GetCommandById(int Id)
        {
            return new Command { Id = 0, HowTo = "Create Web API Core project", Line = "Test Web API Core", Platform = "LINUX" };
        }
    }
}
