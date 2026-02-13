// See https://aka.ms/new-console-template for more information
using SchedulingOps.src;

var chores = new List<Chore>
{
    new () { Id = 1, Name = "Chore 1", Duration = 3, Dependencies = new List<Chore>() },
    new () { Id = 2, Name = "Chore 2", Duration = 2, Dependencies = new List<Chore>() },
    new ()
    {
        Id = 3,
        Name = "Chore 3",
        Duration = 4,
        Dependencies = new List<Chore>
        {
            new () { Id = 1, Name = "Chore 1", Duration = 3, Dependencies = new List<Chore>() }
        }
    },
    new ()
    {
        Id = 4,
        Name = "Chore 4",
        Duration = 1,
        Dependencies = new List<Chore>
        {
            new () { Id = 2, Name = "Chore 2", Duration = 2, Dependencies = new List<Chore>() }
        }
    }
};


// act
var result = ChoreSchedulingrOps.CalculateMinimumDuration(chores);
Console.WriteLine($"Minimum Duration: {result}");
