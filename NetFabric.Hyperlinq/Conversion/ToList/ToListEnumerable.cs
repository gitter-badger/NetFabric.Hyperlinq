﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static List<TSource> ToList<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

#if EXPRESSION_TREES
            return ToListMethod<TEnumerable, TSource>.Invoke(source);
#else
            var list = new List<TSource>();
            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                    list.Add(enumerator.Current);
            }
            return list;
#endif
        }

        internal static class ToListMethod<TEnumerable, TSource>
            where TEnumerable : IEnumerable<TSource>
        {
            public static Func<TEnumerable, List<TSource>> Invoke { get; } = Create();

            public static Func<TEnumerable, List<TSource>> Create()
            {
                var listType = typeof(List<>).MakeGenericType(typeof(TSource));
                var enumerable = Expression.Parameter(typeof(TEnumerable), "enumerable");
                var list = Expression.Variable(listType, "list");
                var current = Expression.Variable(typeof(TSource), "current");

                var body = Expression.Block(new ParameterExpression[] { list },
                    Expression.Assign(list, Expression.New(listType)),
                    ExpressionEx.ForEach(enumerable, current,
                        Expression.Call(list, listType.GetMethod("Add"), current)),
                    list);

                return Expression.Lambda<Func<TEnumerable, List<TSource>>>(body, enumerable).Compile();
            }
        }
    }
}
