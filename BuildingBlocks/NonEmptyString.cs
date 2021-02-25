using Optional;

namespace Talk.Options.BuildingBlocks
{
    public class NonEmptyString : StringValue
    {
        protected NonEmptyString(string value) : base(value) { }

        /// <summary>
        /// Returns Some(NonEmptyString) if the string has more than whitespace; otherwise None.
        /// </summary>
        public static Option<NonEmptyString> Create(string candidate) =>
            string.IsNullOrWhiteSpace(candidate)
            ? Option.None<NonEmptyString>()
            : Option.Some(new NonEmptyString(candidate));
    }
}
