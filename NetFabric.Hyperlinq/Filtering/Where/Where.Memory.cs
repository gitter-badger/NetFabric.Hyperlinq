﻿using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemoryWhereEnumerable<TSource> Where<TSource>(this Memory<TSource> source, Predicate<TSource> predicate)
            => Where((ReadOnlyMemory<TSource>)source, predicate);
    }
}

