using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProxyAPI.Models;

namespace ProxyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProxyController : ControllerBase
    {
        //private readonly ProxyContext _context;
        private ProxyServices _services;
        public ProxyController(ProxyContext context)
        {
            _services = new ProxyServices(new ProxyRepository(context));
        }

        // GET: api/Proxy
        [HttpGet]
        [Route("/api/proxy")]
        public IQueryable GetProxies(string region, string country)
        {
            var proxies = _services.GetProxies(region, country);

            return proxies;
        }
       
        [HttpPost]
        [Route("/api/proxy")]
        public IActionResult UploadFile(IFormFile file)
        {
            _services.ReadFile(file);
            
            return Ok();
        }

        [HttpPatch]
        [Route("/api/proxy")]
        public IActionResult UpdateProxy([FromBody] Proxy proxy)
        {
            _services.UpdateProxy(proxy);
            return Ok();
        }

        [HttpPut]
        [Route("/api/proxy")]
        public IActionResult AddProxy([FromBody] Proxy proxy)
        {
            _services.AddProxy(proxy);
            return Ok();
        }
        
        [HttpDelete]
        [Route("/api/proxy")]
        public IActionResult ClearDB()
        {
            _services.Cleardb();
            return Ok();
        }
    }
}
