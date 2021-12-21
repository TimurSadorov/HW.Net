using System.Reflection;
using BenchmarkDotNet.Running;

namespace Homework13FirstTask
{
	class Program
	{
		static void Main(string[] args)
		{
			BenchmarkRunner.Run<MethodsBenchmark>();
		}
    }
}