using System;
namespace Talk.Options.NullableWoes
{
    /// <summary>
    /// Demonstration of multiple limitations of Nullable in .NET.
    /// </summary>
    public static class Playground
    {
        public static void Example()
        {
            // #1: Cannot make non-value types (Classes!!!) nullable. 
            {
                //var x = new Talk.Options.Anemic.Address?();

                // HECK! We cannot even have a nullable of nullable.
                // var y = new Nullable<Nullable<int>>();
            }

            // #2: Easy run-time exceptions
            {
                int Add10(int? num) =>
                    num.HasValue
                    ? num.Value + 10
                    // Ruh roh Shaggy!!! We know that num is null in the False expression
                    // but here we are reading the value.
                    : num.Value;

                Add10(null); // <-- throws a run-time exception
            }

            // #3: Terrible ergonomics
            {
                var random = new Random();

                int? FickleLoad(int num) =>
                    num < random.Next()
                    ? new int?(random.Next())
                    : null;

                int? SequenceWithEscapeHatch(int num)
                {
                    var first = FickleLoad(num);
                    if (!first.HasValue)
                        return null;

                    var second = FickleLoad(first.Value < 100 ? first.Value + 10 : first.Value);
                    if (!second.HasValue)
                        return null;

                    var third = FickleLoad(second.Value);
                    return third.HasValue
                        ? new int?(first.Value + second.Value + third.Value)
                        : null;                          
                }
                SequenceWithEscapeHatch(1);

                int? SequencePyramidOfDoom(int num)
                {
                    var first = FickleLoad(num);
                    if (first.HasValue)
                    {
                        var second = FickleLoad(first.Value);
                        if (second.HasValue)
                        {
                            var third = FickleLoad(second.Value);
                            if (third.HasValue)
                            {
                                return new int?(first.Value + second.Value + third.Value);
                            }
                            else
                                return null;
                        }
                        else
                            return null;
                    }
                    else
                        return null;
                }
                SequencePyramidOfDoom(2);
            }
        }
    }
}
