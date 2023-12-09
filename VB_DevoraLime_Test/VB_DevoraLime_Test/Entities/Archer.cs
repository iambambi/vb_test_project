namespace VB_DevoraLime_Test.Entities
{
    public class Archer : Hero
    {
        public new int MaxHealth = 100;
        public new HeroTypes HeroType = HeroTypes.Archer;
        public override int Id { get; set; }
        private int health;
        public override int Health
        {
            get { return health; }
            set
            {
                if (value <= 0 || value < (MaxHealth/4))
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

        public Archer(int id) : base(id)
        {
            Health = MaxHealth;
        }
        public override void Defense(Hero attacker)
        {
            switch (attacker.HeroType)
            {
                case HeroTypes.Archer:
                    this.Health = 0;
                    break;
                case HeroTypes.Swordman:
                    this.Health = 0;
                    break;
                case HeroTypes.Cavalry:
                    this.Health = 0;
                    break;
                default:
                    break;
            }
        }

        public override string ToString() => $"{Id}_Archer";
        public override void Heal(int hp)
        {
            Health = Math.Min(Health + hp, MaxHealth);
        }
    }
}
