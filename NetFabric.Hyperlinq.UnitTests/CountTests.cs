using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class CountTests
    {
        [Fact]
        public void Count_With_NullSource_Should_Throw()
        {
            // Arrange

            // Act
            Action action = () => Enumerable.Count<IEnumerable<int>, IEnumerator<int>, int>(null);

            // Assert
            action.Should()
                .ThrowExactly<ArgumentNullException>()
                .And
                .ParamName.Should()
                    .Be("source");
        }

        public static TheoryData<IReadOnlyCollection<int>> IEnumerableData =>
            new TheoryData<IReadOnlyCollection<int>> 
            {
                { new int[] {} },
                { new int[] { 0 }  },
                { new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 } },
            };

        [Theory]
        [MemberData(nameof(IEnumerableData))]
        public void Count_With_ValidIEnumerable_Should_Succeed(IReadOnlyCollection<int> source)
        {
            // Arrange

            // Act
            var result = source.Count();

            // Assert
            result.Should().Be(source.Count);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        public void Count_With_ValidRange_Should_Succeed(int expected)
        {
            // Arrange
            var range = Enumerable.Range(0, expected);

            // Act
            var result = range.Count();

            // Assert
            result.Should().Be(expected);
        }        

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        public void Count_With_ValidSelect_Should_Succeed(int expected)
        {
            // Arrange
            var select = Enumerable.Range(0, expected)
                .Select<int>(value => value);

            // Act
            var result = select.Count();

            // Assert
            result.Should().Be(expected);
        }        

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        public void Count_With_ValidWhere_Should_Succeed(int expected)
        {
            // Arrange
            var where = Enumerable.Range(0, expected)
                .Where(_ => true);

            // Act
            var result = where.Count();

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        public void Count_With_ValidEnumerableReferenceType_Should_Succeed(int expected)
        {
            // Arrange
            var enumerable = TestEnumerable.ReferenceType(expected);

            // Act
            var result = enumerable.Count();

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        public void Count_With_ValidEnumerableValueType_Should_Succeed(int expected)
        {
            // Arrange
            var enumerable = TestEnumerable.ValueType(expected);

            // Act
            var result = enumerable.Count<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>();

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        public void CountPredicate_With_ValidEnumerableReferenceType_Should_Succeed(int expected)
        {
            // Arrange
            var enumerable = TestEnumerable.ReferenceType(expected);

            // Act
            var result = enumerable.Count(_ => true);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        public void CountPredicate_With_ValidEnumerableValueType_Should_Succeed(int expected)
        {
            // Arrange
            var enumerable = TestEnumerable.ValueType(expected);

            // Act
            var result = enumerable.Count<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(_ => true);

            // Assert
            result.Should().Be(expected);
        }
    }
}