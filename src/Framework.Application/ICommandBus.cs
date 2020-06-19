using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Application
{
    public interface ICommandBus
    {
        Task Dispatch<T>(T command) where T : Command;
    }
}
