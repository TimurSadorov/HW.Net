using System;
using Homework11.Exceptions;
using Microsoft.Extensions.Logging;

namespace WebApplication.Services
{
	public class ExceptionHandler : IExceptionHandler
	{
		private readonly ILogger<ExceptionHandler> _logger;

		public ExceptionHandler(ILogger<ExceptionHandler> logger)
		{
			_logger = logger;
		}

		public void HandleException<T>(T exception) where T : Exception
		{
			this.Handle((dynamic) exception);
		}

		public void Handle(InvalidNumberException exception)
		{
			_logger.LogError($"Invalid number: {exception.Message}");
		}

		public void Handle(InvalidSyntaxException exception)
		{
			_logger.LogError($"Invalid syntax: {exception.Message}");
		}
		
		public void Handle(InvalidSymbolException exception)
		{
			_logger.LogError($"Invalid symbol: {exception.Message}");
		}
	}
}