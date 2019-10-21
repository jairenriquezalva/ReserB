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
			if (await _service.Login(credentials.EMail, credentials.Password))
			{
				HttpContext.Session.SetString("user", credentials.EMail);
				return StatusCode(StatusCodes.Status202Accepted);
			}
			return StatusCode(StatusCodes.Status401Unauthorized);
		}

		public class Credentials
		{
			public string EMail { get; set; }
			public string Password { get; set; }
		}
    }
}