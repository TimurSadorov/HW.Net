using System;

namespace Homework11.Exceptions
{
	public class InvalidNumberException: Exception
	{
		public InvalidNumberException(string message)
			: base(message)
		{
		}
	}
}