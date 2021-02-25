/// <summary>
/// There are at least 18 kinds of run-time error that can occur when working with this model.
/// - Null reference exceptions: "Billion dollar mistake".
/// - Numerical relationships
/// - Malformed data
/// 
/// The type system does not document much about the expectations
/// - What is required? What is optional?
/// - How should things like phone number and e-mail address be shaped?
/// - Can we have a Customer without an Order? 
/// 
/// There first improvement we will consider is "How can we tell the type system that something is required? or optional?"
/// </summary>
namespace Talk.Options.Anemic
{
    public class Address
    {
        public string Line1 { get; set; } // null, empty
        public string Line2 { get; set; } // null, empty
        public string City { get; set; } // null, empty
    }

    public class Order { }

    public class Customer
    {
        public string Name { get; set; } // null, empty (ex. "", "    ")
        public string PhoneNumber { get; set; } // null, empty, malformed
        public string EmailAddress { get; set; } // null, empty, malformed
        public Address Billing { get; set; } // null
        public Address Shipping { get; set; } // null
        public Order[] Orders { get; set; } // null, empty - What if there is a business rule that every customer
                                            // must have at least One Order? 
    }    
}
