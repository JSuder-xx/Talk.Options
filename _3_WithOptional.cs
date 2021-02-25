using Optional;

/// <summary>
/// By using this type we drop the number of errors from roughly 18 downto 15.
/// And most importantly we have now documented what is optional which means that by contrast everything 
/// else can be expected to be present. 
/// 
/// We have a choice here:
/// - Use Option for everything and get protection against NREs at run-time BUT lose documentation.
/// - Use Option just for nullable things to get protection against the most _probable_ NREs AND get documentation.
/// </summary>
namespace Talk.Options.WithOptional
{
    public class Address
    {
        public string Line1 { get; set; } // null, empty
        public Option<string> Line2 { get; set; } // empty
        public string City { get; set; } // null, empty
    }

    public class Order {  }    

    public class Customer
    {
        public string Name { get; set; } // null, empty
        public Option<string> PhoneNumber { get; set; } // empty, malformed
        public string EmailAddress { get; set; } // null, empty, malform
        public Address Billing { get; set; } // null
        public Option<Address> Shipping { get; set; } 
        public Order[] Orders { get; set; } // null, empty
    }

}
