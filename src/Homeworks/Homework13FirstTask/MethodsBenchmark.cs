using System.Reflection;
using BenchmarkDotNet.Attributes;

namespace Homework13FirstTask
{
	[MemoryDiagnoser]
	[MinColumn]
	[MaxColumn]
	[MedianColumn]
	[MeanColumn]
	[StdDevColumn]
	public class MethodsBenchmark
	{
		private Test _test;
		private string _testNumber;
		private static MethodInfo _methodFromTest;

		[GlobalSetup]
		public void Setup()
		{
			_test = new Test();
			_methodFromTest = typeof(Test).GetMethod("ReflectionMethod");
			_testNumber = "10";
		}

		[Benchmark(Description = "simple method")]
		public void TestSimpleMethod()
		{
			_test.SimpleMethod(_testNumber);
		}

		[Benchmark(Description = "static method")]
		public void TestStaticMethod()
		{
			Test.StaticMethod(_testNumber);
		}

		[Benchmark(Description = "virtual method")]
		public void TestVirtualMethod()
		{
			_test.VirtualMethod(_testNumber);
		}

		[Benchmark(Description = "generic method")]
		public void TestGenericMethod()
		{
			_test.GenericMethod<string>(_testNumber);
		}

		[Benchmark(Description = "reflection method")]
		public void TestReflectionMethod()
		{
			_methodFromTest.Invoke(_test, new object[] {_testNumber});
		}

		[Benchmark(Description = "dynamic method")]
		public void TestDynamicMethod()
		{
			_test.DynamicMethod(_testNumber);
		}
	}
}