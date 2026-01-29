using InitializerInActions.src;

namespace InitializerInActions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CollectionOps.ListInitializer_Test();
            CollectionOps.DictionaryInitializer_Test();
            CollectionOps.StackInitializer_Test();
            CollectionOps.AnonymousInitializer_Test();
            CollectionOps.ListToDictionary_Test();
        }
    }
}