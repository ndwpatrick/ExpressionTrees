using System.Data;
using System.Linq.Expressions;

namespace ExpressionTrees
{
    public class Rule<T>
    {
        // Step 1: Define a Rule Structure
        private Func<T, bool> Condition { get; set; }
        private string Description { get; set; }

        // Generating dummy data for testing
        private IEnumerable<User> users = new List<User>
        {
            new User { Name = "John", Age = 30, Country = "USA" },
            new User { Name = "Jane", Age = 22, Country = "UK" },
            new User { Name = "Doe", Age = 28, Country = "India" }
        };

        //Step 2: Build Expression Tree Dynamically
        public void DoExecute()
        {
            var parameter = Expression.Parameter(typeof(User), "u");

            var ageExpr = Expression.GreaterThan(
                Expression.Property(parameter, "Age"),
                Expression.Constant(25)
            );

            var countryExpr = Expression.Equal(
                Expression.Property(parameter, "Country"),
                Expression.Constant("India")
            );

            var body = Expression.AndAlso(ageExpr, countryExpr);
            var lambda = Expression.Lambda<Func<User, bool>>(body, parameter);
            var isEligible = lambda.Compile();
            var results = users.Where(isEligible).ToList();

            //Step 3: Add Rule to Engine
            var rule = new Rule<User>
            {
                Condition = lambda.Compile(),
                Description = "User is Indian and older than 25"
            };

            // Step 4: Iterate over the users collection to find the matching record
            foreach (var user in results)
            {
                if (rule.Condition(user))
                {
                    Console.WriteLine($"✅ Rule Matched with description: {rule.Description} for User: {user.Name}");
                }
            }
            Console.WriteLine($"Total users matching the rule: {results.Count} out of {users.Count()}");
        }
    }
}