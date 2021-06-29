using System;
using System.Collections.Generic;
using System.Text;

namespace Gridnine.FlightCodingTest.Helpers
{
    public static class LinqExtension
    {
        public static IEnumerable<TSource> TakeWhileAggregate<TSource, TAccumulate>(
    this IEnumerable<TSource> source,
    TAccumulate seed,
    Func<TAccumulate, TSource, TAccumulate> func,
    Func<TAccumulate, bool> predicate
)
        {
            TAccumulate accumulator = seed;
            foreach (TSource item in source)
            {
                accumulator = func(accumulator, item);
                if (predicate(accumulator))
                {
                    yield return item;
                }
                else
                {
                    yield break;
                }
            }
        }

        public static IEnumerable<TResult> SelectPairs<TSource,TResult>(this IEnumerable<TSource> source, Func<TSource, TSource, TResult> selector)
        {
            var first = true;
            var prev = default(TSource);
            foreach (var curr in source)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    yield return selector(prev, curr);
                }
                prev = curr;
            }
        }

        public static bool SumWhile<TSource,TAccumulate>(this IEnumerable<TSource> source,
    TAccumulate seed,
    Func<TAccumulate, TSource, TAccumulate> func,
    Func<TAccumulate, bool> predicate)
        {
            bool retBool = false;
            TAccumulate accumulator = seed;
            foreach (TSource item in source)
            {
                accumulator = func(accumulator, item);
                if (predicate(accumulator))
                {
                    continue;
                }
                else
                {
                    retBool =  true;
                    break;
                }
            }
            return retBool;
        }
    }
}
