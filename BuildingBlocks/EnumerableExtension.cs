using System;
using System.Collections.Generic;
using System.Linq;

namespace Talk.Options.BuildingBlocks
{
    public static class EnumerableExtension
    {
        public delegate Result NonEmptyListTransform<Item, Result>(Item firstItem, IEnumerable<Item> remainingItems);
        public delegate void NonEmptyListAction<Item>(Item firstItem, IEnumerable<Item> remainingItems);

        /// <summary>
        /// This extension method can be used any vanilla enumerable to ensure safe access for computations that return a value.
        /// </summary>
        public static Result Match<Item, Result>(this IEnumerable<Item> items, Func<Result> empty, NonEmptyListTransform<Item, Result> nonEmpty) =>
            !items.Any()
            ? empty()
            : nonEmpty(items.First(), items.Skip(1));  
        
        /// <summary>
        /// Extension method to be used on vanilla enumerables to ensure safe access for imperative/side-effecty code.
        /// </summary>
        /// <typeparam name="Item"></typeparam>
        public static void Act<Item>(this IEnumerable<Item> items, Action empty, NonEmptyListAction<Item> nonEmpty)
        {
            if (!items.Any())
                empty();
            else
                nonEmpty(items.First(), items.Skip(1));
        }
    }
}
