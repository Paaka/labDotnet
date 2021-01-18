using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication3.Middlewares
{
    public class TimeMiddleware
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;

        public TimeMiddleware(RequestDelegate next, ILogger<TimeMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            await _next(httpContext);

            _logger.LogInformation($"Executed in {stopWatch.ElapsedMilliseconds}ms");
            Console.WriteLine($"Executed in {stopWatch.ElapsedMilliseconds}ms");
        }
    }
}
