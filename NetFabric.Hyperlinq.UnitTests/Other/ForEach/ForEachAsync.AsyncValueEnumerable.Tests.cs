using NetFabric.Assertive;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Other.ForEachAsync
{
    public class AsyncValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public async ValueTask ForEachAsync_Action_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var result = new List<int>();
            var expected = new List<int>();
            System.Linq.EnumerableEx.ForEach(source, item => expected.Add(item));

            // Act
            await AsyncValueEnumerable
                .ForEachAsync<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, (item, cancellationToken) => { result.Add(item); return new ValueTask(); });

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public async ValueTask ForEachAsync_Action_Predicate_With_ValidData_Must_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var result = new List<int>();
            var expected = new List<int>();
            System.Linq.EnumerableEx.ForEach(
                System.Linq.Enumerable.Where(source, predicate.AsFunc()), item => expected.Add(item));

            // Act
            await AsyncValueEnumerable
                .Where<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                .ForEachAsync((item, cancellationToken) => { result.Add(item); return new ValueTask(); });

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public async ValueTask ForEachAsync_Action_PredicateAt_With_ValidData_Must_Succeed(int[] source, PredicateAt<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var result = new List<int>();
            var expected = new List<int>();
            System.Linq.EnumerableEx.ForEach(
                System.Linq.Enumerable.Where(source, predicate.AsFunc()), item => expected.Add(item));

            // Act
            await AsyncValueEnumerable
                .Where<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                .ForEachAsync((item, cancellationToken) => { result.Add(item); return new ValueTask(); });

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public async ValueTask ForEachAsync_Action_Selector_With_ValidData_Must_Succeed(int[] source, Selector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var result = new List<string>();
            var expected = new List<string>();
            System.Linq.EnumerableEx.ForEach(
                System.Linq.Enumerable.Select(source, selector.AsFunc()), item => expected.Add(item));

            // Act
            await AsyncValueEnumerable
                .Select<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int, string>(wrapped, selector.AsAsync())
                .ForEachAsync((item, cancellationToken) => { result.Add(item); return new ValueTask(); });

            // Assert
            _ = result.Must()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public async ValueTask ForEachAsync_Action_SelectorAt_With_ValidData_Must_Succeed(int[] source, SelectorAt<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var result = new List<string>();
            var expected = new List<string>();
            System.Linq.EnumerableEx.ForEach(
                System.Linq.Enumerable.Select(source, selector.AsFunc()), item => expected.Add(item));

            // Act
            await AsyncValueEnumerable
                .Select<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int, string>(wrapped, selector.AsAsync())
                .ForEachAsync((item, cancellationToken) => { result.Add(item); return new ValueTask(); });

            // Assert
            _ = result.Must()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorMultiple), MemberType = typeof(TestData))]
        public async ValueTask ForEachAsync_Action_Predicate_Selector_With_ValidData_Must_Succeed(int[] source, Predicate<int> predicate, Selector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var result = new List<string>();
            var expected = new List<string>();
            System.Linq.EnumerableEx.ForEach(
                System.Linq.Enumerable.Select(
                    System.Linq.Enumerable.Where(source, predicate.AsFunc()), selector.AsFunc()), item => expected.Add(item));

            // Act
            await AsyncValueEnumerable
                .Where<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                .Select(selector.AsAsync())
                .ForEachAsync((item, cancellationToken) => { result.Add(item); return new ValueTask(); });

            // Assert
            _ = result.Must()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected);
        }

        /////////////////////////////
        // ActionAt

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public async ValueTask ForEachAsync_ActionAt_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var result = new List<(int, int)>();
            var expected = new List<(int, int)>();
            System.Linq.EnumerableEx.ForEach(source, (item, index) => expected.Add((item, index)));

            // Act
            await AsyncValueEnumerable
                .ForEachAsync<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, (item, index, cancellationToken) => { result.Add((item, index)); return new ValueTask(); });

            // Assert
            _ = result.Must()
                .BeEnumerableOf<(int, int)>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public async ValueTask ForEachAsync_ActionAt_Predicate_With_ValidData_Must_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var result = new List<(int, int)>();
            var expected = new List<(int, int)>();
            System.Linq.EnumerableEx.ForEach(
                System.Linq.Enumerable.Where(source, predicate.AsFunc()), (item, index) => expected.Add((item, index)));

            // Act
            await AsyncValueEnumerable
                .Where<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                .ForEachAsync((item, index, cancellationToken) => { result.Add((item, index)); return new ValueTask(); });

            // Assert
            _ = result.Must()
                .BeEnumerableOf<(int, int)>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public async ValueTask ForEachAsync_ActionAt_PredicateAt_With_ValidData_Must_Succeed(int[] source, PredicateAt<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var result = new List<(int, int)>();
            var expected = new List<(int, int)>();
            System.Linq.EnumerableEx.ForEach(
                System.Linq.Enumerable.Where(source, predicate.AsFunc()), (item, index) => expected.Add((item, index)));

            // Act
            await AsyncValueEnumerable
                .Where<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                .ForEachAsync((item, index, cancellationToken) => { result.Add((item, index)); return new ValueTask(); });

            // Assert
            _ = result.Must()
                .BeEnumerableOf<(int, int)>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public async ValueTask ForEachAsync_ActionAt_Selector_With_ValidData_Must_Succeed(int[] source, Selector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var result = new List<(string, int)>();
            var expected = new List<(string, int)>();
            System.Linq.EnumerableEx.ForEach(
                System.Linq.Enumerable.Select(source, selector.AsFunc()), (item, index) => expected.Add((item, index)));

            // Act
            await AsyncValueEnumerable
                .Select<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int, string>(wrapped, selector.AsAsync())
                .ForEachAsync((item, index, cancellationToken) => { result.Add((item, index)); return new ValueTask(); });

            // Assert
            _ = result.Must()
                .BeEnumerableOf<(string, int)>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public async ValueTask ForEachAsync_ActionAt_SelectorAt_With_ValidData_Must_Succeed(int[] source, SelectorAt<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var result = new List<(string, int)>();
            var expected = new List<(string, int)>();
            System.Linq.EnumerableEx.ForEach(
                System.Linq.Enumerable.Select(source, selector.AsFunc()), (item, index) => expected.Add((item, index)));

            // Act
            await AsyncValueEnumerable
                .Select<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int, string>(wrapped, selector.AsAsync())
                .ForEachAsync((item, index, cancellationToken) => { result.Add((item, index)); return new ValueTask(); });

            // Assert
            _ = result.Must()
                .BeEnumerableOf<(string, int)>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorMultiple), MemberType = typeof(TestData))]
        public async ValueTask ForEachAsync_ActionAt_Predicate_Selector_With_ValidData_Must_Succeed(int[] source, Predicate<int> predicate, Selector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var result = new List<(string, int)>();
            var expected = new List<(string, int)>();
            System.Linq.EnumerableEx.ForEach(
                System.Linq.Enumerable.Select(
                    System.Linq.Enumerable.Where(source, predicate.AsFunc()), selector.AsFunc()), (item, index) => expected.Add((item, index)));

            // Act
            await AsyncValueEnumerable
                .Where<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                .Select(selector.AsAsync())
                .ForEachAsync((item, index, cancellationToken) => { result.Add((item, index)); return new ValueTask(); });

            // Assert
            _ = result.Must()
                .BeEnumerableOf<(string, int)>()
                .BeEqualTo(expected);
        }
    }
}