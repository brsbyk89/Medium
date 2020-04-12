using Medium.Business.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.DependencyInjection;
using Medium.Helper;
using Medium.Client.Entities;

namespace Medium.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MediumController : ControllerBase
    {
        IServiceProvider _serviceProvider { get; set; }

        public MediumController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpPost]
        [Route("AddStory")]
        public bool AddStory(AddStoryRequest request)
        {
            return _serviceProvider.GetService<IMediumEngine>().AddStory(request);
        }

        [HttpGet]
        [Route("GetAll")]
        public bool GetAll()
        {
            return true;
        }

        [HttpGet]
        [Route("UnHandleError")]
        public string UnHandleError()
        {
            int x = 0;
            int t = 10 / x;

            return t.ToString();
        }

        [HttpGet]
        [Route("HandleError")]
        public string HandleError()
        {
            int mediumStoryCount = 0;

            if (mediumStoryCount == 0)
            {
                throw new MediumApiException("Minimum 1 tane yayınlanmış hikayeniz olmak zorundadır");
            }

            return mediumStoryCount.ToString();
        }
    }
}
