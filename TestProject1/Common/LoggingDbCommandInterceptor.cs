using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Common
{
    public class LoggingDbCommandInterceptor : DbCommandInterceptor
    {
        private readonly ILogger<LoggingDbCommandInterceptor> _logger;

        public LoggingDbCommandInterceptor(ILogger<LoggingDbCommandInterceptor> logger)
        {
            _logger = logger;
        }

        public override InterceptionResult<int> NonQueryExecuting(
            DbCommand command, CommandEventData eventData, InterceptionResult<int> result)
        {
            _logger.LogInformation($"SQL Query: {command.CommandText}");
            return base.NonQueryExecuting(command, eventData, result);
        }

        public override InterceptionResult<DbDataReader> ReaderExecuting(
            DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
        {
            _logger.LogInformation($"SQL Query: {command.CommandText}");
            return base.ReaderExecuting(command, eventData, result);
        }
    }
}
