using System;
using System.Collections.Generic;
using System.Net;

namespace CustomSearchInActions.src;

public class Customer
{ 
    public string FirstName { get; set; } 
    public string LastName { get; set; }
    public string Address { get; set; }
}

public class SearchResult
{
    public Customer Customer { get; set; }
    public int Score { get; set; }
}

public class CustomeSearchFromHackerRank
{
    public static void Execute(Stream? stream)
    {
        //using var stdinstream = Console.OpenStandardInput();
        //using var stdin = new StreamReader(stdinstream);

        var streamReader = new StreamReader(stream ?? Console.OpenStandardInput());

        var lines = streamReader.ReadToEnd().Split("\n")
            .Select(line =>
            {
                return line.Split(',');
            });

        var weights = lines.Where(w => w[0] == "weight")
            .ToDictionary(x => x[1], x => int.Parse(x[2])); // firstName|lastName|weight <-> score

        var customers = lines.Where(c => c[0] == "customer")
            .Select(line => new Customer
            {
                FirstName = line[1],
                LastName = line[2],
                Address = line[3]
            })
            .ToList();

        var searchString = lines.Where(line => line[0] == "search")
            .Select(x => x[1])
            .First();

        // perform the search
        var searchResults = Search(weights, customers, searchString);

        // display the results
        foreach (var result in searchResults)
        {
            Console.WriteLine($"{result.Customer.FirstName} {result.Customer.LastName} {result.Customer.Address} - Score: {result.Score}");
        }
    }

    static List<SearchResult> Search(Dictionary<string, int> weights, List<Customer> customers, string searchString)
    {
        var results = new List<SearchResult>();
        var fullSearch = searchString.Trim().ToLowerInvariant();
        var tokens = TokenizeSearchString(fullSearch);

        foreach (var customer in customers)
        {
            int score = 0;
            score += CalculateFieldScore(customer.FirstName, "FirstName", weights, fullSearch, tokens);
            score += CalculateFieldScore(customer.LastName, "LastName", weights, fullSearch, tokens);
            score += CalculateFieldScore(customer.Address, "Address", weights, fullSearch, tokens);

            if (score == 0) continue;

            results.Add(new SearchResult 
            { 
                Customer = customer, 
                Score = score 
            });
        }

        return results
            .OrderByDescending(r => r.Score)
            .ThenBy(r => r.Customer.FirstName)
            .ThenBy(r => r.Customer.LastName)
            .Take(5)
            .ToList();
    }

    static List<string> TokenizeSearchString(string searchString)
    {
        // tokenize the search string
        return searchString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Where(token => token.Length >= 3)
            .ToList();
    }

    static int CalculateFieldScore(string fieldValue, string fieldName, Dictionary<string, int> weights, string fullSearch, List<string> tokens)
    {
        if (string.IsNullOrEmpty(fieldValue)) return 0;
        if (!weights.TryGetValue(fieldName, out int weight)) weight = 0;

        var field = fieldValue.ToLowerInvariant().Trim();
        int score = 0;

        var normalizedFullSearch = string.Join(" ", fullSearch.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

        // Full string match
        if (field.Contains(normalizedFullSearch))
        {
            return weight * 4;
        }

        // Token matches
        foreach (var token in tokens)
        {
            if (field.Equals(token))
                score += weight * 2;
            else if (field.Contains(token))
                score += weight * 1;
        }

        return score;
    }   
}