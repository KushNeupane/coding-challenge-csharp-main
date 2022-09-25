using System;
using System.Collections.Generic;

/**
 *
 * Given is the following FizzBuzz application which counts from 1 to 100 and outputs either the corresponding
 * number or the corresponding text if one of the following rules apply.
 * Rules:
 *  - dividable by 3 without a remainder -> Fizz
 *  - dividable by 5 without a remainder -> Buzz
 *  - dividable by 3 and 5 without a remainder -> FizzBuzz
 *
 * ACCEPTANCE CRITERIA:
 * Please refactor this code so that it can be easily extended in the future with other rules, such as
 * "if it is dividable by 7 without a remainder output Bar"
 * "if multiplied by 10 is larger than 100 output Foo"
 *
 */

namespace FizzBuzz
{
    public class FizzBuzzEngine
    {
        private List<IRules> _rules;
        public FizzBuzzEngine(List<IRules> rules) => _rules = rules;

        public void Run(int limit = 100)
        {
            for (int i = 1; i <= limit; i++)
            {
                string output = string.Empty;
                foreach (var rule in _rules)
                {
                    output = rule.Operation(i);
                    if (!string.IsNullOrEmpty(output))
                        break;
                }
                if (output == string.Empty) { output = new DefaultOutput().Operation(i); }
                Console.WriteLine("{0}: {1}", i, output);
            }
        }
    }

    internal class FizzRule : IRules
    {
        public string Operation(int x)
        {
            return x % 3 == 0 ? "Fizz" : string.Empty;
        }
    }

    internal class BuzzRule : IRules
    {
        public string Operation(int x)
        {
            return x % 5 == 0 ? "Buzz" : string.Empty;
        }
    }

    internal class FizzAndBuzzRules : IRules
    {
        public string Operation(int x)
        {
            return x % 3 == 0 && x % 5 == 0 ? "FizzBuzz" : string.Empty;
        }
    }

    internal class FooRule : IRules
    {
        public string Operation(int x)
        {
            return x * 10 > 100 ? "Foo" : string.Empty;
        }
    }

    internal class BarRule : IRules
    {
        public string Operation(int x)
        {
            return x % 7 == 0 ? "Bar" : string.Empty;
        }
    }

    internal class DefaultOutput : IRules
    {
        public string Operation(int x)
        {
            return x.ToString();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var rules = new List<IRules>
            {
                new FizzAndBuzzRules(),
                new BarRule(),
                new FizzRule(),
                new BuzzRule(),
                new FooRule(),
            };
            new FizzBuzzEngine(rules).Run();
        }
    }
}
