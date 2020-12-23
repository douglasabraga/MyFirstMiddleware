using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

public class MyMiddleware
{
	private readonly RequestDelegate _next;

	public MyMiddleware(RequestDelegate next)
    {
		_next = next;
    }

	public async Task InvokeAsync(HttpContext context)
    {
		Console.WriteLine("\n\r ---------- Antes ---------- \n\r");

		await _next(context);

		Console.WriteLine("\n\r ---------- Depois ---------- \n\r");
	}
}

public static class MyMiddlewareExtension
{
	public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
    {
		return builder.UseMiddleware<MyMiddleware>();
    }
}