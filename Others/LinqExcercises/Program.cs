// See https://aka.ms/new-console-template for more information

using CSharp_Skills_LINQ;

IEnumerable<char> query = "Not what you might expect";
string vowels = "aeiou";

//for( int i = 0; i < vowels.Length; i++ )
//{
//    char c = vowels[i]; // <-- need to retrieve this one first to avoid early execution
//    query = query.Where(x => x != c);
//}

foreach (var c in vowels)
{
    query = query.Where(x => x != c);
}

foreach ( char c in query )
{
    Console.WriteLine(c);
}

LINQ_IEnumerable_Tutorial.RetrieveItemsFromLINQ();

LINQ_IEnumerable_Tutorial.StringFromLINQ();
//LINQ_IEnumerable_Tutorial.ReportFiles();

//LINQ_XML_Tutorial.GetNamesFromXML("Files\\student.xml")
//    .ForEach(Console.WriteLine);