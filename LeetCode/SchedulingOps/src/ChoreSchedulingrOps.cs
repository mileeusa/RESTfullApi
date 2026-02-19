using System;
using System.Collections.Generic;
using System.Text;

namespace SchedulingOps.src
{
    public class Chore
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; } // in minutes
        public List<Chore> Dependencies { get; set; } = new List<Chore>();

        public override bool Equals(object? obj)
        {
            return Equals(obj as Chore);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public bool Equals(Chore? obj)
        {
            return (obj != null) && (obj.Id == this.Id);
        }
    }

    public class ChoreSchedulingrOps
    {
        public static int CalculateMinimumDuration(List<Chore> chores)
        {
            var queue = new Queue<Chore>();
            var inDegree = new Dictionary<Chore, int>();
            var dependentMap = new Dictionary<Chore, List<Chore>>();
            var earliestCompletion = new Dictionary<Chore, int>();

            foreach (var chore in chores)
            {
                inDegree[chore] = chore.Dependencies.Count;
                if (chore.Dependencies.Count == 0)
                {
                    queue.Enqueue(chore);
                    earliestCompletion[chore] = chore.Duration;
                }

                foreach (var dep in chore.Dependencies)
                {
                    if (!dependentMap.ContainsKey(dep))
                    {
                        dependentMap[dep] = new List<Chore>();
                    }
                    dependentMap[dep].Add(chore);
                }
            }

            int totalDuration = 0;
            int processedChores = 0;

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                processedChores++;
                totalDuration = Math.Max(totalDuration, earliestCompletion[current]);

                if (!dependentMap.ContainsKey(current))
                {
                    continue;
                }

                foreach (var next in dependentMap[current])
                {
                    inDegree[next]--;
                    earliestCompletion[next] = Math.Max(earliestCompletion.GetValueOrDefault(next, 0),
                                                         earliestCompletion[current] + next.Duration);
                    if (inDegree[next] == 0)
                    {
                        queue.Enqueue(next);
                    }
                }
            }

            if (processedChores != chores.Count)
            {
                throw new InvalidOperationException("Cyclic dependency detected among chores.");
            }

            return totalDuration;
        }
    }
}
