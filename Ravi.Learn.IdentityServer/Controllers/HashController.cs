using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ravi.Learn.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HashController : ControllerBase
    {
        [HttpGet]
        [Route("{secret}")]
        public ActionResult<string> Get(string secret)
        {
            return Ok(secret.Sha256());
        }
    }
}