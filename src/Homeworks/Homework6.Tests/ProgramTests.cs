using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace Homework6.Tests
{
	public class HostBuilder : WebApplicationFactory<App.Startup>
	{
		protected override IHostBuilder CreateHostBuilder()
			=> Host
				.CreateDefaultBuilder()
				.ConfigureWebHostDefaults(a => a
					.UseStartup<App.Startup>()
					.UseTestServer());
	}
	public class ProgramTests : IClassFixture<HostBuilder>
	{
		private readonly HttpClient client;
		public ProgramTests(HostBuilder fixture)
		{
			client = fixture.CreateClient();
		}
		
		[Theory]
		[InlineData("2", "plus", "4", "6.0")]
		[InlineData("10", "minus", "4", "6.0")]
		[InlineData("3", "mult", "5", "15.0")]
		[InlineData("10", "divide", "5", "2.0")]
		[InlineData("2.3", "plus", "3.1", "5.4")]
		[InlineData("3.45", "minus", "5", "-1.55")]
		[InlineData("2.5", "mult", "0", "0.0")]
		[InlineData("1.5", "divide", "1.5", "1.0")]
		public async Task Main_CorrectExpression_ReturnCorrectResult(string v1,
			string operation,
			string v2,
			string expected)
		{
			await DoTest(v1, operation, v2, expected);
		}

		[Theory]
		[InlineData("x", "plus", "4", "\"Invalid syntax\"")]
		[InlineData("p", "minus", "4", "\"Invalid syntax\"")]
		[InlineData("dream", "mult", "team", "\"Invalid syntax\"")]
		[InlineData("10", "div", "5", "\"Valid operation, supported operations are plus mines mult divide\"")]
		[InlineData("2.3", "p", "3.1", "\"Valid operation, supported operations are plus mines mult divide\"")]
		[InlineData("3.45", "m", "5", "\"Valid operation, supported operations are plus mines mult divide\"")]
		public async Task Main_InvalidExpression_ReturnMessageError(string v1,
			string operation,
			string v2,
			string expected)
		{
			await DoTest(v1, operation, v2, expected);
		}
		
		[Theory]
		[InlineData("10", "divide", "0", "\"Division by zero is not possible\"")]
		[InlineData("2.4", "divide", "0", "\"Division by zero is not possible\"")]
		public async Task Main_DivideZero_ReturnMessageError(string v1,
			string operation,
			string v2,
			string expected)
		{
			await DoTest(v1, operation, v2, expected);
		}

		private async Task DoTest(string v1, string operation, string v2, string expected)
		{
			var response =
				await client.GetAsync($"http://localhost:5000/calculate?v1={v1}&Operation={operation}&v2={v2}");
			var result = await response.Content.ReadAsStringAsync();
			Assert.Equal(expected, result);
		}

		[Fact]
		public async Task Main_NonExistentPage_ReturnNotFound()
		{
			var response =
				await client.GetAsync($"http://localhost:5000/calc");
			var result = await response.Content.ReadAsStringAsync();
			Assert.Equal("Not Found", result);
		}
	}
}