﻿using System;
using BenchmarkDotNet.Running;

namespace Homework12
{
	class Program
	{
		static void Main(string[] args)
		{
			BenchmarkRunner.Run<WebTest>();
		}
	}
}