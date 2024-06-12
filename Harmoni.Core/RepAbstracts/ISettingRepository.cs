using Harmoni.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.Core.RepAbstracts
{
    public interface ISettingRepository:IGenericRepository<Setting>
    {
          Dictionary<string, string> GetSettingAsync(Func<Setting, bool>? func = null);
    }
}
