using System.Threading.Tasks;
using Db.Dto;
using Db.Models;
using Db.Service;
using Microsoft.AspNetCore.Mvc;

namespace Db.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MonstersController : ControllerBase
    {
        private readonly MonsterService _monsterService;

        public MonstersController(MonsterService monsterService)
        {
            _monsterService = monsterService;
        }

        [HttpGet]
        [Route("RandomMonster")]
        public async Task<JsonResult> GetRandomMonster()
        {
            return new JsonResult(await _monsterService.GetRandomMonster());
        }
    }
}