using System;
using System.Linq;
using System.Collections.Generic;
using Optional;
using Optional.Linq;

namespace Talk.Options.OptionalImprovements
{
    /// <summary>
    /// Here we introduce the Option data type which represents that a value is there or not. 
    /// - Using the Optional NuGet package (1.5 million downloads)
    /// - A bit similar to the Optional type introduced in Java 8.
    /// - The Option type has a history in OCaml, F#, Rust, Scala, Swift, ReasonML, Coq, . 
    /// - The same data type is called a Maybe in Haskell, Elm, Idris, Agda.
    /// </summary>
    public static class OptionalImprovements
    {
        public static void OptionImprovements()
        {
            // #1: CAN make Option hold reference types (i.e. Classes).
            {
                var someAddress = Option.Some(new Anemic.Address());
                var missingAddress = Option.None<Anemic.Address>();
            }

            // #2: Hard to get run-time exceptions
            {
                int Add10(Option<int> num) =>
                    num.Match(
                        some: (value) => value + 10,
                        none: () => 0
                    );
                Add10(Option.None<int>());

                var someNumber = Option.Some(10);
                // uncomment for intellisense
                // someNumber

                // Options are Values (structs), stored on the stack, and so no need to instantiate
                Option<Anemic.Address> addressOpt; 
                // if using addressOpt here we would NOT get a NRE!!! The value would just be None.
            }

            // #3: Improved Ergonomics, support for LINQ
            {
                var random = new Random();

                Option<int> FickleLoad(int num) =>
                    num < random.Next()
                    ? Option.Some(random.Next())
                    : Option.None<int>();

                // Check it! We can sequence calls to Optional<T> with LINQ.
                // **DID YOU KNOW** You can make your own custom types (with a single type argument) work with LINQ.
                // See the 
                // https://github.com/nlkl/Optional/blob/master/src/Optional/Linq/OptionLinqExtensions.cs
                Option<int> SequenceUsingLINQ(int num) =>
                    from first in FickleLoad(num)
                    from second in FickleLoad(first < 100 ? first + 10 : first)
                    from third in FickleLoad(second)
                    select first + second + third;
                SequenceUsingLINQ(1);

                // For a mind expanding example see the .NET parser combinator library Sprache which builds parser functions 
                // which processes input in sequences by using LINQ
                // https://github.com/sprache/Sprache

                // Convert an Option (which is 0 or 1 things) to an Enumerable (which is 0 to Many thing) in order to interoperate with IEnumerable extensions.
                IEnumerable<Item> GetSomethings<Item>(IEnumerable<Option<Item>> itemOptions) =>
                    itemOptions.SelectMany(itemOption => itemOption.ToEnumerable());
                foreach (var num in GetSomethings(new[] { Option.Some(10), Option.Some(20), Option.None<int>(), Option.Some(30) }))
                {
                    Console.WriteLine(num);
                }
            }
        }

        public static void SafeTreatmentOfReferenceTypes()
        {
            Anemic.Customer customer = null;
            var safeCustomer = customer.SomeNotNull();
            safeCustomer.Match(
                some: (cust) =>
                {
                    Console.WriteLine(cust.Name);
                },
                none: () =>
                {
                    Console.WriteLine("Uh oh!!!");
                });
        }
    }
}
