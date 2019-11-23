using System;
using System.Collections.Generic;
using System.Text;

namespace BlueBoard.Persistence.Abstractions
{
    public interface IConnectionStringProvider
    {
        string GetConnectionString();
    }
}
