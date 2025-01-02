using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Application.Interfaces
{
    public interface IAIDreamInterpreterService
    {
        Task<string> InterpretDreamAsync(string dreamDescription);
    }
}
