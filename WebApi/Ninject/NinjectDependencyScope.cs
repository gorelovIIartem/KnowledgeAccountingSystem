using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Ninject.Syntax;
using System.Web.Http.Dependencies;

namespace WebApi.Ninject
{
    public class NinjectDependencyScope:IDependencyScope
    {
        private IResolutionRoot _resolver;

        internal NinjectDependencyScope(IResolutionRoot resolver)
        {
            _resolver = resolver;
        }
        public object GetService(Type serviceType)
        {
            return _resolver.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _resolver.GetAll(serviceType);
        }
        public void Dispose()
        {
            var disposable = _resolver as IDisposable;
            if(disposable !=null)
            {
                disposable.Dispose();
            }
            _resolver = null;
        }
    }
}