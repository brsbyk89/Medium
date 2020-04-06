using Medium.Business.Contracts;
using Medium.Data.Contracts;
using System;
using Microsoft.Extensions.DependencyInjection;


namespace Medium.Business
{
    public class MediumEngine : IMediumEngine
    {
        private IServiceProvider _serviceProvider { get; set; }
        public MediumEngine(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public string Add()
        {
            return _serviceProvider.GetService<IMediumRepository>().Add();
        }
    }
}
