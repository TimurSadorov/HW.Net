using System;
using System.Linq;
using System.Threading.Tasks;
using Db.Dto;
using Db.Models;
using Microsoft.EntityFrameworkCore;

namespace Db.Service
{
    public class MonsterService
    {
        private readonly GameDb _dbGame;
        public MonsterService(GameDb dbGame)
        {
            _dbGame = dbGame;
        }

        public async Task<MonsterDto> GetRandomMonster()
        {
            var r = new Random();
            var randomSkip = (int) (r.NextDouble() * _dbGame.Monsters.Count());
            return new MonsterDto(await _dbGame.Monsters.Skip(randomSkip).FirstAsync());
        }
    }
}