using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CQRS2.Behaivor
{
    public class LogginBehaivor<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LogginBehaivor<TRequest, TResponse>> _logger;
        public LogginBehaivor(ILogger<LogginBehaivor<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            //pre
            _logger.Log(LogLevel.Debug,"befor");
            //logic

            var response = await next();
            //post
            _logger.Log(LogLevel.Debug, response.ToString());


            return response;


        }
    }
}
