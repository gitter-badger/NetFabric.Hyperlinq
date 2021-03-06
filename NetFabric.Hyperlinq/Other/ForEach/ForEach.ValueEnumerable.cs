﻿using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        public static void ForEach<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Action<TSource> action)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (action is null) Throw.ArgumentNullException(nameof(action));

            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
                action(enumerator.Current);
        }

        static void ForEach<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Action<TSource> action, Predicate<TSource> predicate)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (predicate(item))
                    action(item);
            }
        }

        static void ForEach<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Action<TSource> action, PredicateAt<TSource> predicate)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var enumerator = source.GetEnumerator();
            checked
            {
                for (var index = 0; enumerator.MoveNext(); index++)
                {
                    var item = enumerator.Current;
                    if (predicate(item, index))
                        action(item);
                }
            }
        }

        static void ForEach<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Action<TResult> action, Selector<TSource, TResult> selector)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
                action(selector(enumerator.Current));
        }

        static void ForEach<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Action<TResult> action, SelectorAt<TSource, TResult> selector)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var enumerator = source.GetEnumerator();
            checked
            {
                for (var index = 0; enumerator.MoveNext(); index++)
                    action(selector(enumerator.Current, index));
            }
        }

        static void ForEach<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Action<TResult> action, Predicate<TSource> predicate, Selector<TSource, TResult> selector)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (predicate(item))
                    action(selector(item));
            }
        }

        public static void ForEach<TEnumerable, TEnumerator, TSource>(this TEnumerable source, ActionAt<TSource> action)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (action is null) Throw.ArgumentNullException(nameof(action));

            using var enumerator = source.GetEnumerator();
            checked
            {
                for (var index = 0;  enumerator.MoveNext(); index++)
                    action(enumerator.Current, index);
            }
        }

        static void ForEach<TEnumerable, TEnumerator, TSource>(this TEnumerable source, ActionAt<TSource> action, Predicate<TSource> predicate)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var enumerator = source.GetEnumerator();
            checked
            {
                var itemIndex = 0;
                for (var index = 0;  enumerator.MoveNext(); index++)
                {
                    var item = enumerator.Current;
                    if (predicate(item))
                        action(item, itemIndex++);
                }
            }
        }

        static void ForEach<TEnumerable, TEnumerator, TSource>(this TEnumerable source, ActionAt<TSource> action, PredicateAt<TSource> predicate)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var enumerator = source.GetEnumerator();
            checked
            {
                var itemIndex = 0;
                for (var index = 0;  enumerator.MoveNext(); index++)
                {
                    var item = enumerator.Current;
                    if (predicate(item, index))
                        action(item, itemIndex++);
                }
            }
        }

        static void ForEach<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, ActionAt<TResult> action, Selector<TSource, TResult> selector)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var enumerator = source.GetEnumerator();
            checked
            {
                for (var index = 0; enumerator.MoveNext(); index++)
                    action(selector(enumerator.Current), index);
            }
        }

        static void ForEach<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, ActionAt<TResult> action, SelectorAt<TSource, TResult> selector)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var enumerator = source.GetEnumerator();
            checked
            {
                for (var index = 0; enumerator.MoveNext(); index++)
                    action(selector(enumerator.Current, index), index);
            }
        }

        static void ForEach<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, ActionAt<TResult> action, Predicate<TSource> predicate, Selector<TSource, TResult> selector)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var enumerator = source.GetEnumerator();
            checked
            {
                var itemIndex = 0;
                for (var index = 0;  enumerator.MoveNext(); index++)
                {
                    var item = enumerator.Current;
                    if (predicate(item))
                        action(selector(item), itemIndex++);
                }
            }
        }
    }
}

