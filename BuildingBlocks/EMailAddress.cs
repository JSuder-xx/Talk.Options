using System;
using Optional;

namespace Talk.Options.BuildingBlocks
{
    public class EmailAddress : StringValue
    {
        protected EmailAddress(string email) : base(email) { }

        /// <summary>
        /// Returns Some(EmailAddress) if the string is correctly formed otherwise None.
        /// </summary>
        public static Option<EmailAddress> Create(string candidate) =>
            string.IsNullOrWhiteSpace(candidate) || (candidate.Split("@", StringSplitOptions.RemoveEmptyEntries).Length != 2)
            ? Option.None<EmailAddress>()
            : Option.Some(new EmailAddress(candidate));
    }
}
