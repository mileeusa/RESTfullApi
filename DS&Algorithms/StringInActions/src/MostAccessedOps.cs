using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInActions
{
    public class MostAccessedOps
    {
        public static List<string> TopTenMostAccessedIPs(string fileName)
        {
            if (string.IsNullOrEmpty(fileName) || !File.Exists(fileName))
            {
                return new List<string>();
            }

            var ipCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            var lines = File.ReadAllLines(fileName);

            foreach (var line in lines)
            {
                var columns = line.Split(',', StringSplitOptions.RemoveEmptyEntries);

                if (columns.Length >= 3)
                {
                    string ipAddr = columns[1];
                    if (!ipCounts.ContainsKey(ipAddr))
                    {
                        ipCounts[ipAddr] = 1;
                    }
                    else
                    {
                        ipCounts[ipAddr]++;
                    }
                }
            }

            var topTen = ipCounts.OrderByDescending(kvp => kvp.Value).Take(10);

            return topTen.Select(kvp => $"{kvp.Key}").ToList<string>();
        }
    }
}
