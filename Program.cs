namespace ExpressionTrees;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Rule<User> rule = new Rule<User>();
        rule.DoExecute();
        Console.ReadLine();
    }
}