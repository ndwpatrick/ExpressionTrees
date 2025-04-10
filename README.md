# Expression Trees in C#

This project demonstrates the use of **Expression Trees** in C# to dynamically build and execute rules for filtering data. The project includes a generic `Rule<T>` class that evaluates conditions on a collection of `User` objects.

## Features

- **Dynamic Expression Trees**: Build and compile expressions at runtime.
- **Rule Engine**: Define and execute rules dynamically using lambda expressions.
- **LINQ Integration**: Filter collections using dynamically generated conditions.

## Project Structure

- **`Rule<T>` Class**: A generic class that defines a rule structure and dynamically builds expression trees.
- **`User` Class**: Represents a user with properties like `Name`, `Age`, and `Country`.
- **Dummy Data**: A collection of `User` objects is used for testing the rule engine.

## How It Works

1. **Define a Rule**:

   - A rule is defined using an expression tree that combines conditions (e.g., age > 25 and country == "India").

2. **Compile the Rule**:

   - The expression tree is compiled into a lambda function.

3. **Filter Data**:

   - The compiled lambda function is used to filter the `User` collection.

4. **Output Results**:
   - The matching users are displayed along with the rule description.

## Example Code

Here’s an example of how the rule engine works:

```csharp
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

```

## Prerequisites

- .NET 6.0 or later
- Basic understanding of C# and LINQ

## Author

- **Pratik**  
  [GitHub Profile](https://github.com/ndwpatrick)
