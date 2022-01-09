using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Db.Dto;
using Exam.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers
{
    public class GameController : Controller
    {
        private readonly HttpClient _client = new();
        private readonly Uri _getRandomMonstersUri = new("https://localhost:5003/Monsters/RandomMonster");

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Start(PlayerDto player)
        {
            var randomMonster = await _client.GetFromJsonAsync<MonsterDto>(_getRandomMonstersUri);
            return default;
        }
    }
}