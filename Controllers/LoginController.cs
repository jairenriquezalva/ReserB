using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReserB.Services;

namespace ReserB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
		readonly LoginService _service;
		
		public LoginController(LoginService service)
		{
			_service = service;
		}

		[HttpPost]
		public async Task<ActionResult> Login(Credentials credentials)
		{
			var customer = await _service.Login(credentials.EMail, credentials.Password);
			if (customer.Id != "-1" && customer.Id != "0")
			{
				HttpContext.Session.SetString("user", credentials.EMail);
				return new JsonResult(new {status = "success", customer });
			}else if (customer.Id != "0")
			{
				return new JsonResult(new { status = "invalid username" });
			}
			return new JsonResult(new {status = "invalid password" });
		}

		[HttpPost("provider")]
		public async Task<ActionResult> LoginProvider(Credentials credentials)
		{
			var provider = await _service.LoginProvider(credentials.EMail, credentials.Password);
			if(provider.Id != "-1" && provider.Id != "0")
			{
				HttpContext.Session.SetString("user", credentials.EMail);
				return new JsonResult(new { status = "success", provider });
			}
			else if( provider.Id != "0")
			{
				return new JsonResult(new { status = "invalid username" });
			}
			return new JsonResult(new { status = "invalid password" });
		}

		public class Credentials
		{
			public string EMail { get; set; }
			public string Password { get; set; }
		}
    }
}
