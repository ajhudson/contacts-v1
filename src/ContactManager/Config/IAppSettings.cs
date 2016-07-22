using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Config
{
    public interface IAppSettings
    {
        string Title { get; }
        string ConnectionString { get; }
    }
}
