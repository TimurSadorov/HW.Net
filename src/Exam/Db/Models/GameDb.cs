using Microsoft.EntityFrameworkCore;

namespace Db.Models
{
    public class GameDb : DbContext
    {
        public DbSet<Monster> Monsters { get; set; }

        public GameDb(DbContextOptions<GameDb> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Monster>().HasData(
                new Monster
                {
                    AttackModifier = 10, ArmorClass = 10, Damage = 5,
                    Name = "Лось", Weapon = 10, DamageModifier = 4,
                    HitPoints = 79, AttackPerRound = 3, MonsterId = 1
                }, new Monster
                {
                    AttackModifier = 4, ArmorClass = 4, Damage = 4,
                    Name = "Кошка", Weapon = 3, DamageModifier = 1,
                    HitPoints = 20, AttackPerRound = 2, MonsterId = 2
                }, new Monster
                {
                    AttackModifier = 1, ArmorClass = 10, Damage = 2,
                    Name = "Амерго", Weapon = 3, DamageModifier = 3,
                    HitPoints = 50, AttackPerRound = 2, MonsterId = 3
                }, new Monster
                {
                    AttackModifier = 4, ArmorClass = 2, Damage = 1,
                    Name = "Дерро", Weapon = 1, DamageModifier = 3,
                    HitPoints = 69, AttackPerRound = 2, MonsterId = 4
                }, new Monster
                {
                    AttackModifier = 2, ArmorClass = 11, Damage = 6,
                    Name = "Савид", Weapon = 2, DamageModifier = 4,
                    HitPoints = 80, AttackPerRound = 4, MonsterId = 5
                });
        }
    }
}