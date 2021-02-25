using System;
using Optional;

namespace Talk.Options.BuildingBlocks
{
    public class ZipCode : StringValue
    {
        protected ZipCode(string code) : base(code) { }

        /// <summary>
        /// Returns Some(ZipCode) if the string is correctly formed otherwise None.
        /// </summary>
        public static readonly Func<string, Option<ZipCode>> Create = FactoryFactory(
            new System.Text.RegularExpressions.Regex(
                @"(\([0-9]{3}\)|[0-9]{3}-)[0-9]{3}-[0-9]{4}"
            ),
            (candidate) => new ZipCode(candidate)
        );
    }
}
