using System.Xml.Linq;

namespace VB_DevoraLime_Test.Entities
{
    public class Cavalry : Hero
    {
        public new int MaxHealth = 150;
        public new HeroTypes HeroType = HeroTypes.Cavalry;
        public override int Id { get; set; }
        private int health;
        public override int Health
        {
            get { return health; }
            set
            {
                if (value <= 0 || value < (MaxHealth / 4))
                {
                    Console.WriteLine($"{this} has died.");
                    health = 0;
                }
                else
                {
                    health = value;
                }
            }
        }
        public Cavalry(int id) : base(id)
        {
            Health = this.MaxHealth;
        }

        public override void Defense(Hero attacker)
        {
            switch (attacker.HeroType)
            {
                case HeroTypes.Archer:
                    if (Helpers.RandomEvent(0.4))
                    {
                        this.Health = 0;
                    }
                    break;
                case HeroTypes.Cavalry:
                    this.Health = 0;
                    break;
                case HeroTypes.Swordman:
                default:
                    break;
            }
        }

        public override string ToString() => $"{Id}_Cavarly";

        public override void Heal(int hp)
        {
            Health = Math.Min(Health + hp, MaxHealth);
        }
    }
}
