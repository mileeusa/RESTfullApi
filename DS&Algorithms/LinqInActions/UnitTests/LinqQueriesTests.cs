using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqInActions.UnitTests
{
    [TestFixture]
    public class LinqQueriesTests
    {
        [Test]
        public void SubQueries_Test()
        {
            // arrange
            Console.WriteLine();
            Console.WriteLine("LinqQueries.SubQueries_Test:");
         
            // act
            LinqInActions.LINQQueries.SubQueries();

            // assert
        }

        [Test]
        public void LINQJoinWithMethodSyntax_Test()
        {
            // arrange
            Console.WriteLine();
            Console.WriteLine("LinqQueries.LINQJoinWithMethodSyntax_Test:");
            // act
            LinqInActions.LINQQueries.LINQJoinWithMethodSyntax();
            // assert
        }
    }
}
