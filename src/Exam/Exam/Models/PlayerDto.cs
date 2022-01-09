using System.ComponentModel;

namespace Exam.Models
{
    public class PlayerDto
    {
        [DisplayName("User Name")]
        public string UserName { get; set; }
        [DisplayName("Hit Points")]
        public int HitPoints { get; set; }
        [DisplayName("Attack Modifier")]
        public int AttackModifier { get; set; }
        [DisplayName("Attack Per Round")]
        public int AttackPerRound { get; set; }
        [DisplayName("Damage")]
        public int Damage { get; set; }
        [DisplayName("Damage Modifier")]
        public int DamageModifier { get; set; } 
        [DisplayName("Weapon")]
        public int Weapon { get; set; }
        [DisplayName("Armor Class")]
        public int ArmorClass { get; set; }
    }
}