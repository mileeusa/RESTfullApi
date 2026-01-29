using System.Text.RegularExpressions;

namespace CSharp_Skills_LINQ
{
    public class LINQ_IQueryable_Tutorial
    {
        /// <summary>
        /// Examples to retrieve data using EF Core
        /// </summary>
        public static void RetrieveItemsFromLINQ()
        {
            Regex wordCounter = new Regex(@"\b(\w+|[-'])+\b");
            //using var dbContext = GetDbContext();

            //var query = dbContext.MedicalArticles
            //    .where(article => article.Topic == "influenza")
            //    .AsEnumberale()
            //    .WHERE(article => wordCounter.Matches(article.Abstract).Count < 100);
        }

        //private static DbContext GetDbContext ()
        //{
        //    return null;
        //}
    }
}
