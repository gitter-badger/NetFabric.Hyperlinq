using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Projection.SelectIndex
{
    public class ValueEnumerableTests
    {
        [Fact]
        public void SelectIndex_With_NullSelector_Must_Throw()
        {
            // Arrange
            var enumerable = Wrap.AsValueEnumerable(new int[0]);
            var selector = (Selector<int, string>)null;

            // Act
            Action action = () => _ = ValueEnumerable.Select<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int, string>(enumerable, selector);

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "selector");
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void SelectIndex_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.Select(wrapped, (item, index) => (item + index).ToString());

            // Act
            var result = ValueEnumerable
                .Select<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int, string>(wrapped, (item, index) => (item + index).ToString());

            // Assert
            _ = result.Must()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected);
        }
    }
}