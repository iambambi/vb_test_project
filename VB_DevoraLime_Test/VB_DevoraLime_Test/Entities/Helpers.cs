namespace VB_DevoraLime_Test.Entities
{
    public static class Helpers
    {
        public static bool RandomEvent(double probability)
        {
            Random random = new();
            return random.NextDouble() < probability;
        }
    }
}
