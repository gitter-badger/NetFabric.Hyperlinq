using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class ToArrayBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Array() =>
            System.Linq.Enumerable.ToArray(array);

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public int[] Linq_List() =>
            System.Linq.Enumerable.ToArray(list);

        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Range() =>
            System.Linq.Enumerable.ToArray(linqRange);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Enumerable_Reference() =>
            System.Linq.Enumerable.ToArray(enumerableReference);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Enumerable_Value() =>
            System.Linq.Enumerable.ToArray(enumerableValue);

        [BenchmarkCategory("Array_As_IEnumerable")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Array_AsEnumerable() =>
            System.Linq.Enumerable.ToArray(arrayAsEnumerable);

        [BenchmarkCategory("Array_As_IReadOnlyCollection")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Array_AsReadOnlyCollection() =>
            System.Linq.Enumerable.ToArray(arrayAsReadOnlyCollection);

        [BenchmarkCategory("Array_As_IReadOnlyList")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Array_AsReadOnlyList() =>
            System.Linq.Enumerable.ToArray(arrayAsReadOnlyList);

        [BenchmarkCategory("List_As_IEnumerable")]
        [Benchmark(Baseline = true)]
        public int[] Linq_List_AsEnumerable() =>
            System.Linq.Enumerable.ToArray(listAsEnumerable);

        [BenchmarkCategory("List_As_IReadOnlyCollection")]
        [Benchmark(Baseline = true)]
        public int[] Linq_List_AsReadOnlyCollection() =>
            System.Linq.Enumerable.ToArray(listAsReadOnlyCollection);

        [BenchmarkCategory("List_As_IReadOnlyList")]
        [Benchmark(Baseline = true)]
        public int[] Linq_List_AsReadOnlyList() =>
            System.Linq.Enumerable.ToArray(listAsReadOnlyList);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int[] Hyperlinq_Array() =>
            array.ToArray();

        [BenchmarkCategory("List")]
        [Benchmark]
        public int[] Hyperlinq_List() =>
            list.ToArray();

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int[] Hyperlinq_Range() =>
            hyperlinqRange.ToArray();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int[] Hyperlinq_Enumerable_Reference() =>
            enumerableReference.ToArray();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int[] Hyperlinq_Enumerable_Value() =>
            enumerableValue.ToArray<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>();

        [BenchmarkCategory("Array_As_IEnumerable")]
        [Benchmark]
        public int[] Hyperlinq_Array_AsEnumerable() =>
            arrayAsEnumerable.ToArray();

        [BenchmarkCategory("Array_As_IReadOnlyCollection")]
        [Benchmark]
        public int[] Hyperlinq_Array_AsReadOnlyCollection() =>
            arrayAsReadOnlyCollection.ToArray();

        [BenchmarkCategory("Array_As_IReadOnlyList")]
        [Benchmark]
        public int[] Hyperlinq_Array_AsReadOnlyList() =>
            arrayAsReadOnlyList.ToArray();

        [BenchmarkCategory("List_As_IEnumerable")]
        [Benchmark]
        public int[] Hyperlinq_List_AsEnumerable() =>
            listAsEnumerable.ToArray();

        [BenchmarkCategory("List_As_IReadOnlyCollection")]
        [Benchmark]
        public int[] Hyperlinq_List_AsReadOnlyCollection() =>
            listAsReadOnlyCollection.ToArray();

        [BenchmarkCategory("List_As_IReadOnlyList")]
        [Benchmark]
        public int[] Hyperlinq_List_AsReadOnlyList() =>
            listAsReadOnlyList.ToArray();
    }
}
