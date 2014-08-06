using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;

namespace DI
{
    public class SimpleContainer : IDIContainer
    {
        SimpleModule _module = new SimpleModule();
        IKernel _kernel;
        public SimpleContainer()
        {
            _kernel = new StandardKernel(_module);
        }
        public T Get<T>()
        {
            return _kernel.Get<T>();
        }
    }
}
