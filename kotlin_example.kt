// https://play.kotlinlang.org/
class Address(
    val Line1: String,
    val Line2: String?,
    val City: String
)

fun createOrlandoAddress(line1: String?): Address? {
    return if (line1 == null)
    	// TRY: Uncomment the Address line below and comment out null. 
        // Address(Line1 = line1, Line2 = null, City = "Orlando");
        null;
    else 
    	Address(Line1 = line1, Line2 = null, City = "Orlando");
}

fun greet(name: String): String {
    return "$name!!!"
}

fun main() {
    println(greet("John"))
    //println(greet(null))    
    
    var addressOpt = createOrlandoAddress("123");
    if (addressOpt == null) {
        println(addressOpt.City);
    	println("Unable to make address");
    }
    else
    	println("Address Line 1: " + addressOpt.Line1);  
}

