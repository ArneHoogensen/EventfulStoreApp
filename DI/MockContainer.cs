using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;

namespace DI
{
    public class MockContainer : IDIContainer
    {
        MockModule _module = new MockModule();
        IKernel _kernel;
        public MockContainer()
        {
            _kernel = new StandardKernel(_module);
        }
        public T Get<T>()
        {
            return _kernel.Get<T>();
        }
    }
}
