using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using JetBrains.dotMemoryUnit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Homework13Calculator.MemoryTests
{
	public class HostBuilder : WebApplicationFactory<Startup>
	{
		protected override IHostBuilder CreateHostBuilder()
			=> Host
				.CreateDefaultBuilder()
				.ConfigureWebHostDefaults(a => a
					.UseStartup<Startup>()
					.UseTestServer());
	}
	
	public class Tests
	{
		private HttpClient _client;

		[SetUp]
		public void Setup()
		{
			_client = new HostBuilder().CreateClient();
		}

		[Test]
		[DotMemoryUnit(FailIfRunWithoutSupport = true,CollectAllocations = true)]
		public void TestMemoryAsync()
		{
			var memoryPoint = dotMemory.Check();
			for (int i = 0; i < 100; i++)
			{
				var expression = $"{i}+{i}";
				SendRequest(expression);
			}

			dotMemory.Check(
				memory => Assert.True(memory.GetTrafficFrom(memoryPoint).AllocatedMemory.ObjectsCount < 10000000));
		}

		private void SendRequest(string expression)
		{
			var stringContent = new StringContent($"expression={expression}", Encoding.UTF8);
			stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
			_client.PostAsync("https://localhost:5001/Calculator/Calculate", stringContent).GetAwaiter().GetResult();
		}
	}
}