using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Element.ElementAt
{
    public class ValueReadOnlyCollectionTests
    {
        [Theory]
        [MemberData(nameof(TestData.ElementAtOutOfRange), MemberType = typeof(TestData))]
        public void ElementAt_With_OutOfRange_Must_Throw(int[] source, int index)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyCollection(source);

            // Act
            Action action = () => _ = ValueReadOnlyCollection
                .ElementAt<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int>(wrapped, index);

            // Assert
            _ = action.Must()
                .Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [MemberData(nameof(TestData.ElementAt), MemberType = typeof(TestData))]
        public void ElementAt_With_ValidData_Must_Succeed(int[] source, int index)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyCollection(source);
            var expected = 
                System.Linq.Enumerable.ElementAt(wrapped, index);

            // Act
            var result = ValueReadOnlyCollection
                .ElementAt<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int>(wrapped, index);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}