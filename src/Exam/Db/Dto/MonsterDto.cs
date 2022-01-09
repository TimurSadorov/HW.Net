using Db.Models;

namespace Db.Dto
{
    public class MonsterDto
    {
        public MonsterDto()
        {
            
        }
        
        public MonsterDto(Monster monster)
        {
            Name = monster.Name;
            HitPoints = monster.HitPoints;
            AttackModifier = monster.AttackModifier;
            AttackPerRound = monster.AttackPerRound;
            Damage = monster.Damage;
            DamageModifier = monster.DamageModifier;
            Weapon = monster.Weapon;
            ArmorClass = monster.ArmorClass;
        }

        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int AttackModifier { get; set; }
        public int AttackPerRound { get; set; }
        public int Damage { get; set; }
        public int DamageModifier { get; set; }
        public int Weapon { get; set; }
        public int ArmorClass { get; set; }
    }
}