namespace LinqInActions.src
{
    public class WeightRanking
    {
        public static void ExecuteRankingPerScore()
        {
            Console.WriteLine("RankingPerScore:");
            var items = new List<(string Name, double Weight)>
            {
                ("ItemA", 2.5),
                ("ItemB", 3.0),
                ("ItemC", 1.5),
                ("ItemD", 4.0)
            };
            var rankedItems = items
                .OrderByDescending(item => item.Weight)
                .Select((item, index) => new
                {
                    Rank = index + 1,
                    item.Name,
                    item.Weight
                });
            foreach (var rankedItem in rankedItems)
            {
                Console.WriteLine($"Rank: {rankedItem.Rank}, Name: {rankedItem.Name}, Weight: {rankedItem.Weight}");
            }
            Console.WriteLine();
        }

        public static void ExecuteRankingPerCompoundScore()
        {
            Console.WriteLine("RankingPerCompoundScore:");

            var participants = new[]
            {
                new { Name = "Alice", Speed = 8, Strength = 7, Endurance = 9 },
                new { Name = "Bob", Speed = 9, Strength = 6, Endurance = 8 },
                new { Name = "Charlie", Speed = 6, Strength = 9, Endurance = 7 }
            };

            double wSpeed = 0.5;
            double wStrength = 0.3;
            double wEndurance = 0.2;

            var rankedItems = participants
                .Select(p => new
                {
                    p.Name,
                    WeightedScore = (p.Speed * wSpeed) + (p.Strength * wStrength) + (p.Endurance * wEndurance)
                })
                .OrderByDescending(p => p.WeightedScore)
                .Select((p, index) => new
                {
                    Rank = index + 1,
                    p.Name,
                    p.WeightedScore
                });

            foreach (var rankedItem in rankedItems)
            {
                Console.WriteLine($"Rank: {rankedItem.Rank}, Name: {rankedItem.Name}, Weight: {rankedItem.WeightedScore}");
            }
            Console.WriteLine();
        }

        public static void ExecuteRankingHavingTiedCompoundScore()
        {
            Console.WriteLine("RankingHavingTiedCompoundScore:");

            var participants = new[]
            {
                new { Name = "Alice", Speed = 8, Strength = 7, Endurance = 9 },
                new { Name = "Bob", Speed = 8, Strength = 7, Endurance = 9 },
                new { Name = "Charlie", Speed = 6, Strength = 9, Endurance = 7 }
            };

            double wSpeed = 0.5;
            double wStrength = 0.3;
            double wEndurance = 0.2;

            var rankedItems = participants
                .Select(p => new
                {
                    p.Name,
                    WeightedScore = (p.Speed * wSpeed) + (p.Strength * wStrength) + (p.Endurance * wEndurance)
                })
                .OrderByDescending(p => p.WeightedScore)
                .ToList()
                .Select((p, index) => new
                {
                    Rank = index + 1,
                    p.Name,
                    p.WeightedScore
                })
                .GroupBy(p => p.WeightedScore)
                .SelectMany((g, index) =>
                {
                    //var rank = g.First().Rank; // this would keep original rank with gaps, such as 1, 1, 3
                    return g.Select(item => new
                    {
                        Rank = index + 1, // rank + 1
                        item.Name,
                        item.WeightedScore
                    });
                });

            foreach (var rankedItem in rankedItems)
            {
                Console.WriteLine($"Rank: {rankedItem.Rank}, Name: {rankedItem.Name}, Weight: {rankedItem.WeightedScore}");
            }
            Console.WriteLine();
        }

        public static void WeightRanking_Test()
        {
            ExecuteRankingPerScore();
            ExecuteRankingPerCompoundScore();
            ExecuteRankingHavingTiedCompoundScore();
        }
    }
}
