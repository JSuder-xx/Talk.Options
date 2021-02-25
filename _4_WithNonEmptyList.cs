using Optional;
using System.Collections.Generic;
using System.Linq;
using Talk.Options.BuildingBlocks;

/// <summary>
/// We can further structurally enforce that we must always have at least one Order by creating a data type. 
/// This drops the number of errors from 18 downto 14.
/// 
/// This is obvious. It is not rocket science BUT we don't always live in the habit of using the type system to 
/// express our intentions.
/// 
/// Secured perimeter - NonEmptyList(s) construction.
/// </summary>
namespace Talk.Options.WithNonEmptyList
{
    public class Address
    {
        public string Line1 { get; set; } // null, empty
        public Option<string> Line2 { get; set; } // empty
        public string City { get; set; } // null, empty
    }

    public class Order { }

    public class Customer
    {
        public string Name { get; set; } // null, empty
        public Option<string> PhoneNumber { get; set; } // empty, malformed
        public string EmailAddress { get; set; } // null, empty, malformed
        public Address Billing { get; set; } // null
        public Option<Address> Shipping { get; set; }
        public NonEmptyList<Order> Orders { get; set; } // null
    }

    public static class Playground
    {
        /// <summary>
        /// Rather than throw an exception if receiving an empty list we moved the Validation up front
        /// and into the Type space to ensure that Average is, by definition and by construction, always
        /// going to return a value without throwing a divide by zero.
        /// 
        /// This is a PARADIGM shift 
        /// - From Defensive programming which throws exceptions
        /// - To using types to make assurances.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static double Average(NonEmptyList<int> list) =>
            (list.FirstItem + list.Remaining.Sum()) / (1 + list.Remaining.Count());

        public static string SafeTreatmentOfEnumerable(IEnumerable<Customer> customers) =>
            customers.Match(
                empty: () => "I am so sorry! Your business is failing.",
                nonEmpty: (first, remaining) =>
                    $"Your first customer is {first.Name}."
            );
    }
}
