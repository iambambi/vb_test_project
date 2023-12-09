namespace VB_DevoraLime_Test.Entities
{
    public class Game
    {
        private int HeroCount { get; set; }
        private const int healthIncrease = 10;
        private List<Hero> Heroes = [];
        private static readonly List<string> battleLog = [];

        public void Play() 
        {
            // Get the number of heroes
            this.GetHeroCount();
            // Generate fighting hero pool
            this.GenerateHeroes();

            while (Heroes.Count > 1)
            {
                Hero attacker = GetRandomHero();
                Hero defender = GetRandomHero(attacker);
                Log($"Battle: {attacker} vs {defender}");

                foreach (Hero hero in Heroes) 
                {
                    // Healing other heroes
                    if (hero.Id != attacker.Id && hero.Id != defender.Id)
                    {
                        var oldHp = hero.Health;
                        hero.Heal(10);
                        Log($"{hero} health changed from {oldHp} to {hero.Health}.");
                        
                        if (hero.IsHeroDead())
                        {
                            Log($"{hero} has died.");
                        }
                    }
                    else
                    {
                        var oldHp = hero.Health;
                        hero.Heal((-1) * (hero.Health/2));
                        Log($"{hero} health changed from {oldHp} to {hero.Health}.");

                        if (hero.IsHeroDead())
                        {
                            Log($"{hero} has died.");
                        }
                    }
                }

                // Make attack
                attacker.Attack(defender);
                Log($"{attacker} attacked {defender}.");

                // Check who dead in the fight & Log
                if (attacker.IsHeroDead())
                {
                    Heroes.Remove(attacker);
                    Log($"{attacker} has died.");
                }

                if (defender.IsHeroDead())
                {
                    Heroes.Remove(defender);
                    Log($"{defender} has died.");
                }

                if (!attacker.IsHeroDead() && !defender.IsHeroDead())
                {
                    Log($"{attacker} and {attacker} made a draw battle.");
                }
            }

            Log($"\n\n{Heroes.FirstOrDefault()} won the battle!");

            // Print battle events
            PrintBattleLog();
        }
        private Hero GetRandomHero(Hero exclude = null)
        {
            Random random = new();
            Hero randomHero;
            do
            {
                randomHero = this.Heroes[random.Next(this.Heroes.Count)];
            } while (randomHero == exclude);
            return randomHero;
        }
        private void GenerateHeroes()
        {
            List<Hero> heroes = [];

            for (int i = 0; i < HeroCount; i++)
            {
                switch (i % 3)
                {
                    case 0:
                        heroes.Add(new Archer(i));
                        break;
                    case 1:
                        heroes.Add(new Cavalry(i));
                        break;
                    case 2:
                        heroes.Add(new Swordman(i));
                        break;
                }
            }

            this.Heroes = heroes;
        }
        private void GetHeroCount()
        {
            Console.WriteLine("Please, enter the number of heroes: ");

            int n;
            while (!int.TryParse(Console.ReadLine(), result: out n))
            {
                Console.Clear();
                Console.WriteLine("You entered an invalid number!");
                Console.Write("Please, enter the valid number of heroes ( >= 2): ");
            }

            this.HeroCount = n > 2 ? n : 2;
        }
        private static void Log(string message) => battleLog.Add(message);
        private static void PrintBattleLog()
        {
            Console.Clear();
            Console.WriteLine("\nBattle Log:");
            foreach (var logEntry in battleLog)
            {
                Console.WriteLine(logEntry);
            }
        }
    }
}
