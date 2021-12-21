namespace Homework13FirstTask
{
	class Test
	{
		public string SimpleMethod(string num)
		{
			num += num;
			return num;
		}

		public virtual string VirtualMethod(string num)
		{
			num += num;
			return num;
		}

		public static string StaticMethod(string num)
		{
			num += num;
			return num;
		}

		public string GenericMethod<T>(T num)
		{
			return num.ToString() + num;
		}

		public string DynamicMethod(dynamic num)
		{
			num += num.ToString();
			return num;
		}

		public string ReflectionMethod(string num)
		{
			num += num;
			return num;
		}
	}
}