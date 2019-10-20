
using Microsoft.AspNetCore.Builder;

namespace ReserB.Middleware
{
	public static class AuthorizationMiddlewareExtensions
	{
		public static IApplicationBuilder UseAuthorization(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<AuthorizationMiddleware>();
		}
	}
}
