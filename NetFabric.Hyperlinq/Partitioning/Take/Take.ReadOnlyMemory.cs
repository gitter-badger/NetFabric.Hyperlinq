﻿using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyMemory<TSource> Take<TSource>(this ReadOnlyMemory<TSource> source, int count) 
            => source.Slice(0, Utils.Take(source.Length, count));
    }
}
