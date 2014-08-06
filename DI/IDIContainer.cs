using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DI
{
    public interface IDIContainer
    {
        T Get<T>();
    }
}
