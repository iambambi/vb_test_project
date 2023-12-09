namespace VB_DevoraLime_Test.Entities
{
    public abstract class Hero
    {
        public abstract int Id { get; set; }
        public abstract int Health { get; set; }
        public int MaxHealth;
        public HeroTypes HeroType;
        public bool IsHeroDead() => Health == 0;
        public virtual void Attack(Hero defender) => defender.Defense(this);
        public abstract void Defense(Hero attacker);

        public abstract void Heal(int hp);
        public abstract override string ToString();
        protected Hero(int id)
        {
            Id = id;
        }
    }
}
