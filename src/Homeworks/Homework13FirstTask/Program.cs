using System;
using System.Reflection;

namespace Homework13FirstTask
{
	class Program
	{
		private static readonly MethodInfo MethodFromTest = typeof(Test).GetMethod("ReflectionMethod");

		static void Main(string[] args)
		{
			var num = "10";
			var test = new Test();

			StartCycle(() => test.SimpleMethod(num));
			StartCycle(() => test.VirtualMethod(num));
			StartCycle(() => Test.StaticMethod(num));
			StartCycle(() => test.DynamicMethod(num));
			StartCycle(() => test.GenericMethod<int>(num));
			StartCycle(() => MethodFromTest.Invoke(test, new object[] {num}));
		}

		private static void StartCycle(Action action)
		{
			for (int i = 0; i < 10000000; i++)
				action();
		}
	}

	class Test
	{
		public string SimpleMethod(string num)
		{
			for (int i = 0; i < 1; i++)
			{
				num = num + i;
			}

			return num;
		}

		public virtual string VirtualMethod(string num)
		{
			for (int i = 0; i < 1; i++)
			{
				num = num + i;
			}

			return num;
		}

		public static string StaticMethod(string num)
		{
			for (int i = 0; i < 1; i++)
			{
				num = num + i;
			}

			return num;
		}

		public T GenericMethod<T>(string num)
		{
			for (int i = 0; i < 1; i++)
			{
				num = num + i;
			}

			return default;
		}

		public string DynamicMethod(dynamic num)
		{
			for (int i = 0; i < 1; i++)
			{
				num = num + i.ToString();
			}

			return num;
		}

		public string ReflectionMethod(string num)
		{
			for (int i = 0; i < 1; i++)
			{
				num = num + i;
			}

			return num;
		}
	}
}