using AutoFixture;
using Concepts.Core.Utils;
using FluentAssertions;
using Xunit;

namespace Concepts.Core.UnitTests.Utils
{
    public partial class UtilityTests
    {
        [Fact]
        public void ShouldReturnOriginalIdValueWhenIdIsEncodedAndDecodedBack()
        {
            //given
            long inputId = fixture.Create<long>();
            string toStringValueOfInputId = inputId.ToString();
            long expectedOutput = inputId;

            //when
            string hash = IdHashUtil.Encode(inputId);
            long decodedValue = IdHashUtil.Decode(hash);
            
            //then
            hash.Should().NotBe(toStringValueOfInputId);
            decodedValue.Should().Be(expectedOutput);

        }
    }
}