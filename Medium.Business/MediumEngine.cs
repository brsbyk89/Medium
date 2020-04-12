using Medium.Business.Contracts;
using Medium.Data.Contracts;
using System;
using Microsoft.Extensions.DependencyInjection;
using Medium.Client.Entities;
using Medium.Business.Entities;

namespace Medium.Business
{
    public class MediumEngine : IMediumEngine
    {
        private IServiceProvider _serviceProvider { get; set; }
        public MediumEngine(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public bool AddStory(AddStoryRequest request)
        {
            var story = new Story()
            {
                Description = request.Description,
                Title = request.Title
            };

            var result = _serviceProvider.GetService<IMediumRepository>().Create(story).Id;

            return result != 0;
        }
    }
}
