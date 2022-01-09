using System.ComponentModel.DataAnnotations;

namespace Db.Models
{
    public class Monster
    {
        public int MonsterId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required, Range(0, 100)]
        public int HitPoints { get; set; }
        [Required]
        public int AttackModifier { get; set; }
        public int AttackPerRound { get; set; }
        public int Damage { get; set; }
        public int DamageModifier { get; set; }
        public int Weapon { get; set; }
        public int ArmorClass { get; set; }
    }
}