using System;

namespace Homework11.Exceptions
{
	public class InvalidSymbolException: Exception
	{
		public InvalidSymbolException(string message)
			: base(message)
		{
		}
	}
}