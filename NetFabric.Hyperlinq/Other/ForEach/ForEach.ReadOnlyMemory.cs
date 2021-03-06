﻿using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ForEach<TSource>(this ReadOnlyMemory<TSource> source, Action<TSource> action)
            => ForEach(source.Span, action);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ForEach<TSource>(this ReadOnlyMemory<TSource> source, ActionAt<TSource> action)
            => ForEach(source.Span, action);
    }
}

