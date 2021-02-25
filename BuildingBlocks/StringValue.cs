using System;
using Optional;

namespace Talk.Options.BuildingBlocks
{
    /// <summary>
    /// This is a base class for a Value type which guards a string.
    /// Strings are, themselves, immutable.
    /// This class wraps a string value and that value cannot be overwritten. 
    /// </summary>
    public abstract class StringValue
    {
        protected StringValue(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public override string ToString() => Value;

        public override int GetHashCode() => Value.GetHashCode();

        public override bool Equals(object obj) =>
            obj is StringValue asStringValue && (obj.GetType() == this.GetType())
            ? asStringValue.Value.Equals(Value)
            : base.Equals(obj);

        public static implicit operator string(StringValue val) => val.Value;

        /// <summary>
        /// Used by descendant classes to easily make guarded constructors.
        /// </summary>
        protected static Func<string, Option<T>> FactoryFactory<T>(System.Text.RegularExpressions.Regex regex, Func<string, T> create) =>
            (string candidate) =>
                string.IsNullOrWhiteSpace(candidate) || !regex.IsMatch(candidate)
                    ? Option.None<T>()
                    : Option.Some(create(candidate));
    }
}
