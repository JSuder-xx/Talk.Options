using Optional;
using Talk.Options.BuildingBlocks;

/// <summary>
/// With the help of Option and the concept of a secured perimeter we can finally address 
/// numerous possibilities for malforming simple data to bring the total errors from 18 downto a final tally of 6.
/// 
/// So that is C# pre-9. Let's take a look at C# 9 and Kotlin.
/// </summary>
namespace Talk.Options.WithSingleCaseUnions
{
    public class Address
    {
        public NonEmptyString Line1 { get; set; } // null
        public Option<NonEmptyString> Line2 { get; set; } 
        public NonEmptyString City { get; set; } // null
    }

    public class Order { }
    
    public class Customer
    {
        public NonEmptyString Name { get; set; } // null
        public Option<PhoneNumber> PhoneNumber { get; set; } 
        public EmailAddress EmailAddress { get; set; } // null
        public Address Billing { get; set; } // null
        public Option<Address> Shipping { get; set; } 
        public NonEmptyList<Order> Orders { get; set; } // null
    }
}
