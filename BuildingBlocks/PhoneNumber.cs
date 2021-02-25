using System;
using Optional;

namespace Talk.Options.BuildingBlocks
{
    public class PhoneNumber : StringValue
    {
        protected PhoneNumber(string number) : base(number) { }

        /// <summary>
        /// Returns Some(PhoneNumber) if the string is correctly formed otherwise None.
        /// </summary>
        public static readonly Func<string, Option<PhoneNumber>> Create = FactoryFactory(
            new System.Text.RegularExpressions.Regex(
                @"(\([0-9]{3}\)|[0-9]{3}-)[0-9]{3}-[0-9]{4}"
            ),
            (candidate) => new PhoneNumber(candidate)
        );
    }
}
