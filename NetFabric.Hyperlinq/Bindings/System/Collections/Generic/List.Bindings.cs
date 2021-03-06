using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ListBindings
    {
        [Pure]
        public static int Count<TSource>(this List<TSource> source)
            => source.Count;

        [Pure]
        public static ReadOnlyList.SkipTakeEnumerable<List<TSource>, TSource> Skip<TSource>(this List<TSource> source, int count)
            => ReadOnlyList.Skip<List<TSource>, TSource>(source, count);

        [Pure]
        public static ReadOnlyList.SkipTakeEnumerable<List<TSource>, TSource> Take<TSource>(this List<TSource> source, int count)
            => ReadOnlyList.Take<List<TSource>, TSource>(source, count);

        [Pure]
        public static bool All<TSource>(this List<TSource> source, Predicate<TSource> predicate)
            => ReadOnlyList.All<List<TSource>, TSource>(source, predicate);
        [Pure]
        public static bool All<TSource>(this List<TSource> source, PredicateAt<TSource> predicate)
            => ReadOnlyList.All<List<TSource>, TSource>(source, predicate);

        [Pure]
        public static bool Any<TSource>(this List<TSource> source)
            => source.Count != 0;
        [Pure]
        public static bool Any<TSource>(this List<TSource> source, Predicate<TSource> predicate)
            => ReadOnlyList.Any<List<TSource>, TSource>(source, predicate);
        [Pure]
        public static bool Any<TSource>(this List<TSource> source, PredicateAt<TSource> predicate)
            => ReadOnlyList.Any<List<TSource>, TSource>(source, predicate);

        [Pure]
        public static bool Contains<TSource>(this List<TSource> source, TSource value)
            => source.Contains(value);
        [Pure]
        public static bool Contains<TSource>(this List<TSource> source, TSource value, IEqualityComparer<TSource>? comparer)
            => ReadOnlyList.Contains<List<TSource>, TSource>(source, value, comparer);

        [Pure]
        public static ReadOnlyList.SelectEnumerable<List<TSource>, TSource, TResult> Select<TSource, TResult>(
            this List<TSource> source,
            Selector<TSource, TResult> selector)
            => ReadOnlyList.Select<List<TSource>, TSource, TResult>(source, selector);
        [Pure]
        public static ReadOnlyList.SelectIndexEnumerable<List<TSource>, TSource, TResult> Select<TSource, TResult>(
            this List<TSource> source,
            SelectorAt<TSource, TResult> selector)
            => ReadOnlyList.Select<List<TSource>, TSource, TResult>(source, selector);

        [Pure]
        public static ReadOnlyList.SelectManyEnumerable<List<TSource>, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this List<TSource> source,
            Selector<TSource, TSubEnumerable> selector)
            where TSubEnumerable : notnull, IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => ReadOnlyList.SelectMany<List<TSource>, TSource, TSubEnumerable, TSubEnumerator, TResult>(source, selector);

        [Pure]
        public static ReadOnlyList.WhereEnumerable<List<TSource>, TSource> Where<TSource>(
            this List<TSource> source,
            Predicate<TSource> predicate)
            => ReadOnlyList.Where<List<TSource>, TSource>(source, predicate);
        [Pure]
        public static ReadOnlyList.WhereIndexEnumerable<List<TSource>, TSource> Where<TSource>(
            this List<TSource> source,
            PredicateAt<TSource> predicate)
            => ReadOnlyList.Where<List<TSource>, TSource>(source, predicate);

        [Pure]
        public static TSource ElementAt<TSource>(this List<TSource> source, int index)
            => ReadOnlyList.ElementAt<List<TSource>, TSource>(source, index);
        [Pure]
        [return: MaybeNull]
        public static TSource ElementAtOrDefault<TSource>(this List<TSource> source, int index)
            => ReadOnlyList.ElementAtOrDefault<List<TSource>, TSource>(source, index);
        [Pure]
        public static Maybe<TSource> TryElementAt<TSource>(this List<TSource> source, int index)
            => ReadOnlyList.TryElementAt<List<TSource>, TSource>(source, index);

        [Pure]
        public static TSource First<TSource>(this List<TSource> source)
            => ReadOnlyList.First<List<TSource>, TSource>(source);
        [Pure]
        [return: MaybeNull]
        public static TSource FirstOrDefault<TSource>(this List<TSource> source)
            => ReadOnlyList.FirstOrDefault<List<TSource>, TSource>(source);

        [Pure]
        public static TSource Single<TSource>(this List<TSource> source)
            => ReadOnlyList.Single<List<TSource>, TSource>(source);
        [Pure]
        [return: MaybeNull]
        public static TSource SingleOrDefault<TSource>(this List<TSource> source)
            => ReadOnlyList.SingleOrDefault<List<TSource>, TSource>(source);

        [Pure]
        public static ReadOnlyList.DistinctEnumerable<List<TSource>, TSource> Distinct<TSource>(this List<TSource> source, IEqualityComparer<TSource>? comparer = null)
            => ReadOnlyList.Distinct<List<TSource>, TSource>(source, comparer);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TSource> AsEnumerable<TSource>(this List<TSource> source)
            => source;

        [Pure]
        public static ValueWrapper<TSource> AsValueEnumerable<TSource>(this List<TSource> source)
            => new ValueWrapper<TSource>(source);

        [Pure]
        public static TSource[] ToArray<TSource>(this List<TSource> source)
            => ReadOnlyList.ToArray<List<TSource>, TSource>(source);

        [Pure]
        public static List<TSource> ToList<TSource>(this List<TSource> source)
            => new List<TSource>(source);

        [Pure]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this List<TSource> source, Selector<TSource, TKey> keySelector)
            => ReadOnlyList.ToDictionary<List<TSource>, TSource, TKey>(source, keySelector);
        [Pure]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this List<TSource> source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
            => ReadOnlyList.ToDictionary<List<TSource>, TSource, TKey>(source, keySelector, comparer);
        [Pure]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this List<TSource> source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector)
            => ReadOnlyList.ToDictionary<List<TSource>, TSource, TKey, TElement>(source, keySelector, elementSelector);
        [Pure]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this List<TSource> source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer)
            => ReadOnlyList.ToDictionary<List<TSource>, TSource, TKey, TElement>(source, keySelector, elementSelector, comparer);

        public static void ForEach<TSource>(this List<TSource> source, Action<TSource> action)
            => ReadOnlyList.ForEach<List<TSource>, TSource>(source, action);
        public static void ForEach<TSource>(this List<TSource> source, ActionAt<TSource> action)
            => ReadOnlyList.ForEach<List<TSource>, TSource>(source, action);
        
        public readonly partial struct ValueWrapper<TSource>
            : IValueReadOnlyList<TSource, List<TSource>.Enumerator>
            , IList<TSource>
        {
            readonly List<TSource> source;

            public ValueWrapper(List<TSource> source) 
                => this.source = source;

            public readonly int Count
                => source.Count;

            [MaybeNull]
            public readonly TSource this[int index] => source[index];

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly List<TSource>.Enumerator GetEnumerator() => source.GetEnumerator();
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => source.GetEnumerator();
            readonly IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();

            [MaybeNull]
            TSource IList<TSource>.this[int index]
            {
                get => source[index];
                set => throw new NotImplementedException();
            }

            bool ICollection<TSource>.IsReadOnly  
                => true;

            void ICollection<TSource>.CopyTo(TSource[] array, int arrayIndex) 
                => source.CopyTo(array, arrayIndex);
            void ICollection<TSource>.Add(TSource item) 
                => throw new NotImplementedException();
            void ICollection<TSource>.Clear() 
                => throw new NotImplementedException();
            bool ICollection<TSource>.Contains(TSource item) 
                => source.Contains(item);
            bool ICollection<TSource>.Remove(TSource item) 
                => throw new NotImplementedException();
            int IList<TSource>.IndexOf(TSource item)
                => source.IndexOf(item);
            void IList<TSource>.Insert(int index, TSource item)
                => throw new NotImplementedException();
            void IList<TSource>.RemoveAt(int index)
                => throw new NotImplementedException();
        }    
    }
}