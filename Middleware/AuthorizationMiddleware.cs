using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ReserB.Middleware
{
	public class AuthorizationMiddleware
	{
		RequestDelegate nextMiddleware;
		public AuthorizationMiddleware(RequestDelegate nextMiddleware)
		{
			this.nextMiddleware = nextMiddleware;
		}
		public async Task Invoke(HttpContext context)
		{

			await nextMiddleware.Invoke(context);
		}
	}
}
