using Medium.Business.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.DependencyInjection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Medium.Controllers
{
    [Route("api/[controller]")]
    public class MediumController : Controller
    {
        IServiceProvider _serviceProvider { get; set; }

        public MediumController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        // GET: api/<controller>
        [HttpPost]
        [Route("Add")]
        public string Add()
        {
            return _serviceProvider.GetService<IMediumEngine>().Add();
        }

        [HttpGet]
        public bool GetAll()
        {
            return true;
        }
    }
}
