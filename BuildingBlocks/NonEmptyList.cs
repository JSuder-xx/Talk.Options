using Optional;
using System.Linq;
using System.Collections.Generic;

namespace Talk.Options.BuildingBlocks
{
    public class NonEmptyList<T>
    {
        protected NonEmptyList(T firstItem, IEnumerable<T> remaining)
        {
            FirstItem = firstItem;
            Remaining.AddRange(remaining);
        }

        public T FirstItem { get; set; } 
        public readonly List<T> Remaining = new List<T>();

        /// <summary>
        /// The constructor is protected from the outside world and the only way to create
        /// a NonEmptyList is _guarded_ static method that returns an option. In other words it
        /// tells the world that it may not succeed. 
        /// </summary>
        public static Option<NonEmptyList<T>> Create(IEnumerable<T> items) =>
            items.Any()
            ? Option.Some(new NonEmptyList<T>(items.First(), items.Skip(1)))
            : Option.None<NonEmptyList<T>>();                
    }
}
