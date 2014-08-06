using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DI
{
    public class Container : IDIContainer
    {
        static IDIContainer container;

        private static IDIContainer LoadFromConfig()
        {
            //var val = System.Configuration.ConfigurationManager.AppSettings["DIContainer"];

            IDIContainer c;
            //if (!string.IsNullOrEmpty(val))
            //{
            //    var type = System.Type.GetType(val);
            //    if (type != null)
            //    {
            //        c = (type.Assembly.CreateInstance(type.FullName) as IDIContainer);
            //    }
            //    else
            //    {
            //        c = new SimpleContainer();
            //    }
            //}
            //else
            {
                c = new SimpleContainer();
            }
            return c;
        }

        public static object _lock = new object();
        public static IDIContainer Current
        {
            get
            {
                lock (_lock)
                {
                    if (container == null)
                    {
                        container = LoadFromConfig();
                    }
                    return container;
                }
            }
        }

        public T Get<T>()
        {
            return container.Get<T>();
        }
    }
}
